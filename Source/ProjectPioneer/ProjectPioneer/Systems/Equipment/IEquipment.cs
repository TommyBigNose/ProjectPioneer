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
		int ID { get; }
		string Name { get; }
		string Description { get; }
		Stats Stats { get; }
		EquipmentType EquipmentType { get; }
		int GetPurchaseValue();
		int GetSellableValue();
	}

	public enum EquipmentType
	{
		None = 0,
		Blade = 1,
		Gun = 2,
		Staff = 3,
		Armor = 4,
		Aura = 5
	}
}
