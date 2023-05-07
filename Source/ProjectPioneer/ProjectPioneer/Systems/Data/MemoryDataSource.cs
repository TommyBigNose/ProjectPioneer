﻿namespace ProjectPioneer.Systems.Data
{
	public class MemoryDataSource : IDataSource
	{
		// TODO: Load collections into these and leverage them for speed and ease of use later?
		// private List<IJob> _allJobs;
		// private List<IImplant> _allImplants;
		// private List<IEquipment> _allEquipment;
		// private List<QuestInfo> _allQuestInfos;
		// private List<IQuest> _allQuests;

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
				new Weapon(104, "Pallasch", "A single edged energy blade designed by a local energy smith.  Support family owned businesses.", EquipmentType.Blade, new Stats()
				{
					Level= 3,
					PhysicalAttack = 6,
					PhysicalDefense = 0,
					MagicalAttack = 0,
					MagicalDefense = 0,
					Speed = 0,
					FireAttack = 0,
					FireDefense = 0,
					IceAttack = 0,
					IceDefense = 0,
					LightningAttack = 0,
					LightningDefense = 5,
					EarthAttack = 0,
					EarthDefense = 0,
				}),
				new Weapon(105, "Blaster Rifle", "The CEO's kid named this one.  It's alright.", EquipmentType.Gun, new Stats()
				{
					Level= 3,
					PhysicalAttack = 4,
					PhysicalDefense = 0,
					MagicalAttack = 0,
					MagicalDefense = 0,
					Speed = 4,
					FireAttack = 3,
					FireDefense = 0,
					IceAttack = 0,
					IceDefense = 0,
					LightningAttack = 0,
					LightningDefense = 0,
					EarthAttack = 0,
					EarthDefense = 0,
				}),
				new Weapon(106, "Hocus Wand", "Researchers still don't know how it works.  They spent dozens of minutes looking into it.", EquipmentType.Staff, new Stats()
				{
					Level= 3,
					PhysicalAttack = 0,
					PhysicalDefense = 0,
					MagicalAttack = 6,
					MagicalDefense = 0,
					Speed = 0,
					FireAttack = 0,
					FireDefense = 0,
					IceAttack = 0,
					IceDefense = 0,
					LightningAttack = 0,
					LightningDefense = 0,
					EarthAttack = 0,
					EarthDefense = 5,
				}),
				new Weapon(107, "Shiny Claymore", "Just a really big sword adorned with some shiny (but useless) jewels.", EquipmentType.Blade, new Stats()
				{
					Level= 6,
					PhysicalAttack = 12,
					PhysicalDefense = 2,
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
					EarthDefense = 5,
				}),
				new Weapon(108, "Portable Repeater Rifle", "Someone tried to make a portable version of a Scout class ships energy guns.", EquipmentType.Gun, new Stats()
				{
					Level= 6,
					PhysicalAttack = 6,
					PhysicalDefense = 0,
					MagicalAttack = 0,
					MagicalDefense = 0,
					Speed = 8,
					FireAttack = 0,
					FireDefense = 0,
					IceAttack = 0,
					IceDefense = 0,
					LightningAttack = 5,
					LightningDefense = 0,
					EarthAttack = 0,
					EarthDefense = 0,
				}),
				new Weapon(109, "Giant Gilded Baton", "The designer didn't care for portability and just wanted raw magical power!", EquipmentType.Staff, new Stats()
				{
					Level= 6,
					PhysicalAttack = 0,
					PhysicalDefense = 0,
					MagicalAttack = 10,
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
				new Weapon(110, "Flame Bardiche", "An advanced polearm that ignites targets.  Designed by a madman.", EquipmentType.Blade, new Stats()
				{
					Level= 9,
					PhysicalAttack = 18,
					PhysicalDefense = 0,
					MagicalAttack = 0,
					MagicalDefense = 0,
					Speed = 2,
					FireAttack = 25,
					FireDefense = 0,
					IceAttack = 0,
					IceDefense = 0,
					LightningAttack = 0,
					LightningDefense = 0,
					EarthAttack = 0,
					EarthDefense = 0,
				}),
				new Weapon(111, "Charged Railgun", "Not just a rail gun.  This charges its projectiles with electricity for extra power.", EquipmentType.Gun, new Stats()
				{
					Level= 9,
					PhysicalAttack = 7,
					PhysicalDefense = 0,
					MagicalAttack = 0,
					MagicalDefense = 0,
					Speed = 13,
					FireAttack = 0,
					FireDefense = 0,
					IceAttack = 0,
					IceDefense = 0,
					LightningAttack = 25,
					LightningDefense = 0,
					EarthAttack = 0,
					EarthDefense = 0,
				}),
				new Weapon(112, "Blizzard Scepter", "AN ice imbued scepter made in a bygone era.", EquipmentType.Staff, new Stats()
				{
					Level= 9,
					PhysicalAttack = 0,
					PhysicalDefense = 0,
					MagicalAttack = 15,
					MagicalDefense = 5,
					Speed = 0,
					FireAttack = 0,
					FireDefense = 0,
					IceAttack = 25,
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
				new Armor(302, "Frame", "Simple mass produced armor with a focus on resisting the elements", EquipmentType.Armor, new Stats()
				{
					Level= 2,
					PhysicalAttack = 0,
					PhysicalDefense = 2,
					MagicalAttack = 0,
					MagicalDefense = 3,
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
				new Armor(303, "Soul Frame", "This armor gives off some good vibes.", EquipmentType.Armor, new Stats()
				{
					Level= 5,
					PhysicalAttack = 0,
					PhysicalDefense = 13,
					MagicalAttack = 0,
					MagicalDefense = 13,
					Speed = 5,
					FireAttack = 0,
					FireDefense = 3,
					IceAttack = 0,
					IceDefense = 3,
					LightningAttack = 0,
					LightningDefense = 3,
					EarthAttack = 0,
					EarthDefense = 3,
				}),
				new Armor(304, "Elemental Padding", "Wards off the elements, but doesn't help physically much.", EquipmentType.Armor, new Stats()
				{
					Level= 7,
					PhysicalAttack = 0,
					PhysicalDefense = 3,
					MagicalAttack = 0,
					MagicalDefense = 3,
					Speed = 1,
					FireAttack = 0,
					FireDefense = 15,
					IceAttack = 0,
					IceDefense = 15,
					LightningAttack = 0,
					LightningDefense = 15,
					EarthAttack = 0,
					EarthDefense = 15,
				}),
				new Armor(305, "General Armor", "Your general purpose, all encompassing, armor!  Won't let you down, but it also won't surprise you.", EquipmentType.Armor, new Stats()
				{
					Level= 9,
					PhysicalAttack = 0,
					PhysicalDefense = 20,
					MagicalAttack = 0,
					MagicalDefense = 20,
					Speed = 0,
					FireAttack = 0,
					FireDefense = 10,
					IceAttack = 0,
					IceDefense = 10,
					LightningAttack = 0,
					LightningDefense = 10,
					EarthAttack = 0,
					EarthDefense = 10,
				}),
				new Armor(320, "Dragon's Skin", "Wield the skin of a dragon.  High elemental resistance", EquipmentType.Armor, new Stats()
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
				new Aura(502, "Shield", "Aura designed to replicate a physical barrier.  It's alright", EquipmentType.Aura,new Stats()
				{
					Level= 2,
					PhysicalAttack = 0,
					PhysicalDefense = 3,
					MagicalAttack = 0,
					MagicalDefense = 1,
					Speed = 0,
					FireAttack = 0,
					FireDefense = 1,
					IceAttack = 0,
					IceDefense = 1,
					LightningAttack = 0,
					LightningDefense = 1,
					EarthAttack = 0,
					EarthDefense = 1,
				}),
				new Aura(503, "Giga Shield", "Just a really think energy layer that surrounds you.", EquipmentType.Aura,new Stats()
				{
					Level= 4,
					PhysicalAttack = 0,
					PhysicalDefense = 6,
					MagicalAttack = 0,
					MagicalDefense = 6,
					Speed = 0,
					FireAttack = 0,
					FireDefense = 3,
					IceAttack = 0,
					IceDefense = 3,
					LightningAttack = 0,
					LightningDefense = 3,
					EarthAttack = 0,
					EarthDefense = 3,
				}),
				new Aura(504, "Force Barrier", "Doesn't just block, it pushes back!", EquipmentType.Aura,new Stats()
				{
					Level= 6,
					PhysicalAttack = 1,
					PhysicalDefense = 7,
					MagicalAttack = 1,
					MagicalDefense = 7,
					Speed = 0,
					FireAttack = 1,
					FireDefense = 3,
					IceAttack = 1,
					IceDefense = 3,
					LightningAttack = 1,
					LightningDefense = 3,
					EarthAttack = 1,
					EarthDefense = 3,
				}),
				new Aura(505, "General Barrier", "Your general purpose, all encompassing, barrier!  Won't let you down, but it also won't surprise you.", EquipmentType.Aura,new Stats()
				{
					Level= 8,
					PhysicalAttack = 0,
					PhysicalDefense = 10,
					MagicalAttack = 0,
					MagicalDefense = 10,
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
				new Aura(520, "Dragon's Aura", "Wield the spirit of a dragon.  High elemental resistance", EquipmentType.Aura,new Stats()
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

			if (minlevel == 0)
			{
				equipment.Add(GetDefaultWeapon());
				equipment.Add(GetDefaultArmor());
				equipment.Add(GetDefaultAura());
			}

			equipment.AddRange(GetAllWeapons().ToList().FindAll(_ => _.Stats.Level >= minlevel && _.Stats.Level <= maxLevel));
			equipment.AddRange(GetAllArmors().ToList().FindAll(_ => _.Stats.Level >= minlevel && _.Stats.Level <= maxLevel));
			equipment.AddRange(GetAllAuras().ToList().FindAll(_ => _.Stats.Level >= minlevel && _.Stats.Level <= maxLevel));

			return equipment;
		}

		public IEquipment GetEquipmentByID(int id)
		{
			return GetAllEquipment().First(_ => _.ID == id);
		}

		public IEnumerable<IEquipment> GetEquipmentByIDs(List<int> ids)
		{
			return GetAllEquipment().Where(_ => ids.Contains(_.ID));
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
					StatTypeMultiplierRatio = 2.0f,
					StatTypeMultipliers = new List<StatType>()
					{
						StatType.PhysicalAttack
					},
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
					NormalLoot = GetAllWeapons().Where(_=>_.Stats.Level <= 2),
					RareLoot = GetAllAuras().First(_ => _.Stats.Level >= 20)
				},
				new QuestInfo()
				{
					ID = 2,
					Name = "Forest - Part 2",
					Description = "Day turns to night, or is that the shade from the trees playing tricks on you?  A large warehouse stands at the end of the path, where you hear the cry of a large creature.",
					QuestLengthInSeconds = 70,
					ChanceForNormalLoot = 600,
					ChanceForRareLoot = 50,
					TotalChancesForLoot = 2,
					StatTypeMultiplierRatio = 2.0f,
					StatTypeMultipliers = new List<StatType>()
					{
						StatType.FireAttack
					},
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
					NormalLoot = GetAllWeapons().Where(_=>_.Stats.Level <= 2),
					RareLoot = GetAllArmors().First(_ => _.Stats.Level >= 20)
				},
				new QuestInfo()
				{
					ID = 3,
					Name = "Forest - Dragon",
					Description = "To no one's surprise... A fire dragon!",
					QuestLengthInSeconds = 80,
					ChanceForNormalLoot = 600,
					ChanceForRareLoot = 50,
					TotalChancesForLoot = 2,
					StatTypeMultiplierRatio = 2.0f,
					StatTypeMultipliers = new List<StatType>()
					{
						StatType.IceAttack
					},
					Stats = new Stats()
					{
						Level = 4,
						PhysicalAttack = 10,
						PhysicalDefense = 10,
						MagicalAttack = 10,
						MagicalDefense = 10,
						Speed = 7,
						FireAttack = 50,
						FireDefense = 50,
						IceAttack = 0,
						IceDefense = 0,
						LightningAttack = 0,
						LightningDefense = 0,
						EarthAttack = 10,
						EarthDefense = 10,
					},
					NormalLoot = GetAllWeapons().Where(_=>_.Stats.Level <= 4),
					RareLoot = GetAllAuras().First(_ => _.Stats.Level >= 20)
				},
				new QuestInfo()
				{
					ID = 4,
					Name = "Caves - Part 1",
					Description = "Oh yay, caves with magma",
					QuestLengthInSeconds = 120,
					ChanceForNormalLoot = 600,
					ChanceForRareLoot = 50,
					TotalChancesForLoot = 4,
					StatTypeMultiplierRatio = 2.0f,
					StatTypeMultipliers = new List<StatType>()
					{
						StatType.FireDefense, StatType.EarthAttack
					},
					Stats = new Stats()
					{
						Level = 6,
						PhysicalAttack = 15,
						PhysicalDefense = 6,
						MagicalAttack = 12,
						MagicalDefense = 8,
						Speed = 5,
						FireAttack = 15,
						FireDefense = 15,
						IceAttack = 0,
						IceDefense = 0,
						LightningAttack = 0,
						LightningDefense = 0,
						EarthAttack = 10,
						EarthDefense = 10,
					},
					NormalLoot = GetAllWeapons().Where(_=>_.Stats.Level <= 6),
					RareLoot = GetAllArmors().First(_ => _.Stats.Level >= 20)
				},
				new QuestInfo()
				{
					ID = 5,
					Name = "Caves - Part 2",
					Description = "A cool breeze permeates the damp air.  No more magma, but scarier wildlife appears from the streams and flowers.",
					QuestLengthInSeconds = 130,
					ChanceForNormalLoot = 500,
					ChanceForRareLoot = 50,
					TotalChancesForLoot = 5,
					StatTypeMultiplierRatio = 2.0f,
					StatTypeMultipliers = new List<StatType>()
					{
						StatType.Speed, StatType.IceDefense
					},
					Stats = new Stats()
					{
						Level = 8,
						PhysicalAttack = 17,
						PhysicalDefense = 10,
						MagicalAttack = 12,
						MagicalDefense = 10,
						Speed = 6,
						FireAttack = 15,
						FireDefense = 15,
						IceAttack = 0,
						IceDefense = 0,
						LightningAttack = 0,
						LightningDefense = 0,
						EarthAttack = 10,
						EarthDefense = 10,
					},
					NormalLoot = GetAllWeapons().Where(_=>_.Stats.Level <= 8),
					RareLoot = GetAllAuras().First(_ => _.Stats.Level >= 20)
				},
				new QuestInfo()
				{
					ID = 6,
					Name = "Caves - Part 3",
					Description = "Deep within the final layer of the caves, you see both wretched creatures and man-made machines.",
					QuestLengthInSeconds = 160,
					ChanceForNormalLoot = 550,
					ChanceForRareLoot = 100,
					TotalChancesForLoot = 5,
					StatTypeMultiplierRatio = 2.0f,
					StatTypeMultipliers = new List<StatType>()
					{
						StatType.LightningAttack
					},
					Stats = new Stats()
					{
						Level = 10,
						PhysicalAttack = 20,
						PhysicalDefense = 20,
						MagicalAttack = 13,
						MagicalDefense = 13,
						Speed = 7,
						FireAttack = 0,
						FireDefense = 5,
						IceAttack = 0,
						IceDefense = 5,
						LightningAttack = 25,
						LightningDefense = 25,
						EarthAttack = 5,
						EarthDefense = 10,
					},
					NormalLoot = GetAllWeapons().Where(_=>_.Stats.Level <= 10),
					RareLoot = GetAllAuras().First(_ => _.Stats.Level >= 12)
				},
				new QuestInfo()
				{
					ID = 7,
					Name = "Caves - Mutated Worm",
					Description = "A creature once controlled to dig out quarries for the settlement, is now on a rampage.",
					QuestLengthInSeconds = 200,
					ChanceForNormalLoot = 550,
					ChanceForRareLoot = 150,
					TotalChancesForLoot = 3,
					StatTypeMultiplierRatio = 2.0f,
					StatTypeMultipliers = new List<StatType>()
					{
						StatType.PhysicalDefense, StatType.FireAttack, StatType.EarthDefense 
					},
					Stats = new Stats()
					{
						Level = 12,
						PhysicalAttack = 30,
						PhysicalDefense = 23,
						MagicalAttack = 20,
						MagicalDefense = 18,
						Speed = 12,
						FireAttack = 0,
						FireDefense = 5,
						IceAttack = 0,
						IceDefense = 15,
						LightningAttack = 0,
						LightningDefense = 15,
						EarthAttack = 35,
						EarthDefense = 35,
					},
					NormalLoot = GetAllWeapons().Where(_=>_.Stats.Level <= 12),
					RareLoot = GetAllArmors().First(_ => _.Stats.Level >= 12)
				},
				new QuestInfo()
				{
					ID = 8,
					Name = "Mines - Part 1",
					Description = "A mining facility and factory in one, producing machines that no longer are on their original programming.",
					QuestLengthInSeconds = 220,
					ChanceForNormalLoot = 600,
					ChanceForRareLoot = 50,
					TotalChancesForLoot = 3,
					StatTypeMultiplierRatio = 2.0f,
					StatTypeMultipliers = new List<StatType>()
					{
						StatType.LightningAttack, StatType.MagicalAttack 
					},
					Stats = new Stats()
					{
						Level = 14,
						PhysicalAttack = 35,
						PhysicalDefense = 35,
						MagicalAttack = 15,
						MagicalDefense = 15,
						Speed = 25,
						FireAttack = 15,
						FireDefense = 15,
						IceAttack = 0,
						IceDefense = 5,
						LightningAttack = 0,
						LightningDefense = 0,
						EarthAttack = 0,
						EarthDefense = 0,
					},
					NormalLoot = GetAllWeapons().Where(_=>_.Stats.Level <= 12),
					RareLoot = GetAllArmors().First(_ => _.Stats.Level >= 12)
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
