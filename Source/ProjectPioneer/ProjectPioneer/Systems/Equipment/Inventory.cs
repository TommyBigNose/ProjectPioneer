using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Character;
using ProjectPioneer.Systems.Data;

namespace ProjectPioneer.Systems.Equipment
{
	public class Inventory : IInventory
	{
		private int _credits;
		[SaveableAttribute(Constants.AttributeInventoryCredits)]
		public int Credits => _credits;

		private List<IEquipment> _heroInventory = new List<IEquipment>();
		[SaveableAttribute(Constants.AttributeInventoryHerosInventory)]
		public List<IEquipment> HeroInventory => _heroInventory;

		public void AddCredits(int credits)
		{
			_credits += credits;
		}

		public void RemoveCredits(int credits)
		{
			if (_credits - credits <= 0)
				_credits = 0;
			else 
				_credits -= credits;
		}

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
			int creditValue = equipment.GetSellableValue();
			AddCredits(creditValue);
			HeroInventory.Remove(equipment);
			
			return creditValue;
		}

		public void SortEquipment()
		{
			_heroInventory = _heroInventory.OrderBy(_ => (int)_.EquipmentType)
				.ThenBy(_=>_.Stats.Level)
				.ToList();
		}
	}
}
