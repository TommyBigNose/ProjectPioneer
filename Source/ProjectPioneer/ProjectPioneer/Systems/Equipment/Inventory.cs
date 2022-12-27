using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Character;

namespace ProjectPioneer.Systems.Equipment
{
	public class Inventory : IInventory
	{
		private List<IEquipment> _heroInventory = new List<IEquipment>();
		public List<IEquipment> HeroInventory => _heroInventory;

		public void AddEquipment(IEquipment equipment)
		{
			HeroInventory.Add(equipment);
		}

		public bool CanEquip(IEquipment equipment, IHero hero)
		{
			return hero.CanEquip(equipment);
		}

		public void EquipEquipment(IEquipment equipment, EquipmentType equipmentType, IHero hero)
		{
			throw new NotImplementedException();
		}

		public int SellEquipment(IEquipment equipment)
		{
			throw new NotImplementedException();
		}

		public void SortEquipment()
		{
			throw new NotImplementedException();
		}
	}
}
