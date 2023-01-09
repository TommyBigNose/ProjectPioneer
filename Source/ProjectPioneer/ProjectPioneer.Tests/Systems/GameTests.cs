﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems;
using ProjectPioneer.Systems.Character;
using ProjectPioneer.Systems.Data;
using ProjectPioneer.Systems.Equipment;
using ProjectPioneer.Systems.Statistics;

namespace ProjectPioneer.Tests.Systems
{
	[TestFixture]
	public class GameTests
	{
		private IDataSource _dataSource;
		private IHeroBuilder _heroBuilder;
		private IInventory _inventory;

		private IGame _sut;

		[SetUp]
		public void SetUp()
		{
			_dataSource = new LocalDataSource();
			_heroBuilder = new HeroBuilder(_dataSource);
			_inventory = new Inventory();

			_sut = new Game(_dataSource, _heroBuilder, _inventory);
		}

		[TearDown]
		public void TearDown()
		{

		}

		[Test]
		public void Should_SetUpHero_When_ValidInputsProvided()
		{
			// Arrange
			IJob job = new Job("TestJob", "Desc", new List<EquipmentType>() { EquipmentType.None }, new Stats());
			IImplant implant = new Implant("TestImplant", "Desc", new Stats());

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
			
			IJob job = new Job("TestJob", "Desc", new List<EquipmentType>() { EquipmentType.None, EquipmentType.Gun }, new Stats());
			IImplant implant = new Implant("TestImplant", "Desc", new Stats());
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
				Assert.That(firstEquipment.EquipmentType, Is.EqualTo(EquipmentType.Blade), "Game did not sort Blades first as expected");
				Assert.That(lastEquipment.EquipmentType, Is.EqualTo(EquipmentType.Aura), "Game did not sort as expected");
			});
		}
	}
}
