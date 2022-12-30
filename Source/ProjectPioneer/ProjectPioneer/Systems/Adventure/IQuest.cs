using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using ProjectPioneer.Systems.Equipment;
using ProjectPioneer.Systems.Statistics;

namespace ProjectPioneer.Systems.Adventure
{
	public interface IQuest
	{
		public bool Completed { get; }
		QuestInfo QuestInfo { get; }
		IProgressBar ProgressBar { get; }

		int GetRecommendedLevel();
		int GetCreditsReward();
		int GetExpReward();
		Stats GetStatComparison(Stats heroStats);
		int GetSecondReductionFromStatComparison(Stats comparedStats);
		void StartQuest();
		void EndQuest();
		void CancelQuest();
		IEquipment? RollDiceForLoot();
	}
}
