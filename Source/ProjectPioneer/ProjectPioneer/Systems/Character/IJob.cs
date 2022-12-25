using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Equipment;
using ProjectPioneer.Systems.Statistics;

namespace ProjectPioneer.Systems.Character
{
	public interface IJob
	{
		string Name { get; }
		string Description { get; }
		IEnumerable<EquipmentType> EquipableWeaponTypes { get; }
		Stats Stats { get; }
	}
}
