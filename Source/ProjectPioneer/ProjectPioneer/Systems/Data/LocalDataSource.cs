using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Character;
using ProjectPioneer.Systems.Equipment;
using ProjectPioneer.Systems.Statistics;

namespace ProjectPioneer.Systems.Data
{
	public class LocalDataSource : IDataSource
	{
		public IEnumerable<IJob> GetAllJobs()
		{
			var jobs = new List<IJob>()
			{
				new Job("Vanguard", "Melee front line class",
				new List<WeaponType>()
				{
					WeaponType.None, WeaponType.Blade
				},
				new Stats()
				{
					PhysicalAttack = 1,
					PhysicalDefense = 1,
					MagicalAttack = 0,
					MagicalDefense = 0,
					Speed = 0,
					FireAttack = 0,
					FireDefense = 0,
					IceAttack = 0,
					IceDefense = 0,
					LightningAttack = 0,
					LightningDefense = 0,
					EarthAttack = 5,
					EarthDefense = 5,
				}),
				new Job("Ranger", "Long range combat class",
				new List<WeaponType>()
				{
					WeaponType.None, WeaponType.Gun
				},
				new Stats()
				{
					PhysicalAttack = 0,
					PhysicalDefense = 0,
					MagicalAttack = 0,
					MagicalDefense = 0,
					Speed = 2,
					FireAttack = 0,
					FireDefense = 0,
					IceAttack = 0,
					IceDefense = 0,
					LightningAttack = 5,
					LightningDefense = 5,
					EarthAttack = 0,
					EarthDefense = 0,
				}),
				new Job("Technician", "Magic focused class",
				new List<WeaponType>()
				{
					WeaponType.None, WeaponType.Staff
				},
				new Stats()
				{
					PhysicalAttack = 0,
					PhysicalDefense = 0,
					MagicalAttack = 1,
					MagicalDefense = 1,
					Speed = 0,
					FireAttack = 0,
					FireDefense = 0,
					IceAttack = 5,
					IceDefense = 5,
					LightningAttack = 0,
					LightningDefense = 0,
					EarthAttack = 0,
					EarthDefense = 0,
				})
			};

			return jobs;
		}

		public IEnumerable<IImplant> GetAllImplants()
		{
			var implants = new List<IImplant>()
			{
				new Implant("Reinforced Skin", "Enhanced skin for extra defenses all around", new Stats()
				{
					PhysicalAttack = 0,
					PhysicalDefense = 1,
					MagicalAttack = 0,
					MagicalDefense = 1,
					Speed = 0,
					FireAttack = 0,
					FireDefense = 5,
					IceAttack = 0,
					IceDefense = 5,
					LightningAttack = 0,
					LightningDefense = 5,
					EarthAttack = 0,
					EarthDefense = 5,
				}),
				new Implant("Reinforced Joints", "Physical upgrades to help in harsh environments", new Stats()
				{
					PhysicalAttack = 1,
					PhysicalDefense = 0,
					MagicalAttack = 0,
					MagicalDefense = 0,
					Speed = 1,
					FireAttack = 0,
					FireDefense = 0,
					IceAttack = 0,
					IceDefense = 5,
					LightningAttack = 5,
					LightningDefense = 0,
					EarthAttack = 5,
					EarthDefense = 5,
				}),
				new Implant("Focus Injector", "Enhanced mental state for raw offence", new Stats()
				{
					PhysicalAttack = 0,
					PhysicalDefense = 0,
					MagicalAttack = 2,
					MagicalDefense = 0,
					Speed = 0,
					FireAttack = 5,
					FireDefense = 0,
					IceAttack = 5,
					IceDefense = 0,
					LightningAttack = 5,
					LightningDefense = 0,
					EarthAttack = 5,
					EarthDefense = 0,
				})
			};

			return implants;
		}

		public IEnumerable<IWeapon> GetAllWeapons()
		{
			var weapons = new List<IWeapon>()
			{
				new Weapon("Energy Blade", "Mass produced energy blade for rookies", WeaponType.Blade, new Stats()
				{
					Level= 1,
					PhysicalAttack = 2,
					PhysicalDefense = 1,
					MagicalAttack = 0,
					MagicalDefense = 0,
					Speed = 0,
					FireAttack = 0,
					FireDefense = 0,
					IceAttack = 0,
					IceDefense = 0,
					LightningAttack = 0,
					LightningDefense = 0,
					EarthAttack = 0,
					EarthDefense = 0,
				}),
				new Weapon("Energy Pistol", "Mass produced energy pistol for rookies", WeaponType.Gun, new Stats()
				{
					Level= 1,
					PhysicalAttack = 1,
					PhysicalDefense = 0,
					MagicalAttack = 0,
					MagicalDefense = 0,
					Speed = 2,
					FireAttack = 0,
					FireDefense = 0,
					IceAttack = 0,
					IceDefense = 0,
					LightningAttack = 0,
					LightningDefense = 0,
					EarthAttack = 0,
					EarthDefense = 0,
				}),
				new Weapon("Energy Staff", "Mass produced energy staff for rookies", WeaponType.Staff, new Stats()
				{
					Level= 1,
					PhysicalAttack = 0,
					PhysicalDefense = 0,
					MagicalAttack = 2,
					MagicalDefense = 1,
					Speed = 0,
					FireAttack = 0,
					FireDefense = 0,
					IceAttack = 0,
					IceDefense = 0,
					LightningAttack = 0,
					LightningDefense = 0,
					EarthAttack = 0,
					EarthDefense = 0,
				}),
			};

			return weapons;
		}

		public IEnumerable<IArmor> GetAllArmors()
		{
			var armors = new List<IArmor>()
			{
				new Armor("Leather Padding", "Mass produced armor for rookies", new Stats()
				{
					Level= 1,
					PhysicalAttack = 0,
					PhysicalDefense = 2,
					MagicalAttack = 0,
					MagicalDefense = 2,
					Speed = 0,
					FireAttack = 0,
					FireDefense = 0,
					IceAttack = 0,
					IceDefense = 5,
					LightningAttack = 0,
					LightningDefense = 0,
					EarthAttack = 0,
					EarthDefense = 0,
				}),
			};

			return armors;
		}

		public IEnumerable<IAura> GetAllAuras()
		{
			var auras = new List<IAura>()
			{
				new Aura("Resistance Barrier", "Mass produced aura for rookies", new Stats()
				{
					Level= 1,
					PhysicalAttack = 0,
					PhysicalDefense = 0,
					MagicalAttack = 0,
					MagicalDefense = 0,
					Speed = 0,
					FireAttack = 0,
					FireDefense = 2,
					IceAttack = 0,
					IceDefense = 2,
					LightningAttack = 0,
					LightningDefense = 2,
					EarthAttack = 0,
					EarthDefense = 2,
				}),
			};

			return auras;
		}

		public IWeapon GetDefaultWeapon()
		{
			return new Weapon("Nothing", "Just your fists", WeaponType.None, new Stats()
			{
				Level = 0,
				PhysicalAttack = 0,
				PhysicalDefense = 0,
				MagicalAttack = 0,
				MagicalDefense = 0,
				Speed = 0,
				FireAttack = 0,
				FireDefense = 0,
				IceAttack = 0,
				IceDefense = 0,
				LightningAttack = 0,
				LightningDefense = 0,
				EarthAttack = 0,
				EarthDefense = 0,
			});
		}

		public IArmor GetDefaultArmor()
		{
			return new Armor("Clothes", "Whatever you normally wear", new Stats()
			{
				Level = 0,
				PhysicalAttack = 0,
				PhysicalDefense = 0,
				MagicalAttack = 0,
				MagicalDefense = 0,
				Speed = 0,
				FireAttack = 0,
				FireDefense = 0,
				IceAttack = 0,
				IceDefense = 0,
				LightningAttack = 0,
				LightningDefense = 0,
				EarthAttack = 0,
				EarthDefense = 0,
			});
		}

		public IAura GetDefaultAura()
		{
			return new Aura("Basic", "Normal human aura", new Stats()
			{
				Level = 0,
				PhysicalAttack = 0,
				PhysicalDefense = 0,
				MagicalAttack = 0,
				MagicalDefense = 0,
				Speed = 0,
				FireAttack = 0,
				FireDefense = 0,
				IceAttack = 0,
				IceDefense = 0,
				LightningAttack = 0,
				LightningDefense = 0,
				EarthAttack = 0,
				EarthDefense = 0,
			});
		}
	}
}
