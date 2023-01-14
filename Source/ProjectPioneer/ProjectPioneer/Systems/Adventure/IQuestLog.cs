namespace ProjectPioneer.Systems.Adventure
{
	public interface IQuestLog
	{
		List<IQuest> CompletedQuests { get; }
		List<IQuest> Quests { get; }
		void CompleteQuest(IQuest quest);
	}
}