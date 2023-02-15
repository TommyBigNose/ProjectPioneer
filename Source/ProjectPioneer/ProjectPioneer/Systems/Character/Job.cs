using ProjectPioneer.Systems.Equipment;
using ProjectPioneer.Systems.Statistics;

namespace ProjectPioneer.Systems.Character
{
	public class Job : IJob
	{
		private readonly int _id;
		public int ID => _id;

		private readonly string _name = string.Empty;
		public string Name => _name;

		private readonly string _description = string.Empty;
		public string Description => _description;

		private readonly IEnumerable<EquipmentType> _equipableTypes;
		public IEnumerable<EquipmentType> EquipableTypes => _equipableTypes;

		private readonly Stats _stats;
		public Stats Stats => _stats;

		public Job(int id, string name, string description, IEnumerable<EquipmentType> equipableTypes, Stats stats)
		{
			_id = id;
			_name = name;
			_description = description;
			_equipableTypes = equipableTypes;
			_stats = stats;
		}
	}
}
