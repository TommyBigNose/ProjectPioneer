using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Statistics;

namespace ProjectPioneer.Systems.Equipment
{
	public interface IWeapon : ISellableEquipment
	{
		string Name { get; }
		string Description { get; }
		WeaponType WeaponType { get; }
		Stats Stats { get; }
	}

	public enum WeaponType
	{
		None,
		Blade,
		Gun,
		Staff,
	}
}
