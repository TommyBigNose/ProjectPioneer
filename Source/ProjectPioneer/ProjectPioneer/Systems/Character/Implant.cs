using ProjectPioneer.Systems.Statistics;

namespace ProjectPioneer.Systems.Character
{
	public class Implant : IImplant
	{
		private readonly int _id;
		public int ID => _id;

		private readonly string _name = string.Empty;
		public string Name => _name;

		private readonly string _description = string.Empty;
		public string Description => _description;

		private readonly Stats _stats;
		public Stats Stats => _stats;

		public Implant(int id, string name, string description, Stats stats)
		{
			_id = id;
			_name = name;
			_description = description;
			_stats = stats;
		}
	}
}
