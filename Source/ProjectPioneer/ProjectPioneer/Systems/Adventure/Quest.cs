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
		public QuestInfo QuestInfo => throw new NotImplementedException();

		public IProgressBar ProgressBar => throw new NotImplementedException();

		public void CancelQuest()
		{
			throw new NotImplementedException();
		}

		public void EndQuest()
		{
			throw new NotImplementedException();
		}

		public int GetCreditsReward()
		{
			throw new NotImplementedException();
		}

		public int GetExpReward()
		{
			throw new NotImplementedException();
		}

		public int GetRecommendedLevel()
		{
			throw new NotImplementedException();
		}

		public int GetSecondReductionFromStatComparison(Stats comparedStats)
		{
			throw new NotImplementedException();
		}

		public Stats GetStatComparison(Stats heroStats)
		{
			throw new NotImplementedException();
		}

		public IEquipment? RollDiceForLoot()
		{
			throw new NotImplementedException();
		}

		public void StartQuest()
		{
			throw new NotImplementedException();
		}
	}
}
