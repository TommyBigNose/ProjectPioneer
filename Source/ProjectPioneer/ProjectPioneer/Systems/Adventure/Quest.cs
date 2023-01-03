using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using ProjectPioneer.Systems.Equipment;
using ProjectPioneer.Systems.Statistics;

namespace ProjectPioneer.Systems.Adventure
{
	public class Quest : IQuest
	{
		private bool _completed = false;
		public bool Completed => _completed;

		private QuestInfo _questInfo;
		public QuestInfo QuestInfo => _questInfo;

		private OnGoingQuest _onGoingQuest;
		public OnGoingQuest OnGoingQuest => _onGoingQuest;

		public Quest(QuestInfo questInfo)
		{
			_questInfo = questInfo;
			_onGoingQuest = new OnGoingQuest(QuestInfo);
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

		public Stats GetStatComparison(Stats heroStats)
		{
			// Hero Stats - Quest Stats
			// Positive is good for the player
			// Negative is bad for the player
			// Hero Attack vs Quest Defense
			// Hero Defense vs Quest Attack
			Stats stats = new Stats()
			{
				Level = heroStats.Level - QuestInfo.Stats.Level,

				PhysicalAttack = heroStats.PhysicalAttack - QuestInfo.Stats.PhysicalDefense,
				PhysicalDefense = heroStats.PhysicalDefense - QuestInfo.Stats.PhysicalAttack,

				MagicalAttack = heroStats.MagicalAttack - QuestInfo.Stats.MagicalDefense,
				MagicalDefense = heroStats.MagicalDefense - QuestInfo.Stats.MagicalAttack,

				Speed = heroStats.Speed - QuestInfo.Stats.Speed,

				FireAttack = heroStats.FireAttack - QuestInfo.Stats.FireDefense,
				FireDefense = heroStats.FireDefense - QuestInfo.Stats.FireAttack,

				IceAttack = heroStats.IceAttack - QuestInfo.Stats.IceDefense,
				IceDefense = heroStats.IceDefense - QuestInfo.Stats.IceAttack,

				LightningAttack = heroStats.LightningAttack - QuestInfo.Stats.LightningDefense,
				LightningDefense = heroStats.LightningDefense - QuestInfo.Stats.LightningAttack,

				EarthAttack = heroStats.EarthAttack - QuestInfo.Stats.EarthDefense,
				EarthDefense = heroStats.EarthDefense - QuestInfo.Stats.EarthAttack,
			};

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
		}

		public void QuestTimerElapsed(object? sender, ElapsedEventArgs e)
		{
			OnGoingQuest.ProgressBar.IncrementProgressBar();
			if(OnGoingQuest.ProgressBar.Value >= 
				(OnGoingQuest.LootIntervals * Math.Max(OnGoingQuest.LootedEquipment.Count, 1)))
			{
				OnGoingQuest.LootedEquipment.Add(null);
			}
		}

		public void EndQuest()
		{
			throw new NotImplementedException();
		}

		public void PauseQuest()
		{
			OnGoingQuest.QuestTimer.Stop();
		}

		public void CancelQuest()
		{
			OnGoingQuest.QuestTimer.Stop();
		}

		public void ContinueQuest()
		{
			OnGoingQuest.QuestTimer.Start();
		}

		public void ResetQuest()
		{
			OnGoingQuest.QuestTimer.Stop();
			_onGoingQuest = new OnGoingQuest(QuestInfo);
		}

		public bool IsQuestCompleted()
		{
			return (OnGoingQuest.ProgressBar.IsFinished());
		}

		public bool IsQuestOnGoing()
		{
			throw new NotImplementedException();
		}

		public IEquipment? RollDiceForLoot()
		{
			throw new NotImplementedException();
		}
	}
}
