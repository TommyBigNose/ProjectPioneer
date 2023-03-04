using System.Timers;
using ProjectPioneer.Systems.Equipment;
using ProjectPioneer.Systems.Statistics;

namespace ProjectPioneer.Systems.Adventure
{
	public interface IQuest
	{
		QuestInfo QuestInfo { get; }
		OnGoingQuest OnGoingQuest { get; }
		QuestStatus Status { get; }

		int GetRecommendedLevel();
		int GetCreditsReward();
		int GetExpReward();
		IEnumerable<IEquipment> GetEquipmentReward();
		Stats GetStatComparison(Stats heroStats);
		int GetSecondReductionFromStatComparison(Stats comparedStats);
		int GetFinalQuestLengthInSeconds(int secondReduction);
		void StartQuest(Stats comparedStats);
		void QuestTimerElapsed(object? sender, ElapsedEventArgs e);
		bool IsProgressReadyForLootChance();
		void AttemptLootChance();
		void CompleteQuest();
		void PauseQuest();
		void CancelQuest();
		void ContinueQuest();
		void ResetQuest();
		bool IsQuestCompleted();
		bool IsQuestOnGoing();
		bool IsLastLootRare();
		IEquipment? RollDiceForLoot();
	}

	public enum QuestStatus
	{
		None = 0,
		Completed = 1,
		OnGoing = 2,
		Paused = 3,
		Cancelled = 4
	}
}
