using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using ProjectPioneer.Systems.Character;
using ProjectPioneer.Systems.Dice;
using ProjectPioneer.Systems.Equipment;
using ProjectPioneer.Systems.Statistics;

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
			return _questInfo.Stats.Level;
		}

		public int GetCreditsReward()
		{
			return _questInfo.Stats.Level * Constants.QuestRewardCreditScaling;
		}

		public int GetExpReward()
		{
			return _questInfo.Stats.Level * Constants.QuestRewardExpScaling;
		}

		public IEnumerable<IEquipment> GetEquipmentReward()
		{
			List<IEquipment> returnedEquipment = new();

			foreach(IEquipment? equipment in _onGoingQuest.LootedEquipment)
			{
				if(equipment != null)
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
			Stats stats = heroStats.GetStatComparison(QuestInfo.Stats);

			return stats;
		}

		public int GetSecondReductionFromStatComparison(Stats comparedStats)
		{
			int secondReduction = 0;

			secondReduction += comparedStats.Level;
			secondReduction += comparedStats.PhysicalAttack;
			secondReduction += comparedStats.PhysicalDefense;
			secondReduction += comparedStats.MagicalAttack;
			secondReduction += comparedStats.MagicalDefense;
			secondReduction += comparedStats.Speed;
			secondReduction += comparedStats.FireAttack;
			secondReduction += comparedStats.FireDefense;
			secondReduction += comparedStats.IceAttack;
			secondReduction += comparedStats.IceDefense;
			secondReduction += comparedStats.LightningAttack;
			secondReduction += comparedStats.LightningDefense;
			secondReduction += comparedStats.EarthAttack;
			secondReduction += comparedStats.EarthDefense;

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
			if(IsProgressReadyForLootChance())
			{
				OnGoingQuest.LootedEquipment.Add(RollDiceForLoot());
			}
		}

		public bool IsProgressReadyForLootChance()
		{
			return OnGoingQuest.ProgressBar.Value >= (OnGoingQuest.LootIntervals * Math.Max(OnGoingQuest.LootedEquipment.Count, 1));
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

		public IEquipment? RollDiceForLoot()
		{
			IEquipment? equipment = null;
			
			// Chance for Rare Loot
			int diceRoll = _diceSystem.GetDiceRoll(1, 1001);
			if(diceRoll <= QuestInfo.ChanceForRareLoot)
			{
				return QuestInfo.RareLoot;
			}

			// Chance for Normal Loot if that doesn't pass
			diceRoll = _diceSystem.GetDiceRoll(1, 1001);
			if (diceRoll <= QuestInfo.ChanceForNormalLoot)
			{
				diceRoll = _diceSystem.GetDiceRoll(0, QuestInfo.NormalLoot.Count());
				return QuestInfo.NormalLoot.ToList()[diceRoll];
			}

			// Return null equipment if nothing
			return equipment;
		}
	}
}
