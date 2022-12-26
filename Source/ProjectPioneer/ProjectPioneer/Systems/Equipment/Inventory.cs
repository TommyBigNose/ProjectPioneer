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
		private IEnumerable<IEquipment> _heroInventory;
		public IEnumerable<IEquipment> HeroInventory => _heroInventory;

		public void AddEquipment(IEquipment equipment)
		{
			throw new NotImplementedException();
		}

		public void CanEquip(IEquipment equipment, IHero hero)
		{
			throw new NotImplementedException();
		}

		public void EquipEquipment(IEquipment equipment, EquipmentType equipmentType, IHero hero)
		{
			throw new NotImplementedException();
		}

		public int SellEquipment(IEquipment equipment)
		{
			throw new NotImplementedException();
		}
	}
}
