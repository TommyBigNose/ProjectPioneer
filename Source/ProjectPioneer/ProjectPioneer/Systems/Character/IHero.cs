using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Equipment;
using ProjectPioneer.Systems.Statistics;

namespace ProjectPioneer.Systems.Character
{
	public interface IHero: ICalculableStats
	{
		string Name { get; }
		IJob Job { get; }
		IImplant Implant { get; }
		IEquipment EquippedWeapon { get; }
		IEquipment EquippedArmor { get; }
		IEquipment EquippedAura { get; }
		void LevelUp();
		bool CanEquipWeapon(IEquipment weapon);
		IEquipment EquipWeaponAndReturnOldWeapon(IEquipment weapon);
		IEquipment EquipArmorAndReturnOldArmor(IEquipment armor);
		IEquipment EquipAuraAndReturnOldAura(IEquipment aura);
	}
}
