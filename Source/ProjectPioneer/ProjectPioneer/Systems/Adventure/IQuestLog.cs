namespace ProjectPioneer.Systems.Adventure
{
	public interface IQuestLog
	{
		HashSet<int> CompletedQuests { get; }
		void CompleteQuest(IQuest quest);
	}
}