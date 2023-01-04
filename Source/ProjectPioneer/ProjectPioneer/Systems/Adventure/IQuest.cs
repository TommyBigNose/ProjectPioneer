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
		OnGoingQuest OnGoingQuest { get; }
		QuestStatus Status { get; }

		int GetRecommendedLevel();
		int GetCreditsReward();
		int GetExpReward();
		Stats GetStatComparison(Stats heroStats);
		int GetSecondReductionFromStatComparison(Stats comparedStats);
		int GetFinalQuestLengthInSeconds(int secondReduction);
		void StartQuest(Stats comparedStats);
		void QuestTimerElapsed(object? sender, ElapsedEventArgs e);
		void EndQuest();
		void PauseQuest();
		void CancelQuest();
		void ContinueQuest();
		void ResetQuest();
		bool IsQuestCompleted();
		bool IsQuestOnGoing();
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
