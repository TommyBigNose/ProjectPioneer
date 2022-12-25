using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Statistics;

namespace ProjectPioneer.Systems.Equipment
{
	public class Aura : IEquipment
	{
		private readonly string _name = string.Empty;
		public string Name => _name;
		private readonly string _description = string.Empty;
		public string Description => _description;
		private readonly EquipmentType _equipmentType = EquipmentType.None;
		public EquipmentType EquipmentType => _equipmentType;
		private readonly Stats _stats;
		public Stats Stats => _stats;

		public Aura(string name, string description, EquipmentType equipmentType, Stats stats)
		{
			_name = name;
			_description = description;
			_equipmentType = equipmentType;
			_stats = stats;
		}

		public int GetPurchaseValue()
		{
			return _stats.Level * Constants.AuraCostScaling;
		}

		public int GetSellableValue()
		{
			return (int)Math.Ceiling(GetPurchaseValue() * Constants.EquipmentSellValueScaling);
		}
	}
}
