using ProjectPioneer.Systems.Statistics;

namespace ProjectPioneer.Systems.Character
{
	public interface IImplant
	{
		int ID { get; }
		string Name { get; }
		string Description { get; }
		Stats Stats { get; }
	}
}
