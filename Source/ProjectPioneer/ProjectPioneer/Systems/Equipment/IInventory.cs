using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Character;

namespace ProjectPioneer.Systems.Equipment
{
	public interface IInventory
	{
		List<IEquipment> HeroInventory { get; }
		void AddEquipment(IEquipment equipment);
		int SellEquipment(IEquipment equipment);
		bool CanEquip(IEquipment equipment, IHero hero);
		void EquipEquipment(IEquipment equipment, EquipmentType equipmentType, IHero hero);
		void SortEquipment();
	}
}
