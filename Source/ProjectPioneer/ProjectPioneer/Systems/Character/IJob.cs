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
		int ID { get; }
		string Name { get; }
		string Description { get; }
		IEnumerable<EquipmentType> EquipableTypes { get; }
		Stats Stats { get; }
	}
}
