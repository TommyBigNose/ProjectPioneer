using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems;
using ProjectPioneer.Systems.Adventure;
using ProjectPioneer.Systems.Character;
using ProjectPioneer.Systems.Data;
using ProjectPioneer.Systems.Dice;
using ProjectPioneer.Systems.Equipment;
using ProjectPioneer.Systems.Statistics;

namespace ProjectPioneer.Tests.Systems
{
	[TestFixture]
	public class GameTests
	{
		private string _FullFilePath = Path.Combine(Directory.GetCurrentDirectory(), "ProjectPioneerSaveData.json");

		private IDataSource _dataSource;
		private IHeroBuilder _heroBuilder;
		private IInventory _inventory;
		private IShop _shop;
		private IQuestLog _questLog;
		private ISaveDataReader _saveDataReader;
		private IFileSystem _fileSystem;
		private IDiceSystem _diceSystem;

		private IGame _sut;

		[SetUp]
		public void SetUp()
		{
			_dataSource = new MemoryDataSource();
			_heroBuilder = new HeroBuilder(_dataSource);
			_inventory = new Inventory();
			_shop = new Shop(_dataSource);
			_questLog = new QuestLog();
			_saveDataReader = new JsonSaveDataReader(_dataSource);
			_fileSystem = new LocalFileSystem(_saveDataReader);
            _diceSystem = new DiceSystem();

			_sut = new Game(_dataSource, _heroBuilder, _inventory, _shop, _questLog, _fileSystem, _diceSystem);
		}

		[TearDown]
		public void TearDown()
		{
			if (File.Exists(_FullFilePath))
			{
				File.Delete(_FullFilePath);
			}
		}

        [TestCase(0, 100)]
        [TestCase(50, 100)]
        public void Should_GetExp_When_Prompted(int initialExp, int addedExp)
        {
            // Arrange
            IJob job = new Job(999, "TestJob", "Desc", new List<EquipmentType>() { EquipmentType.None }, new Stats());
            IImplant implant = new Implant(999, "TestImplant", "Desc", new Stats());
            _sut.SetUpHero("TestHero", job, implant);

            _sut.AddExp(initialExp);

            // Act
            _sut.AddExp(addedExp);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(_sut.Hero.Exp, Is.EqualTo(initialExp + addedExp), "Hero did not add exp as expected");
            });
        }

        [Test]
        public void Should_GetRequiredExpIsBasedOnlevel_When_Prompted()
        {
            // Arrange
            IJob job = new Job(999, "TestJob", "Desc", new List<EquipmentType>() { EquipmentType.None }, new Stats());
            IImplant implant = new Implant(999, "TestImplant", "Desc", new Stats());
            _sut.SetUpHero("TestHero", job, implant);

            _sut.AddExp(10000);
            int initialRequiredExp = _sut.GetRequiredExp();

            // Act
            _sut.Hero.Stats.Level++;
            int finalRequiredExp = _sut.GetRequiredExp();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(finalRequiredExp, Is.GreaterThan(initialRequiredExp), "Hero did increase in required exp as expected");
            });
        }

        [TestCase(1, "Vanguard", "Reinforced Skin")]
        [TestCase(5, "Vanguard", "Reinforced Skin")]
        [TestCase(1, "Ranger", "Reinforced Joints")]
        [TestCase(5, "Ranger", "Reinforced Joints")]
        [TestCase(1, "Technician", "Focus Injector")]
        [TestCase(5, "Technician", "Focus Injector")]
        public void Should_HaveUpgradedStats_When_LeveledUp(int levelUpCount, string jobName, string implantName)
        {
            // Arrange
            IJob job = _dataSource.GetAllJobs().First(_ => _.Name.Equals(jobName));
            IImplant implant = _dataSource.GetAllImplants().First(_ => _.Name.Equals(implantName));
            _sut.SetUpHero("TestHero", job, implant);
			_sut.AddExp(10000);
			

            Stats initialStats = new Stats(_sut.Hero.Stats);

            // Act
            for (int i = 0; i < levelUpCount; i++)
            {
                _sut.LevelUp();
            }
            Stats resultingStats = new Stats(_sut.Hero.Stats);
            int requiredExp = _sut.GetRequiredExp();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(_sut.Hero.Exp, Is.LessThan(10000), "Hero current exp did not reduce upon leveling");
                Assert.That(requiredExp, Is.EqualTo(_sut.Hero.Stats.Level * Constants.HeroLevelExpScaling), "Hero required exp did not increase upon leveling");
                Assert.That(resultingStats.Level, Is.EqualTo(initialStats.Level + levelUpCount), "Hero did not upgrade Level");

                Assert.That(resultingStats.PhysicalAttack,
                    Is.EqualTo(initialStats.PhysicalAttack + levelUpCount + (job.Stats.PhysicalAttack * levelUpCount) + (implant.Stats.PhysicalAttack * levelUpCount)),
                    "Hero did not upgrade PhysicalAttack");

                Assert.That(resultingStats.PhysicalDefense,
                    Is.EqualTo(initialStats.PhysicalDefense + levelUpCount + (job.Stats.PhysicalDefense * levelUpCount) + (implant.Stats.PhysicalDefense * levelUpCount)),
                    "Hero did not upgrade PhysicalDefense");

                Assert.That(resultingStats.MagicalAttack,
                    Is.EqualTo(initialStats.MagicalAttack + levelUpCount + (job.Stats.MagicalAttack * levelUpCount) + (implant.Stats.MagicalAttack * levelUpCount)),
                    "Hero did not upgrade MagicalAttack");

                Assert.That(resultingStats.MagicalDefense,
                    Is.EqualTo(initialStats.MagicalDefense + levelUpCount + (job.Stats.MagicalDefense * levelUpCount) + (implant.Stats.MagicalDefense * levelUpCount)),
                    "Hero did not upgrade MagicalDefense");

                Assert.That(resultingStats.Speed,
                    Is.EqualTo(initialStats.Speed + levelUpCount + (job.Stats.Speed * levelUpCount) + (implant.Stats.Speed * levelUpCount)),
                    "Hero did not upgrade Speed");
            });
        }

        [TestCase("Vanguard", EquipmentType.Gun)]
        [TestCase("Ranger", EquipmentType.Staff)]
        [TestCase("Technician", EquipmentType.Blade)]
        public void Should_NotBeAbleToEquip_When_JobCannot(string jobName, EquipmentType weaponType)
        {
            // Arrange
             IJob job = _dataSource.GetAllJobs().First(_ => _.Name.Equals(jobName));
            IImplant implant = new Implant(999, "TestImplant", "Desc", new Stats());
            _sut.SetUpHero("TestHero", job, implant);

            IEquipment weapon = _dataSource.GetAllWeapons().First(_ => _.EquipmentType == weaponType);

            // Act
            var result = _sut.CanEquip(weapon);

            // Assert
            Assert.That(result, Is.False, "Hero was allowed to equip a weapon that its job didn't allow");
        }

        [Test]
		public void Should_SetUpHero_When_ValidInputsProvided()
		{
			// Arrange
			IJob job = new Job(999, "TestJob", "Desc", new List<EquipmentType>() { EquipmentType.None }, new Stats());
			IImplant implant = new Implant(999, "TestImplant", "Desc", new Stats());

			// Act
			_sut.SetUpHero("Test", job , implant);

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(_sut.Hero, Is.Not.Null, "Game did not properly setup a hero");
				Assert.That(_sut.Hero.Name, Is.EqualTo("Test"), "Game did not properly setup a hero's name");
				Assert.That(_sut.Hero.Job.Name, Is.EqualTo("TestJob"), "Game did not properly setup a hero's job");
				Assert.That(_sut.Hero.Implant.Name, Is.EqualTo("TestImplant"), "Game did not properly setup a hero's implant");
			});
		}

		[Test]
		public void Should_GetAllJobs_When_Prompted()
		{
			// Arrange
			// Act
			var result = _sut.GetAllJobs();

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(result.Count(), Is.GreaterThanOrEqualTo(3), "Game did not return enough Jobs");
			});
		}

		[Test]
		public void Should_GetAllImplants_When_Prompted()
		{
			// Arrange
			// Act
			var result = _sut.GetAllImplants();

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(result.Count(), Is.GreaterThanOrEqualTo(3), "Game did not return enough Implants");
			});
		}

		[Test]
		public void Should_GetDefaultEquipment_When_NewPlayer()
		{
			// Arrange
			IJob job = new Job(999, "TestJob", "Desc", new List<EquipmentType>() { EquipmentType.None }, new Stats());
			IImplant implant = new Implant(999, "TestImplant", "Desc", new Stats());

			// Act
			_sut.SetUpHero("Test", job, implant);
			var weapon = _sut.GetEquippedWeapon().Name;
			var armor = _sut.GetEquippedArmor().Name;
			var aura = _sut.GetEquippedAura().Name;

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(weapon, Is.EqualTo(_dataSource.GetDefaultWeapon().Name), "Game did not start Hero with default Weapon");
				Assert.That(armor, Is.EqualTo(_dataSource.GetDefaultArmor().Name), "Game did not start Hero with default Armor");
				Assert.That(aura, Is.EqualTo(_dataSource.GetDefaultAura().Name), "Game did not start Hero with default Aura");
			});
		}

        [TestCase(1, 5)]
        [TestCase(1, 20)]
        [TestCase(0, 999)]
        public void Should_GetAllEquipmentWithinLevelRange_When_Prompted(int minLevel, int maxLevel)
        {
            // Arrange
            // Act
            var result = _sut.GetAllPossibleEquipment(minLevel, maxLevel);
            var totalEquipment = _sut.GetAllPossibleEquipment().ToList().Count;
            bool isEquipmentOutOfRange = result.ToList().Exists(_ => _.Stats.Level < minLevel || _.Stats.Level > maxLevel);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result.Count, Is.LessThanOrEqualTo(totalEquipment), "Game returned too much equipment");
                Assert.That(result.Count, Is.GreaterThanOrEqualTo(0), "Game did not return enough equipment between range");
                Assert.That(isEquipmentOutOfRange, Is.False, "Game returned equipment out of specified range");
            });
        }

        [TestCase(0, 100)]
		[TestCase(100, 100)]
		public void Should_IncreaseCredits_When_Prompted(int initialCredits, int credits)
		{
			// Arrange
			_inventory.AddCredits(initialCredits);

			// Act
			_sut.AddCredits(credits);
			var finalCredits = _sut.GetCredits();

			// Assert
			Assert.That(finalCredits, Is.EqualTo(initialCredits+credits), "Game did not add credits");
		}

		[TestCase(0, 100)]
		[TestCase(100, 100)]
		public void Should_ReduceCredits_When_Prompted(int initialCredits, int credits)
		{
			// Arrange
			_inventory.AddCredits(initialCredits);

			// Act
			_sut.RemoveCredits(credits);
			var finalCredits = _sut.GetCredits();

			// Assert
			Assert.That(finalCredits, Is.EqualTo(Math.Max(initialCredits - credits, 0)), "Game did not remove credits");
		}

		[Test]
		public void Should_GetInventory_When_Prompted()
		{
			// Arrange
			_dataSource.GetAllEquipment().ToList().ForEach(_ => _sut.AddEquipment(_));

			// Act
			var result = _sut.GetInventory();

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(result, Is.Not.Null, "Game did not return Inventory");
				Assert.That(result.ToList().Count, Is.EqualTo(_dataSource.GetAllEquipment().ToList().Count), "Game did not return Inventory with the expected amount of Equipment");
			});
		}

		[Test]
		public void Should_SellEquipmentFromInventory_When_Prompted()
		{
			// Arrange
			var equipment = _dataSource.GetAllWeapons().First();
			_inventory.AddEquipment(equipment);

			// Act
			_sut.SellEquipment(equipment);
			int credits = _sut.GetCredits();

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(_sut.GetInventory().Contains(equipment), Is.False, "Game did not remove equipment after it got sold");
				Assert.That(credits, Is.EqualTo(equipment.GetSellableValue()), "Game did sell equipment at the right value");
			});
		}

		[Test]
		public void Should_CheckIfEquipmentCanBeEquipped_When_Prompted()
		{
			// Arrange
			var equipmentBlade = _dataSource.GetAllWeapons().First(_ => _.EquipmentType == EquipmentType.Blade);
			var equipmentGun = _dataSource.GetAllWeapons().First(_ => _.EquipmentType == EquipmentType.Gun);
			
			IJob job = new Job(999, "TestJob", "Desc", new List<EquipmentType>() { EquipmentType.None, EquipmentType.Gun }, new Stats());
			IImplant implant = new Implant(999, "TestImplant", "Desc", new Stats());
			_sut.SetUpHero("Test", job, implant);

			// Act
			var resultBlade = _sut.CanEquip(equipmentBlade);
			var resultGun = _sut.CanEquip(equipmentGun);

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(resultBlade, Is.False, "Game is allowing the player to equipment they cannot");
				Assert.That(resultGun, Is.True, "Game is not allowing the player to equipment they can");
			});
		}

		[Test]
		public void Should_GrowInventory_When_AddedEquipment()
		{
			// Arrange
			var equipmentBlade = _dataSource.GetAllWeapons().First(_ => _.EquipmentType == EquipmentType.Blade);
			var equipmentGun = _dataSource.GetAllWeapons().First(_ => _.EquipmentType == EquipmentType.Gun);

			// Act
			_sut.AddEquipment(equipmentBlade);
			_sut.AddEquipment(equipmentGun);

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(_sut.GetInventory().Count(), Is.EqualTo(2), "Game not adding the expected amount of equipment");
			});
		}


		[Test]
		public void Should_SortEquipment_When_Prompted()
		{
			// Arrange
			_dataSource.GetAllEquipment().ToList().ForEach(_ => _sut.AddEquipment(_));

			// Act
			_sut.SortEquipment();
			var firstEquipment = _dataSource.GetAllEquipment().First();
			var lastEquipment = _dataSource.GetAllEquipment().Last();

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(firstEquipment.EquipmentType, Is.EqualTo(EquipmentType.None), "Game did not sort None first as expected");
				Assert.That(lastEquipment.EquipmentType, Is.EqualTo(EquipmentType.Aura), "Game did not sort as expected");
			});
		}

		[Test]
		public void Should_EquipEquipmentOnHeroAndReturnsOldOneToInventory_When_Prompted()
		{
			// Arrange
			var equipmentBlade = _dataSource.GetAllWeapons().First(_ => _.EquipmentType == EquipmentType.Blade);
			
			IJob job = new Job(999, "TestJob", "Desc", new List<EquipmentType>() { EquipmentType.None, EquipmentType.Gun }, new Stats());
			IImplant implant = new Implant(999, "TestImplant", "Desc", new Stats());
			_sut.SetUpHero("Test", job, implant);
			var initialEquipment = _sut.GetEquippedWeapon();

			// Act
			_sut.EquipEquipment(equipmentBlade, _sut.Hero);
			var currentEquipment = _sut.GetEquippedWeapon();

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(currentEquipment, Is.EqualTo(equipmentBlade), "Game did equip the proper equipment on the hero");
				Assert.That(_sut.Inventory.HeroInventory.Contains(initialEquipment), Is.True, "Game did return old equipment to inventory");
			});
		}


		[TestCase(1)]
		[TestCase(20)]
		public void Should_GetShopInventoryInLevelRange_When_Prompted(int level)
		{
			// Arrange
			// Act
			var result = _sut.GetShopInventory(level);
			int maxLevel = result.Max(_ => _.Stats.Level);

			// Assert
			Assert.That(maxLevel, Is.LessThanOrEqualTo(level + 1), "Game's Shop invetory returned wrong equipment level range");
		}


		[TestCase(10000)]
		public void Should_AffordEquipment_When_InventoryHasEnoughCredits(int credits)
		{
			// Arrange
			_sut.AddCredits(credits);
			var equipmentBlade = _dataSource.GetAllWeapons().First(_ => _.EquipmentType == EquipmentType.Blade);

			// Act
			var result = _sut.CanHeroAffordEquipment(equipmentBlade, _inventory);

			// Assert
			Assert.That(result, Is.True, "Game said player could not afford some equipment when they had enough credits");
		}

		[TestCase(0)]
		[TestCase(5)]
		public void Should_NotBeAbleToAffordEquipment_When_InventoryIsBroke(int credits)
		{
			// Arrange
			_sut.AddCredits(credits);
			var equipmentBlade = _dataSource.GetAllWeapons().First(_ => _.EquipmentType == EquipmentType.Blade);

			// Act
			var result = _sut.CanHeroAffordEquipment(equipmentBlade, _inventory);

			// Assert
			Assert.That(result, Is.False, "Game said player could afford some equipment when they clearly did not");
		}

		[TestCase(1000)]
		public void Should_AddEquipmentToInventoryAndRemoveCredits_When_PlayerBuysEquipment(int credits)
		{
			// Arrange
			_sut.AddCredits(credits);
			IEquipment sellableWeapon = _dataSource.GetAllWeapons().First();

			// Act
			_sut.BuyEquipmentAndAddToInventory(sellableWeapon, _inventory);

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(_sut.GetInventory().Contains(sellableWeapon), Is.True, "Game's Shop did not add sold Weapon to Inventory");
				Assert.That(_sut.Inventory.Credits, Is.EqualTo(credits - sellableWeapon.GetPurchaseValue()), "Game's Shop did not remove credits from Inventory");
			});
		}


		[Test]
		public void Should_GetAllQuests_When_Prompted()
		{
			// Arrange
			int totalQuestCount = _dataSource.GetAllQuestInfos().Count();

			// Act
			var result = _sut.GetAllQuests();

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(result.Count(), Is.EqualTo(totalQuestCount), "Game did not return all quests");
			});
		}

		[Test]
		public void Should_GetAllCompletedQuests_When_GivenCompletedQuests()
		{
			// Arrange
			int totalQuestCount = _dataSource.GetAllQuestInfos().Count();
			var questToComplete1 = _sut.GetAllQuests().First();
			var questToComplete2 = _sut.GetAllQuests().Last();
			_sut.CompleteQuest(questToComplete1);
			_sut.CompleteQuest(questToComplete2);

			// Act
			var result = _sut.GetCompletedQuests();

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(result.Count(), Is.EqualTo(2), "Game did not return completed quests");
				Assert.That(result.Contains(questToComplete1.QuestInfo.ID), Is.True, "Game did not return expected completed quest 1");
				Assert.That(result.Contains(questToComplete2.QuestInfo.ID), Is.True, "Game did not return expected completed quest 2");
			});
		}

		[Test]
		public void Should_CreateASaveFile_When_SavingForTheFirstTime()
		{
			// Arrange
			_sut.SetUpHero("TestHeroName", _dataSource.GetAllJobs().First(), _dataSource.GetAllImplants().First());

			// Act
			_sut.SaveData();

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(File.Exists(_FullFilePath), Is.True, "Game did not create a save file");
			});
		}

		[Test]
		public void Should_OverwriteCurrentData_When_LoadingUpOlderData()
		{
			// Arrange
			_sut.SetUpHero("TestHeroName", _dataSource.GetAllJobs().First(), _dataSource.GetAllImplants().First());
			_sut.SaveData();
			_sut.SetUpHero("SecondHero", _dataSource.GetAllJobs().Last(), _dataSource.GetAllImplants().Last());
			IHero heroBeforeLoading = _sut.Hero;
			_sut.AddEquipment(_dataSource.GetAllWeapons().First());
			_sut.CompleteQuest(_dataSource.GetAllQuests().First());

			// Act
			_sut.LoadSavedData();

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(File.Exists(_FullFilePath), Is.True, "Game did not create a save file");
				Assert.That(_sut.Hero.Name, Is.Not.EqualTo(heroBeforeLoading.Name), "Game did not overwrite Hero");
				Assert.That(_sut.GetInventory().Count(), Is.EqualTo(0), "Game did not overwrite Inventory");
				Assert.That(_sut.GetCompletedQuests().Count(), Is.EqualTo(0), "Game did not overwrite QuestLog");
			});
		}

		[Test]
		public void Should_ThrowFileNotFoundException_When_LoadingWithNoFile()
		{
			// Arrange
			// Act
			// Assert
			Assert.Throws<FileNotFoundException>(() => _sut.LoadSavedData(), "Game did not throw an exception when attempting to load a file that isn't there");
		}

        [TestCaseSource(nameof(GetDiceSystemMinMaxesValid))]
        public void Should_GetRandomNumberFromDiceRoll_When_MinIsLessThanMax(int min, int max)
        {
            // Arrange
            // Act
            var result = _sut.GetDiceRoll(min, max);

            // Assert
            Assert.That(result, Is.InRange(min, max), "Dice roll was not within specified ranges.");
        }

        private static IEnumerable GetDiceSystemMinMaxesValid()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = i; j < 10; j++)
                {
                    yield return new object[] { i, j };
                }
            }
        }
    }
}
