using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPioneer.Systems.Adventure
{
	public class OnGoingQuest
	{
		public QuestInfo QuestInfo { get; set; }
		public IProgressBar ProgressBar { get; set; }
		public int FinalQuestLengthInSeconds { get; set; }
		public float LootIntervals { get; set; }
		public System.Timers.Timer QuestTimer { get; set; }

		public OnGoingQuest(QuestInfo questInfo)
		{
			QuestInfo = questInfo;
			ProgressBar = new ProgressBar(TimeSpan.FromSeconds(QuestInfo.QuestLengthInSeconds));
			FinalQuestLengthInSeconds = QuestInfo.QuestLengthInSeconds;
			QuestTimer = new System.Timers.Timer(ProgressBar.IncrementTickRateInMs);
		}
	}
}
