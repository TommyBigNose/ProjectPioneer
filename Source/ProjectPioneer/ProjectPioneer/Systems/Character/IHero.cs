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
		IWeapon EquippedWeapon { get; }
		//IArmor EquippedArmor { get; }
		//IAura EquippedAura { get; }
		void LevelUp();
		bool CanEquipWeapon(IWeapon weapon);
		IWeapon EquipWeaponAndReturnOldWeapon(IWeapon weapon);
		//void EquipArmor(IArmor weapon);
		//void EquipAura(IAura weapon);
	}
}
