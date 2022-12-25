using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Statistics;

namespace ProjectPioneer.Systems.Equipment
{
	public interface IEquipment
	{
		string Name { get; }
		string Description { get; }
		Stats Stats { get; }
		EquipmentType EquipmentType { get; }
		int GetPurchaseValue();
		int GetSellableValue();
	}

	public enum EquipmentType
	{
		None,
		Blade,
		Gun,
		Staff,
		Armor,
		Aura
	}
}
