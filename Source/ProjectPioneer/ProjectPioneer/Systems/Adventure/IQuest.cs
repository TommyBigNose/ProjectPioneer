using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Equipment;
using ProjectPioneer.Systems.Statistics;

namespace ProjectPioneer.Systems.Adventure
{
	public interface IQuest
	{
		string Name { get; }
		string Description { get; }
		bool Completed { get; }
		int QuestLengthInSeconds { get; }
		Timer QuestTimer { get; }
		int ChanceForNormalLoot { get; }
		int ChanceForRareLoot { get; }
		int TotalChancesForLoot { get; }
		Stats Stats { get; }
		IProgressBar ProgressBar { get; }
		IEnumerable<IEquipment> NormalLoot { get; }
		IEquipment RareLoot { get; }

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
