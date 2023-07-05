namespace ProjectPioneer.Systems.Adventure
{
	public class Quest : IQuest
	{
		private readonly QuestInfo _questInfo;
		public QuestInfo QuestInfo => _questInfo;

		private OnGoingQuest _onGoingQuest;
		public OnGoingQuest OnGoingQuest => _onGoingQuest;

		private QuestStatus _status = QuestStatus.None;
		public QuestStatus Status => _status;

		private readonly IDiceSystem _diceSystem;

		public Quest(QuestInfo questInfo)
		{
			_questInfo = questInfo;
			_onGoingQuest = new OnGoingQuest(QuestInfo);
			_diceSystem = new DiceSystem();
		}

		public int GetRecommendedLevel()
		{
			return _questInfo.Stats!.Level;
		}

		public int GetCreditsReward()
		{
			return _questInfo.Stats!.Level * Constants.QuestRewardCreditScaling;
		}

		public int GetExpReward()
		{
			return _questInfo.Stats!.Level * Constants.QuestRewardExpScaling;
		}

		public IEnumerable<IEquipment> GetEquipmentReward()
		{
			List<IEquipment> returnedEquipment = new();

			foreach (IEquipment? equipment in _onGoingQuest.LootedEquipment)
			{
				if (equipment != null)
				{
					returnedEquipment.Add(equipment);
				}
			}

			return returnedEquipment;
		}

		public Stats GetStatComparison(Stats heroStats)
		{
			// Hero Stats - Quest Stats
			// Positive is good for the player
			// Negative is bad for the player
			// Hero Attack vs Quest Defense
			// Hero Defense vs Quest Attack
			Stats stats = heroStats.GetStatComparisonForQuest(QuestInfo.Stats!);

			return stats;
		}

		public int GetSecondReductionFromStatComparison(Stats comparedStats)
		{
			// TODO: This should be calculated differently.  If Defense wins, it shouldn't be negative?
			int secondReduction = 0;

			if(QuestInfo.StatTypeMultipliers!.Contains(StatType.Level)) secondReduction += (int)Math.Ceiling(comparedStats.Level * QuestInfo.StatTypeMultiplierRatio);
			else secondReduction += comparedStats.Level;

			if (QuestInfo.StatTypeMultipliers!.Contains(StatType.PhysicalAttack)) secondReduction += (int)Math.Ceiling(comparedStats.PhysicalAttack * QuestInfo.StatTypeMultiplierRatio);
			else secondReduction += comparedStats.PhysicalAttack;

			if (QuestInfo.StatTypeMultipliers!.Contains(StatType.PhysicalDefense)) secondReduction += (int)Math.Ceiling(comparedStats.PhysicalDefense * QuestInfo.StatTypeMultiplierRatio);
			else secondReduction += comparedStats.PhysicalDefense;

			if (QuestInfo.StatTypeMultipliers!.Contains(StatType.MagicalAttack)) secondReduction += (int)Math.Ceiling(comparedStats.MagicalAttack * QuestInfo.StatTypeMultiplierRatio);
			else secondReduction += comparedStats.MagicalAttack;

			if (QuestInfo.StatTypeMultipliers!.Contains(StatType.MagicalDefense)) secondReduction += (int)Math.Ceiling(comparedStats.MagicalDefense * QuestInfo.StatTypeMultiplierRatio);
			else secondReduction += comparedStats.MagicalDefense;

			if (QuestInfo.StatTypeMultipliers!.Contains(StatType.Speed)) secondReduction += (int)Math.Ceiling(comparedStats.Speed * QuestInfo.StatTypeMultiplierRatio);
			else secondReduction += comparedStats.Speed;

			if (QuestInfo.StatTypeMultipliers!.Contains(StatType.FireAttack)) secondReduction += (int)Math.Ceiling(comparedStats.FireAttack * QuestInfo.StatTypeMultiplierRatio);
			else secondReduction += comparedStats.FireAttack;

			if (QuestInfo.StatTypeMultipliers!.Contains(StatType.FireDefense)) secondReduction += (int)Math.Ceiling(comparedStats.FireDefense * QuestInfo.StatTypeMultiplierRatio);
			else secondReduction += comparedStats.FireDefense;

			if (QuestInfo.StatTypeMultipliers!.Contains(StatType.IceAttack)) secondReduction += (int)Math.Ceiling(comparedStats.IceAttack * QuestInfo.StatTypeMultiplierRatio);
			else secondReduction += comparedStats.IceAttack;

			if (QuestInfo.StatTypeMultipliers!.Contains(StatType.IceDefense)) secondReduction += (int)Math.Ceiling(comparedStats.IceDefense * QuestInfo.StatTypeMultiplierRatio);
			else secondReduction += comparedStats.IceDefense;

			if (QuestInfo.StatTypeMultipliers!.Contains(StatType.LightningAttack)) secondReduction += (int)Math.Ceiling(comparedStats.LightningAttack * QuestInfo.StatTypeMultiplierRatio);
			else secondReduction += comparedStats.LightningAttack;

			if (QuestInfo.StatTypeMultipliers!.Contains(StatType.LightningDefense)) secondReduction += (int)Math.Ceiling(comparedStats.LightningDefense * QuestInfo.StatTypeMultiplierRatio);
			else secondReduction += comparedStats.LightningDefense;

			if (QuestInfo.StatTypeMultipliers!.Contains(StatType.EarthAttack)) secondReduction += (int)Math.Ceiling(comparedStats.EarthAttack * QuestInfo.StatTypeMultiplierRatio);
			else secondReduction += comparedStats.EarthAttack;

			if (QuestInfo.StatTypeMultipliers!.Contains(StatType.EarthDefense)) secondReduction += (int)Math.Ceiling(comparedStats.EarthDefense * QuestInfo.StatTypeMultiplierRatio);
			else secondReduction += comparedStats.EarthDefense;

			return secondReduction;
		}

		public int GetFinalQuestLengthInSeconds(int secondReduction)
		{
			return Math.Max(Constants.QuestMinimumLengthInSeconds, QuestInfo.QuestLengthInSeconds - secondReduction);
		}

		public void StartQuest(Stats comparedStats)
		{
			// Calculate where chances for loot should go
			OnGoingQuest.FinalQuestLengthInSeconds = GetFinalQuestLengthInSeconds(GetSecondReductionFromStatComparison(comparedStats));
			OnGoingQuest.RefreshProgressBar();

			// Calculate when loot is received
			OnGoingQuest.LootIntervals = OnGoingQuest.ProgressBar.ValueMax / QuestInfo.TotalChancesForLoot;

			// Start timer
			OnGoingQuest.QuestTimer.Elapsed += QuestTimerElapsed;
			OnGoingQuest.QuestTimer.Start();

			_status = QuestStatus.OnGoing;
		}

		public void QuestTimerElapsed(object? sender, ElapsedEventArgs e)
		{
			OnGoingQuest.ProgressBar.IncrementProgressBar();
			// TODO: I think this needs to be called instead because it's being called extra due to UI async vs this being sync
			//if (IsProgressReadyForLootChance())
			//{
			//	OnGoingQuest.LootedEquipment.Add(RollDiceForLoot());
			//}
		}

		public bool IsProgressReadyForLootChance()
		{
			return OnGoingQuest.ProgressBar.Value >= (OnGoingQuest.LootIntervals * (OnGoingQuest.LootedEquipment.Count + 1));
		}

		public void AttemptLootChance()
		{
			if (IsProgressReadyForLootChance())
			{
				OnGoingQuest.LootedEquipment.Add(RollDiceForLoot());
			}
		}

		public void CompleteQuest()
		{
			_status = QuestStatus.Completed;
			OnGoingQuest.QuestTimer.Stop();
		}

		public void PauseQuest()
		{
			_status = QuestStatus.Paused;
			OnGoingQuest.QuestTimer.Stop();
		}

		public void CancelQuest()
		{
			_status = QuestStatus.Cancelled;
			OnGoingQuest.QuestTimer.Stop();
		}

		public void ContinueQuest()
		{
			_status = QuestStatus.OnGoing;
			OnGoingQuest.QuestTimer.Start();
		}

		public void ResetQuest()
		{
			_status = QuestStatus.None;
			OnGoingQuest.QuestTimer.Stop();
			_onGoingQuest = new OnGoingQuest(QuestInfo);
		}

		public bool IsQuestCompleted()
		{
			return (OnGoingQuest.ProgressBar.IsFinished());
		}

		public bool IsQuestOnGoing()
		{
			return (!OnGoingQuest.ProgressBar.IsFinished() &&
				_status == QuestStatus.OnGoing);
		}

		public bool IsLastLootRare()
		{
			IEquipment? lastEquipment = _onGoingQuest.LootedEquipment.Last();
			if (lastEquipment != null)
			{
				if(lastEquipment.ID == QuestInfo.RareLoot!.ID)
				{
					return true;
				}
			}

			return false;
		}

		public IEquipment? RollDiceForLoot()
		{
			IEquipment? equipment = null;

			// Chance for Rare Loot
			int diceRoll = _diceSystem.GetDiceRoll(1, 1001);
			if (diceRoll <= QuestInfo.ChanceForRareLoot)
			{
				return QuestInfo.RareLoot;
			}

			// Chance for Normal Loot if that doesn't pass
			diceRoll = _diceSystem.GetDiceRoll(1, 1001);
			if (diceRoll <= QuestInfo.ChanceForNormalLoot)
			{
				diceRoll = _diceSystem.GetDiceRoll(0, QuestInfo.NormalLoot!.Count());
				return QuestInfo.NormalLoot!.ToList()[diceRoll];
			}

			// Return null equipment if nothing
			return equipment;
		}
	}
}
