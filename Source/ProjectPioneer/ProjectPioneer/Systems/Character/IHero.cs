using ProjectPioneer.Systems.Equipment;
using ProjectPioneer.Systems.Statistics;

namespace ProjectPioneer.Systems.Character
{
	public interface IHero : ICalculableStats
	{
		string Name { get; }
		int Exp { get; }
		IJob Job { get; }
		IImplant Implant { get; }
		IEquipment EquippedWeapon { get; }
		IEquipment EquippedArmor { get; }
		IEquipment EquippedAura { get; }
		void AddExp(int exp);
		int GetRequiredExp();
		void LevelUp();
		bool CanLevelUp();
		bool CanEquip(IEquipment equipment);
		IEquipment EquipWeaponAndReturnOldWeapon(IEquipment weapon);
		IEquipment EquipArmorAndReturnOldArmor(IEquipment armor);
		IEquipment EquipAuraAndReturnOldAura(IEquipment aura);
	}
}
