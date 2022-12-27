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

		public void EquipEquipment(IEquipment equipment, IHero hero)
		{
			HeroInventory.Remove(equipment);

			IEquipment oldEquipment;
			switch (equipment.EquipmentType)
			{
				case EquipmentType.Armor:
					oldEquipment = hero.EquipArmorAndReturnOldArmor(equipment);
					break;
				case EquipmentType.Aura:
					oldEquipment = hero.EquipAuraAndReturnOldAura(equipment);
					break;
				default:
					oldEquipment = hero.EquipWeaponAndReturnOldWeapon(equipment);
					break;
			}

			HeroInventory.Add(oldEquipment);
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
