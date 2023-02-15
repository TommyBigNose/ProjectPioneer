using ProjectPioneer.Systems.Adventure;
using ProjectPioneer.Systems.Character;
using ProjectPioneer.Systems.Equipment;

namespace ProjectPioneer.Systems
{
	public interface IGame
	{
		IHero Hero { get; }
		IInventory Inventory { get; }
		IShop Shop { get; }
		IQuestLog QuestLog { get; }

		#region Hero
		void SetUpHero(string name, IJob job, IImplant implant);
		IEnumerable<IJob> GetAllJobs();
		IEnumerable<IImplant> GetAllImplants();
		void AddExp(int exp);
		int GetRequiredExp();
		void LevelUp();
		bool CanLevelUp();
		IEquipment GetEquippedWeapon();
		IEquipment GetEquippedArmor();
		IEquipment GetEquippedAura();
		#endregion

		#region Inventory
		IEnumerable<IEquipment> GetAllPossibleEquipment(int minlevel = 0, int maxLevel = 999);
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
		IEnumerable<IEquipment> GetShopInventory(int level);
		bool CanHeroAffordEquipment(IEquipment equipment, IInventory inventory);
		void BuyEquipmentAndAddToInventory(IEquipment equipment, IInventory inventory);
		#endregion

		#region Quest
		IEnumerable<IQuest> GetAllQuests();
		void CompleteQuest(IQuest quest);
		ISet<int> GetCompletedQuests();
		#endregion

		#region Data
		void SaveData();
		void LoadSavedData();
		#endregion

		#region System
		/// <summary>
		/// Random number greater than or equal to min, less than max
		/// min <= result < max
		/// </summary>
		/// <param name="min">Inclusive</param>
		/// <param name="max">Exclusive</param>
		/// <returns></returns>
		int GetDiceRoll(int min, int max);
		#endregion
	}
}
