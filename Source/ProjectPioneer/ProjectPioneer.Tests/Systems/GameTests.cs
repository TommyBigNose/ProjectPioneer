using System;
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
			// Act
			var result = _sut.GetInventory();

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(result, Is.Not.Null, "Game did not return Inventory");
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
	}
}
