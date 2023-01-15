namespace ProjectPioneer.Systems.Adventure
{
	public interface IQuestLog
	{
		List<IQuest> Quests { get; }
		HashSet<IQuest> CompletedQuests { get; }
		void CompleteQuest(IQuest quest);
	}
}