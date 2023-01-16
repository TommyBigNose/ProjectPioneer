using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Equipment;
using ProjectPioneer.Systems.Statistics;

namespace ProjectPioneer.Systems
{
	public class Constants
	{
		public const int HeroLevelExpScaling = 150;

		public const int WeaponCostScaling = 100;
		public const int ArmorCostScaling = 120;
		public const int AuraCostScaling = 80;
		public const float EquipmentSellValueScaling = 0.5f;

		public const int QuestRewardCreditScaling = 50;
		public const int QuestRewardExpScaling = 50;
		public const int QuestMinimumLengthInSeconds = 10;
		public const int QuestProgressBarIncrementTickRateInMs = 100;

		public const string AttributeSeparator = "|||";
		public const string AttributeListSeparator = ",";

		public const string AttributeHeroName = "HeroName";
		public const string AttributeHeroExp = "HeroExp";
		public const string AttributeHeroJob = "HeroJob";
		public const string AttributeHeroImplant = "HeroImplant";
		public const string AttributeHeroWeapon = "HeroWeapon";
		public const string AttributeHeroArmor = "HeroArmor";
		public const string AttributeHeroAura = "HeroAura";
		public const string AttributeHeroStats = "HeroStats";

		public const string AttributeInventoryCredits = "InventoryCredits";
		public const string AttributeInventoryHerosInventory = "InventoryHerosInventory";

		public const string AttributeQuestLogCompletedQuests = "QuestLogCompletedQuests";
	}
}
