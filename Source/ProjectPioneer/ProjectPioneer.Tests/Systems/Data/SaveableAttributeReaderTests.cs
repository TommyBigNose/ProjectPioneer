﻿using System;
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
	public class SaveableAttributeReaderTests
	{
		private IDataSource _dataSource;
		private IHeroBuilder _heroBuilder;
		private IInventory _inventory;
		private IQuestLog _questLog;
		private SaveData _saveData;

		private ISaveableAttributeReader _sut;

		[SetUp]
		public void SetUp()
		{
			_dataSource = new MemoryDataSource();
			_heroBuilder = new HeroBuilder(_dataSource);
			_inventory = new Inventory();
			_questLog = new QuestLog(_dataSource);
			_saveData = new SaveData()
			{
				Hero = _heroBuilder.CreateHero("", _dataSource.GetAllJobs().First(), _dataSource.GetAllImplants().First()),
				Inventory = _inventory,
				QuestLog = _questLog
			};

			_sut = new SaveableAttributeReader();
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
			var result = _sut.ReadAllAttributesOfObject(_saveData);

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(result, Does.Contain($"{Constants.AttributeHeroName}|||TestHeroName"), "SaveableAttributeReader did not parse out Name");
				Assert.That(result, Does.Contain($"{Constants.AttributeHeroExp}|||0"), "SaveableAttributeReader did not parse out Exp");
				Assert.That(result, Does.Contain($"{Constants.AttributeHeroJob}|||999"), "SaveableAttributeReader did not parse out Job");
				Assert.That(result, Does.Contain($"{Constants.AttributeHeroImplant}|||1001"), "SaveableAttributeReader did not parse out Implant");
				Assert.That(result, Does.Contain($"{Constants.AttributeHeroWeapon}|||1"), "SaveableAttributeReader did not parse out Weapon");
				Assert.That(result, Does.Contain($"{Constants.AttributeHeroArmor}|||2"), "SaveableAttributeReader did not parse out Armor");
				Assert.That(result, Does.Contain($"{Constants.AttributeHeroAura}|||3"), "SaveableAttributeReader did not parse out Aura");
				Assert.That(result, Does.Contain($"{Constants.AttributeHeroStats}|||"+ JsonSerializer.Serialize(hero.Stats)), "SaveableAttributeReader did not parse out Stats");
			});
		}

		[Test]
		public void Should_ReturnsInventoryData_When_GivenNewInventory()
		{
			// Arrange
			// Act
			var result = _sut.ReadAllAttributesOfObject(_saveData);

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(result, Does.Contain($"{Constants.AttributeInventoryCredits}|||0"), "SaveableAttributeReader did not parse out Credits");
				Assert.That(result, Does.Contain($"{Constants.AttributeInventoryHerosInventory}|||"), "SaveableAttributeReader did not parse out Hero Inventory");
			});
		}

		[Test]
		public void Should_ReturnsInventoryData_When_GivenInventory()
		{
			// Arrange
			_dataSource.GetAllEquipment().ToList().ForEach(_ => _inventory.AddEquipment(_));
			string csvOfEquipment = string.Join(Constants.AttributeListSeparator, _inventory.HeroInventory.Select(_ => _.ID));
			_inventory.AddCredits(9999);

			// Act
			var result = _sut.ReadAllAttributesOfObject(_saveData);

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(result, Does.Contain($"{Constants.AttributeInventoryCredits}|||9999"), "SaveableAttributeReader did not parse out Credits");
				Assert.That(result, Does.Contain($"{Constants.AttributeInventoryHerosInventory}|||{csvOfEquipment}"), "SaveableAttributeReader did not parse out an empty Hero Inventory");
			});
		}

		[Test]
		public void Should_ReturnsQuestLogData_When_GivenNewQuestLog()
		{
			// Arrange
			// Act
			var result = _sut.ReadAllAttributesOfObject(_saveData);

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(result, Does.Contain($"{Constants.AttributeQuestLogCompletedQuests}|||"), "SaveableAttributeReader did not parse out an empty set of Completed Quests");
			});
		}

		[Test]
		public void Should_ReturnsQuestLogData_When_GivenQuestLog()
		{
			// Arrange
			_dataSource.GetAllQuestInfos().ToList().ForEach(_ => _questLog.CompleteQuest(new Quest(_)));
			string csvOfCompletedQuests = string.Join(Constants.AttributeListSeparator, _questLog.CompletedQuests.Select(_ => _.QuestInfo.ID));

			// Act
			var result = _sut.ReadAllAttributesOfObject(_saveData);

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(result, Does.Contain($"{Constants.AttributeQuestLogCompletedQuests}|||{csvOfCompletedQuests}"), "SaveableAttributeReader did not parse out Completed Quests");
			});
		}
	}
}
