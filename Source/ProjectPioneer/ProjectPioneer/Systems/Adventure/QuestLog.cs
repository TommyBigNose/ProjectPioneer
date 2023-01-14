using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPioneer.Systems.Adventure
{
	public class QuestLog
	{
		public List<IQuest> Quests { get; set; } = new List<IQuest>();
		public List<IQuest> CompletedQuests { get; set; } = new List<IQuest>();
	}
}
