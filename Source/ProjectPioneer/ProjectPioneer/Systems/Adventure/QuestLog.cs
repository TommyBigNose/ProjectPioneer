using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPioneer.Systems.Adventure
{
	public class QuestLog : IQuestLog
	{
		public List<IQuest> Quests { get; } = new List<IQuest>();
		public List<IQuest> CompletedQuests { get; } = new List<IQuest>();

		public QuestLog()
		{

		}

		public void CompleteQuest(IQuest quest)
		{
			CompletedQuests.Add(quest);
		}
	}
}
