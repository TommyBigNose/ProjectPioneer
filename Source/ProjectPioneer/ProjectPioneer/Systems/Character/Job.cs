using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Equipment;
using ProjectPioneer.Systems.Statistics;

namespace ProjectPioneer.Systems.Character
{
	public class Job : IJob
	{
		private readonly string _name = string.Empty;
		public string Name => _name;
		private readonly string _description = string.Empty;
		public string Description => _description;
		private readonly IEnumerable<EquipmentType> _equipableWeaponTypes;
		public IEnumerable<EquipmentType> EquipableWeaponTypes => _equipableWeaponTypes;
		private readonly Stats _stats;
		public Stats Stats => _stats;

		public Job(string name, string description, IEnumerable<EquipmentType> equipableWeaponTypes, Stats stats)
		{
			_name = name;
			_description = description;
			_equipableWeaponTypes = equipableWeaponTypes;
			_stats = stats;
		}
	}
}
