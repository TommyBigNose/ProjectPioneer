using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Adventure;
using ProjectPioneer.Systems.Character;
using ProjectPioneer.Systems.Equipment;
using ProjectPioneer.Systems.Statistics;

namespace ProjectPioneer.Systems.Data
{
	public class MemoryDataSource : IDataSource
	{
		public IEnumerable<IJob> GetAllJobs()
		{
			var jobs = new List<IJob>()
			{
				new Job(1, "Vanguard", "Melee front line class",
				new List<EquipmentType>()
				{
					EquipmentType.None, EquipmentType.Blade, EquipmentType.Armor, EquipmentType.Aura
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
				new Job(2, "Ranger", "Long range combat class",
				new List<EquipmentType>()
				{
					EquipmentType.None, EquipmentType.Gun, EquipmentType.Armor, EquipmentType.Aura
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
				new Job(3, "Technician", "Magic focused class",
				new List<EquipmentType>()
				{
					EquipmentType.None, EquipmentType.Staff, EquipmentType.Armor, EquipmentType.Aura
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
				new Implant(1, "Reinforced Skin", "Enhanced skin for extra defenses all around", new Stats()
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
				new Implant(2, "Reinforced Joints", "Physical upgrades to help in harsh environments", new Stats()
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
				new Implant(3, "Focus Injector", "Enhanced mental state for raw offence", new Stats()
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

		public IEnumerable<IEquipment> GetAllWeapons()
		{
			var weapons = new List<IEquipment>()
			{
				new Weapon(101, "Energy Blade", "Mass produced energy blade for rookies", EquipmentType.Blade, new Stats()
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
				new Weapon(102, "Energy Pistol", "Mass produced energy pistol for rookies", EquipmentType.Gun, new Stats()
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
				new Weapon(103, "Energy Staff", "Mass produced energy staff for rookies", EquipmentType.Staff, new Stats()
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

		public IEnumerable<IEquipment> GetAllArmors()
		{
			var armors = new List<IEquipment>()
			{
				new Armor(301, "Leather Padding", "Mass produced armor for rookies", EquipmentType.Armor, new Stats()
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
				new Armor(302, "Dragon's Skin", "Wield the skin of a dragon.  High elemental resistance", EquipmentType.Armor, new Stats()
				{
					Level= 20,
					PhysicalAttack = 0,
					PhysicalDefense = 15,
					MagicalAttack = 0,
					MagicalDefense = 20,
					Speed = 0,
					FireAttack = 0,
					FireDefense = 25,
					IceAttack = 0,
					IceDefense = 25,
					LightningAttack = 0,
					LightningDefense = 25,
					EarthAttack = 0,
					EarthDefense = 25,
				}),
			};

			return armors;
		}

		public IEnumerable<IEquipment> GetAllAuras()
		{
			var auras = new List<IEquipment>()
			{
				new Aura(501, "Resistance Barrier", "Mass produced aura for rookies", EquipmentType.Aura,new Stats()
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
				new Aura(502, "Dragon's Aura", "Wield the spirit of a dragon.  High elemental resistance", EquipmentType.Aura,new Stats()
				{
					Level= 20,
					PhysicalAttack = 0,
					PhysicalDefense = 5,
					MagicalAttack = 0,
					MagicalDefense = 10,
					Speed = 0,
					FireAttack = 0,
					FireDefense = 40,
					IceAttack = 0,
					IceDefense = 40,
					LightningAttack = 0,
					LightningDefense = 40,
					EarthAttack = 0,
					EarthDefense = 40,
				}),
			};

			return auras;
		}

		public IEnumerable<IEquipment> GetAllEquipment(int minlevel = 0, int maxLevel = 999)
		{
			List<IEquipment> equipment = new List<IEquipment>();

			equipment.AddRange(GetAllWeapons().ToList().FindAll(_ => _.Stats.Level >= minlevel && _.Stats.Level <= maxLevel));
			equipment.AddRange(GetAllArmors().ToList().FindAll(_ => _.Stats.Level >= minlevel && _.Stats.Level <= maxLevel));
			equipment.AddRange(GetAllAuras().ToList().FindAll(_ => _.Stats.Level >= minlevel && _.Stats.Level <= maxLevel));

			return equipment;
		}

		public IEquipment GetDefaultWeapon()
		{
			return new Weapon(1, "Nothing", "Just your fists", EquipmentType.None, new Stats()
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

		public IEquipment GetDefaultArmor()
		{
			return new Armor(2, "Clothes", "Whatever you normally wear", EquipmentType.Armor, new Stats()
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

		public IEquipment GetDefaultAura()
		{
			return new Aura(3, "Basic", "Normal human aura", EquipmentType.Aura, new Stats()
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

		public IEnumerable<QuestInfo> GetAllQuestInfos()
		{
			var questInfos = new List<QuestInfo>()
			{
				new QuestInfo()
				{
					ID = 1,
					Name = "Forest - Part 1",
					Description = "Desolate buildings are all that remains of the colony's first city.  A seemingly friendly forest encapsulates the town.",
					QuestLengthInSeconds = 60,
					ChanceForNormalLoot = 600,
					ChanceForRareLoot = 50, 
					TotalChancesForLoot = 2,
					Stats = new Stats()
					{
						Level = 1,
						PhysicalAttack = 3,
						PhysicalDefense = 3,
						MagicalAttack = 3,
						MagicalDefense = 3,
						Speed = 2,
						FireAttack = 0,
						FireDefense = 0,
						IceAttack = 0,
						IceDefense = 5,
						LightningAttack = 0,
						LightningDefense = 5,
						EarthAttack = 5,
						EarthDefense = 20,
					},
					NormalLoot = GetAllWeapons(),
					RareLoot = GetAllAuras().First(_ => _.Stats.Level >= 20)
				},
				new QuestInfo()
				{
					ID = 2,
					Name = "Forest - Part 2",
					Description = "Day turns to night, or is that the shade from the trees playing tricks on you?  A large warehouse stands at the end of the path, where you hear the cry of a large creature.",
					QuestLengthInSeconds = 60,
					ChanceForNormalLoot = 600,
					ChanceForRareLoot = 50,
					TotalChancesForLoot = 2,
					Stats = new Stats()
					{
						Level = 2,
						PhysicalAttack = 5,
						PhysicalDefense = 5,
						MagicalAttack = 5,
						MagicalDefense = 5,
						Speed = 4,
						FireAttack = 0,
						FireDefense = 0,
						IceAttack = 0,
						IceDefense = 5,
						LightningAttack = 0,
						LightningDefense = 5,
						EarthAttack = 5,
						EarthDefense = 20,
					},
					NormalLoot = GetAllWeapons(),
					RareLoot = GetAllAuras().First(_ => _.Stats.Level >= 20)
				},
			};
			
			return questInfos;
		}

		public IEnumerable<IQuest> GetAllQuests()
		{
			List<IQuest> quests = new List<IQuest>();
			
			GetAllQuestInfos().ToList().ForEach(_ => quests.Add(new Quest(_)));

			return quests;
		}
	}
}
