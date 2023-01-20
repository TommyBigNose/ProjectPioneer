using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Data;

namespace ProjectPioneer.Systems.Adventure
{
	public class QuestLog : IQuestLog
	{
		public HashSet<int> CompletedQuests { get; } = new HashSet<int>();

		public QuestLog() { }

		public QuestLog(HashSet<int> completedQuests)
		{
			CompletedQuests = completedQuests;
		}

		public void CompleteQuest(IQuest quest)
		{
			CompletedQuests.Add(quest.QuestInfo.ID);
		}
	}
}
