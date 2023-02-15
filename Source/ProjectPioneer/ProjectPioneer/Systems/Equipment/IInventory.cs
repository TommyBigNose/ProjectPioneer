using ProjectPioneer.Systems.Character;

namespace ProjectPioneer.Systems.Equipment
{
	public interface IInventory
	{
		int Credits { get; }
		List<IEquipment> HeroInventory { get; }
		void AddCredits(int credits);
		void RemoveCredits(int credits);
		void AddEquipment(IEquipment equipment);
		int SellEquipment(IEquipment equipment);
		bool CanEquip(IEquipment equipment, IHero hero);
		void EquipEquipment(IEquipment equipment, IHero hero);
		void SortEquipment();
	}
}
