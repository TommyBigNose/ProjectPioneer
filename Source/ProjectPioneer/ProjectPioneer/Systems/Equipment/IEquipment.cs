namespace ProjectPioneer.Systems.Equipment
{
	public interface IEquipment
	{
		int ID { get; }
		string Name { get; }
		string Description { get; }
		string ImageName { get; }
		Stats Stats { get; }
		EquipmentType EquipmentType { get; }
		int GetPurchaseValue();
		int GetSellableValue();
	}

	public enum EquipmentType
	{
		None = 0,
		Blade = 1,
		Gun = 2,
		Staff = 3,
		Armor = 4,
		Aura = 5
	}
}
