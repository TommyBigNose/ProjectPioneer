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


		public OnGoingQuest(QuestInfo questInfo)
		{
			QuestInfo = questInfo;
			ProgressBar = new ProgressBar(TimeSpan.FromSeconds(QuestInfo.QuestLengthInSeconds));
			FinalQuestLengthInSeconds = QuestInfo.QuestLengthInSeconds;
		}
	}
}
