using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Adventure;
using ProjectPioneer.Systems.Character;
using ProjectPioneer.Systems.Equipment;

namespace ProjectPioneer.Systems.Data
{
	public class SaveData
	{
		public IHero Hero { get; set; }
		public IInventory Inventory { get; set; }
		public IQuestLog QuestLog { get; set; }

		public SerializeableSaveData ConvertToSerializeableSaveData()
		{
			SerializeableSaveData data = new()
			{
				Name = Hero.Name,
				Exp = Hero.Exp,
				JobID = Hero.Job.ID,
				ImplantID = Hero.Implant.ID,
				EquippedWeaponID = Hero.EquippedWeapon.ID,
				EquippedArmorID = Hero.EquippedArmor.ID,
				EquippedAuraID = Hero.EquippedAura.ID,
				Stats = Hero.Stats,

				Credits = Inventory.Credits,
				HeroInventoryIDs = Inventory.HeroInventory.Select(_=>_.ID).ToList(),

				CompletedQuests = QuestLog.CompletedQuests
			};

			return data;
		}
	}
}
