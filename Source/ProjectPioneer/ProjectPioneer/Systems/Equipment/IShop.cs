namespace ProjectPioneer.Systems.Equipment
{
	public interface IShop
	{
		IEnumerable<IEquipment> GetShopInventory(int level);
		bool CanHeroAffordEquipment(IEquipment equipment, IInventory inventory);
		void BuyEquipmentAndAddToInventory(IEquipment equipment, IInventory inventory);
	}
}
