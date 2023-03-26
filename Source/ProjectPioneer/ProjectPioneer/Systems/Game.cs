namespace ProjectPioneer.Systems
{
	public class Game : IGame
	{
		private IHero _hero;
		public IHero Hero => _hero;

		private IInventory _inventory;
		public IInventory Inventory => _inventory;

		private readonly IShop _shop;
		public IShop Shop => _shop;

		private IQuestLog _questLog;
		public IQuestLog QuestLog => _questLog;

		private readonly IDataSource _dataSource;
		private readonly IHeroBuilder _heroBuilder;
		private readonly ISaveDataReader _saveDataReader;
		private readonly IDiceSystem _diceSystem;

		public Game(IDataSource dataSource, IHeroBuilder heroBuilder, IInventory inventory, IShop shop, IQuestLog questLog, ISaveDataReader saveDataReader, IDiceSystem diceSystem)
		{
			_dataSource = dataSource;
			_heroBuilder = heroBuilder;

			_inventory = inventory;
			_shop = shop;

			_questLog = questLog;
			_saveDataReader = saveDataReader;
			_diceSystem = diceSystem;
		}

		#region Hero
		public void SetUpHero(string name, IJob job, IImplant implant)
		{
			_hero = _heroBuilder.CreateHero(name, job, implant);
		}

		public IEnumerable<IJob> GetAllJobs()
		{
			return _dataSource.GetAllJobs();
		}

		public IEnumerable<IImplant> GetAllImplants()
		{
			return _dataSource.GetAllImplants();
		}

		public void AddExp(int exp)
		{
			_hero.AddExp(exp);
		}

		public int GetRequiredExp()
		{
			return _hero.GetRequiredExp();
		}

		public void LevelUp()
		{
			_hero.LevelUp();
		}

		public bool CanLevelUp()
		{
			return _hero.Exp >= GetRequiredExp();
		}

		public IEquipment GetEquippedWeapon()
		{
			return _hero.EquippedWeapon;
		}

		public IEquipment GetEquippedArmor()
		{
			return _hero.EquippedArmor;
		}

		public IEquipment GetEquippedAura()
		{
			return _hero.EquippedAura;
		}
		#endregion

		#region Inventory
		public IEnumerable<IEquipment> GetAllPossibleEquipment(int minlevel = 0, int maxLevel = 999)
		{
			return _dataSource.GetAllEquipment(minlevel, maxLevel);
		}

		public int GetCredits()
		{
			return Inventory.Credits;
		}

		public void AddCredits(int credits)
		{
			Inventory.AddCredits(credits);
		}

		public void RemoveCredits(int credits)
		{
			Inventory.RemoveCredits(credits);
		}

		public IEnumerable<IEquipment> GetInventory()
		{
			return Inventory.HeroInventory;
		}

		public void SellEquipment(IEquipment equipment)
		{
			Inventory.SellEquipment(equipment);
		}

		public bool CanEquip(IEquipment equipment)
		{
			return Inventory.CanEquip(equipment, Hero);
		}

		public void AddEquipment(IEquipment equipment)
		{
			Inventory.AddEquipment(equipment);
		}

		public void SortEquipment()
		{
			Inventory.SortEquipment();
		}

		public void EquipEquipment(IEquipment equipment, IHero hero)
		{
			Inventory.EquipEquipment(equipment, hero);
		}
		#endregion

		#region Shop
		public IEnumerable<IEquipment> GetShopInventory(int level)
		{
			return _shop.GetShopInventory(level);
		}

		public bool CanHeroAffordEquipment(IEquipment equipment, IInventory inventory)
		{
			return _shop.CanHeroAffordEquipment(equipment, inventory);
		}

		public void BuyEquipmentAndAddToInventory(IEquipment equipment, IInventory inventory)
		{
			_shop.BuyEquipmentAndAddToInventory(equipment, inventory);
		}
		#endregion

		#region Quest
		public IEnumerable<IQuest> GetAllQuests()
		{
			return _dataSource.GetAllQuests();
		}

		public void CompleteQuest(IQuest quest)
		{
			QuestLog.CompleteQuest(quest);
		}

		public ISet<int> GetCompletedQuests()
		{
			return QuestLog.CompletedQuests;
		}

		public void RewardHeroForQuest(IQuest quest)
		{
			AddCredits(quest.GetCreditsReward());
			AddExp(quest.GetExpReward());
			quest.GetEquipmentReward().ToList().ForEach(_ => AddEquipment(_));
		}
		#endregion

		#region Data
		public string SaveData()
		{
			var saveData = new SaveData()
			{
				Hero = _hero,
				Inventory = _inventory,
				QuestLog = QuestLog,
			};

			return _saveDataReader.GetStringFromSaveData(saveData);
		}

		public void LoadSavedData(string saveDataString)
		{
			var saveData = _saveDataReader.GetSaveDataFromString(saveDataString);
			_hero = saveData.Hero;
			_inventory = saveData.Inventory;
			_questLog = saveData.QuestLog;
		}
		#endregion

		#region System
		public int GetDiceRoll(int min, int max)
		{
			return _diceSystem.GetDiceRoll(min, max);
		}
		#endregion
	}
}
