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
	}
}
