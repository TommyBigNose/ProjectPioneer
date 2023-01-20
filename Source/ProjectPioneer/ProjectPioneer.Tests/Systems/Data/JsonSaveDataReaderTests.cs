using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ProjectPioneer.Systems;
using ProjectPioneer.Systems.Adventure;
using ProjectPioneer.Systems.Character;
using ProjectPioneer.Systems.Data;
using ProjectPioneer.Systems.Equipment;
using ProjectPioneer.Systems.Statistics;

namespace ProjectPioneer.Tests.Systems.Data
{
	[TestFixture]
	public class JsonSaveDataReaderTests
	{
		private IDataSource _dataSource;
		private IHeroBuilder _heroBuilder;
		private IInventory _inventory;
		private IQuestLog _questLog;
		private SaveData _saveData;

		private ISaveDataReader _sut;

		[SetUp]
		public void SetUp()
		{
			_dataSource = new MemoryDataSource();
			_heroBuilder = new HeroBuilder(_dataSource);
			_inventory = new Inventory();
			_questLog = new QuestLog();
			_saveData = new SaveData()
			{
				Hero = _heroBuilder.CreateHero("", _dataSource.GetAllJobs().First(), _dataSource.GetAllImplants().First()),
				Inventory = _inventory,
				QuestLog = _questLog
			};

			_sut = new JsonSaveDataReader(_dataSource);
		}

		[TearDown]
		public void TearDown()
		{

		}

		[Test]
		public void Should_ReturnsHeroData_When_GivenNewHero()
		{
			// Arrange
			IJob job = new Job(999, "TestJob", "Desc", new List<EquipmentType>()
			{ EquipmentType.None, EquipmentType.Blade, EquipmentType.Armor, EquipmentType.Aura }, new Stats());

			IImplant implant = new Implant(1001, "TestImplant", "Desc", new Stats());
			IHero hero = _heroBuilder.CreateHero("TestHeroName", job, implant);

			_saveData.Hero = hero;

			// Act
			var result = _sut.GetStringFromSaveData(_saveData);

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(result, Does.Contain("\"Name\": \"TestHeroName\""), "JsonSaveDataReaderTests did not parse out Name");
				Assert.That(result, Does.Contain("\"Exp\": 0"), "JsonSaveDataReaderTests did not parse out Exp");
				Assert.That(result, Does.Contain("\"JobID\": 999"), "JsonSaveDataReaderTests did not parse out Job");
				Assert.That(result, Does.Contain("\"ImplantID\": 1001"), "JsonSaveDataReaderTests did not parse out Implant");
				Assert.That(result, Does.Contain("\"EquippedWeaponID\": 1"), "JsonSaveDataReaderTests did not parse out Weapon");
				Assert.That(result, Does.Contain("\"EquippedArmorID\": 2"), "JsonSaveDataReaderTests did not parse out Armor");
				Assert.That(result, Does.Contain("\"EquippedAuraID\": 3"), "JsonSaveDataReaderTests did not parse out Aura");
				Assert.That(result, Does.Contain("\"Level\": 1"), "JsonSaveDataReaderTests did not parse out Stats");
			});
		}

		[Test]
		public void Should_ReturnsInventoryData_When_GivenNewInventory()
		{
			// Arrange
			// Act
			var result = _sut.GetStringFromSaveData(_saveData);

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(result, Does.Contain("\"Credits\": 0"), "JsonSaveDataReaderTests did not parse out Credits");
				Assert.That(result, Does.Contain("\"HeroInventoryIDs\": []"), "JsonSaveDataReaderTests did not parse out Hero Inventory");
			});
		}

		[Test]
		public void Should_ReturnsInventoryData_When_GivenInventory()
		{
			// Arrange
			_dataSource.GetAllEquipment().ToList().ForEach(_ => _inventory.AddEquipment(_));
			_inventory.AddCredits(9999);

			// Act
			var result = _sut.GetStringFromSaveData(_saveData);

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(result, Does.Contain("\"Credits\": 9999"), "JsonSaveDataReaderTests did not parse out Credits");
				Assert.That(result, Does.Contain("HeroInventoryIDs\": [\r\n    1,"), "JsonSaveDataReaderTests did not parse out an empty Hero Inventory");
			});
		}

		[Test]
		public void Should_ReturnsQuestLogData_When_GivenNewQuestLog()
		{
			// Arrange
			// Act
			var result = _sut.GetStringFromSaveData(_saveData);

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(result, Does.Contain("\"CompletedQuests\": []"), "JsonSaveDataReaderTests did not parse out an empty set of Completed Quests");
			});
		}

		[Test]
		public void Should_ReturnsQuestLogData_When_GivenQuestLog()
		{
			// Arrange
			_dataSource.GetAllQuests().ToList().ForEach(_ => _questLog.CompleteQuest(_));

			// Act
			var result = _sut.GetStringFromSaveData(_saveData);

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(result, Does.Contain("\"CompletedQuests\": [\r\n    1,"), "JsonSaveDataReaderTests did not parse out Completed Quests");
			});
		}

		[Test]
		public void Should_ReturnsSaveData_When_GivenOlderSavedDataAsString()
		{
			// Arrange
			// Hero
			IHero hero = _heroBuilder.CreateHero("TestHeroName", _dataSource.GetAllJobs().First(), _dataSource.GetAllImplants().First());

			_saveData.Hero = hero;

			// Inventory
			_dataSource.GetAllEquipment().ToList().ForEach(_ => _inventory.AddEquipment(_));
			_inventory.AddCredits(9999);

			// QuestLog
			_dataSource.GetAllQuests().ToList().ForEach(_ => _questLog.CompleteQuest(_));

			string json = _sut.GetStringFromSaveData(_saveData);

			// Act
			var result = _sut.GetSaveDataFromString(json);

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(result.Hero.Name, Is.EqualTo(_saveData.Hero.Name), "JsonSaveDataReaderTests loaded a mismatching Hero's Name");
				Assert.That(result.Hero.Stats.Level, Is.EqualTo(_saveData.Hero.Stats.Level), "JsonSaveDataReaderTests loaded a mismatching Hero's Level");
				Assert.That(result.Hero.Stats.PhysicalAttack, Is.EqualTo(_saveData.Hero.Stats.PhysicalAttack), "JsonSaveDataReaderTests loaded a mismatching Hero's PhysicalAttack");
				Assert.That(result.Hero.Stats.PhysicalDefense, Is.EqualTo(_saveData.Hero.Stats.PhysicalDefense), "JsonSaveDataReaderTests loaded a mismatching Hero's PhysicalDefense");
				Assert.That(result.Hero.Stats.MagicalAttack, Is.EqualTo(_saveData.Hero.Stats.MagicalAttack), "JsonSaveDataReaderTests loaded a mismatching Hero's MagicalAttack");
				Assert.That(result.Hero.Stats.MagicalDefense, Is.EqualTo(_saveData.Hero.Stats.MagicalDefense), "JsonSaveDataReaderTests loaded a mismatching Hero's MagicalDefense");
				Assert.That(result.Hero.Stats.Speed, Is.EqualTo(_saveData.Hero.Stats.Speed), "JsonSaveDataReaderTests loaded a mismatching Hero's Speed");

				Assert.That(result.Hero.Stats.FireAttack, Is.EqualTo(_saveData.Hero.Stats.FireAttack), "JsonSaveDataReaderTests loaded a mismatching Hero's FireAttack");
				Assert.That(result.Hero.Stats.FireDefense, Is.EqualTo(_saveData.Hero.Stats.FireDefense), "JsonSaveDataReaderTests loaded a mismatching Hero's FireDefense");
				Assert.That(result.Hero.Stats.IceAttack, Is.EqualTo(_saveData.Hero.Stats.IceAttack), "JsonSaveDataReaderTests loaded a mismatching Hero's IceAttack");
				Assert.That(result.Hero.Stats.IceDefense, Is.EqualTo(_saveData.Hero.Stats.IceDefense), "JsonSaveDataReaderTests loaded a mismatching Hero's IceDefense");
				Assert.That(result.Hero.Stats.LightningAttack, Is.EqualTo(_saveData.Hero.Stats.LightningAttack), "JsonSaveDataReaderTests loaded a mismatching Hero's LightningAttack");
				Assert.That(result.Hero.Stats.LightningDefense, Is.EqualTo(_saveData.Hero.Stats.LightningDefense), "JsonSaveDataReaderTests loaded a mismatching Hero's LightningDefense");
				Assert.That(result.Hero.Stats.EarthAttack, Is.EqualTo(_saveData.Hero.Stats.EarthAttack), "JsonSaveDataReaderTests loaded a mismatching Hero's EarthAttack");
				Assert.That(result.Hero.Stats.EarthDefense, Is.EqualTo(_saveData.Hero.Stats.EarthDefense), "JsonSaveDataReaderTests loaded a mismatching Hero's EarthDefense");

				Assert.That(result.Inventory.HeroInventory.Count, Is.EqualTo(_saveData.Inventory.HeroInventory.Count), "JsonSaveDataReaderTests loaded a mismatching HeroInventory count");
				Assert.That(result.Inventory.HeroInventory.Select(_=>_.ID).Except(_saveData.Inventory.HeroInventory.Select(_ => _.ID)).Any(), Is.False, "JsonSaveDataReaderTests loaded a mismatching HeroInventory");

				Assert.That(result.QuestLog.CompletedQuests.Count, Is.EqualTo(_saveData.QuestLog.CompletedQuests.Count), "JsonSaveDataReaderTests loaded a mismatching Completed QuestLog count");
				Assert.That(result.QuestLog.CompletedQuests.Except(_saveData.QuestLog.CompletedQuests).Any(), Is.False, "JsonSaveDataReaderTests loaded a mismatching Completed QuestLog");
			});
		}
	}
}
