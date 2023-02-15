using ProjectPioneer.Systems.Equipment;

namespace ProjectPioneer.Systems.Adventure
{
	public class OnGoingQuest
	{
		public QuestInfo QuestInfo { get; set; }
		public IProgressBar ProgressBar { get; set; }
		public int FinalQuestLengthInSeconds { get; set; }
		public float LootIntervals { get; set; }
		public List<IEquipment?> LootedEquipment { get; set; }
		public System.Timers.Timer QuestTimer { get; set; }

		public OnGoingQuest(QuestInfo questInfo)
		{
			QuestInfo = questInfo;
			ProgressBar = new ProgressBar(TimeSpan.FromSeconds(QuestInfo.QuestLengthInSeconds));
			FinalQuestLengthInSeconds = QuestInfo.QuestLengthInSeconds;
			LootedEquipment = new List<IEquipment?>();
			QuestTimer = new System.Timers.Timer(ProgressBar.IncrementTickRateInMs);
		}

		public void RefreshProgressBar()
		{
			ProgressBar = new ProgressBar(TimeSpan.FromSeconds(FinalQuestLengthInSeconds));
		}
	}
}
