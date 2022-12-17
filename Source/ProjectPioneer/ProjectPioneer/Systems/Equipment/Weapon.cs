using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Statistics;

namespace ProjectPioneer.Systems.Equipment
{
	public class Weapon : IWeapon
	{
		private readonly string _name = string.Empty;
		public string Name => _name;
		private readonly string _description = string.Empty;
		public string Description => _description;
		private readonly WeaponType _weaponType = WeaponType.None;
		public WeaponType WeaponType => _weaponType;
		private readonly Stats _stats;
		public Stats Stats => _stats;

		public Weapon(string name, string description, WeaponType weaponType, Stats stats)
		{
			_name = name;
			_description = description;
			_weaponType = weaponType;
			_stats = stats;
		}
	}
}
