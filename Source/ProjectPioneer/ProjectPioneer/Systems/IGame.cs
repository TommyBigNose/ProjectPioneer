using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Character;
using ProjectPioneer.Systems.Equipment;

namespace ProjectPioneer.Systems
{
	public interface IGame
	{
		IHero Hero { get; }
		IInventory Inventory { get; }
		IShop Shop { get; }

		#region Hero
		void SetUpHero(string name, IJob job, IImplant implant);
		IEnumerable<IJob> GetAllJobs();
		IEnumerable<IImplant> GetAllImplants();
		IEquipment GetEquippedWeapon();
		IEquipment GetEquippedArmor();
		IEquipment GetEquippedAura();
		#endregion

		#region Inventory
		int GetCredits();
		void AddCredits(int credits);
		void RemoveCredits(int credits);
		IEnumerable<IEquipment> GetInventory();
		void SellEquipment(IEquipment equipment);
		bool CanEquip(IEquipment equipment);
		void AddEquipment(IEquipment equipment);
		void SortEquipment();
		void EquipEquipment(IEquipment equipment, IHero hero);
		#endregion

		#region Shop
		//IEnumerable<IEquipment> GetShopInventory(int level);
		//bool CanPlayerAffordEquipment(IEquipment equipment, int credits);
		//void BuyEquipmentAndAddToInventory(IEquipment equipment, IInventory inventory)
		#endregion

		#region Quest
		#endregion
	}
}
