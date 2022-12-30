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

		private IProgressBar _progressBar;
		public IProgressBar ProgressBar => _progressBar;

		public Quest(QuestInfo questInfo)
		{
			_questInfo = questInfo;
			_progressBar = new ProgressBar(TimeSpan.FromSeconds(_questInfo.QuestLengthInSeconds));
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
			throw new NotImplementedException();
		}

		public void StartQuest()
		{
			throw new NotImplementedException();
		}


		public void EndQuest()
		{
			throw new NotImplementedException();
		}

		public void CancelQuest()
		{
			throw new NotImplementedException();
		}

		public IEquipment? RollDiceForLoot()
		{
			throw new NotImplementedException();
		}
	}
}
