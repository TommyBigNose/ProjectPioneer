using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Data;

namespace ProjectPioneer.Systems.Adventure
{
	public class QuestLog : IQuestLog
	{
		public List<IQuest> Quests { get; } = new List<IQuest>();
		public HashSet<IQuest> CompletedQuests { get; } = new HashSet<IQuest>();
		private readonly IDataSource _dataSource;

		public QuestLog(IDataSource dataSource)
		{
			_dataSource = dataSource;
			SetUpQuests();
		}

		public void CompleteQuest(IQuest quest)
		{
			CompletedQuests.Add(quest);
		}

		private void SetUpQuests()
		{
			_dataSource.GetAllQuestInfos().ToList().ForEach(_ => Quests.Add(new Quest(_)));
		}
	}
}
