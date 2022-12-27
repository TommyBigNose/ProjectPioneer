using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Character;
using ProjectPioneer.Systems.Data;
using ProjectPioneer.Systems.Equipment;
using ProjectPioneer.Systems.Statistics;

namespace ProjectPioneer.Tests.Systems.Equipment
{
	[TestFixture]
	public class InventoryTests
	{
		private IDataSource _dataSource;
		private IHeroBuilder _heroBuilder;
		private IInventory _sut;

		[SetUp]
		public void SetUp()
		{
			_dataSource = new LocalDataSource();
			_heroBuilder = new HeroBuilder(_dataSource);
			_sut = new Inventory();
		}

		[TearDown]
		public void TearDown()
		{

		}

		[Test]
		public void Should_AddEquipment_When_Provided()
		{
			// Arrange
			// Act
			_sut.AddEquipment(_dataSource.GetDefaultWeapon());
			_sut.AddEquipment(_dataSource.GetDefaultArmor());
			_sut.AddEquipment(_dataSource.GetDefaultAura());

			// Assert
			Assert.That(_sut.HeroInventory.Count, Is.EqualTo(3), "Inventory did not add equipment as expected");
		}

		[Test]
		public void Should_BeAbleToEquipEquipment_When_PlayersJobAllowsIt()
		{
			// Arrange
			IJob job = new Job("TestJob", "Desc", new List<EquipmentType>() 
			{ EquipmentType.None, EquipmentType.Blade, EquipmentType.Armor, EquipmentType.Aura }, new Stats());

			IImplant implant = new Implant("TestImplant", "Desc", new Stats());
			IHero hero = _heroBuilder.CreateHero("Test", job, implant);

			// Act
			var resultWeapon = _sut.CanEquip(_dataSource.GetDefaultWeapon(), hero);
			var resultArmor = _sut.CanEquip(_dataSource.GetDefaultArmor(), hero);
			var resultAura = _sut.CanEquip(_dataSource.GetDefaultAura(), hero);

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(resultWeapon, Is.True, "Inventory did not allow equipable weapon to be equipped");
				Assert.That(resultArmor, Is.True, "Inventory did not allow equipable armor to be equipped");
				Assert.That(resultAura, Is.True, "Inventory did not allow equipable aura to be equipped");
			});
		}

		[Test]
		public void Should_NotBeAbleToEquipEquipment_When_PlayersJobDoesNotAllowIt()
		{
			// Arrange
			IJob job = new Job("TestJob", "Desc", new List<EquipmentType>()
			{ EquipmentType.None, EquipmentType.Blade }, new Stats());

			IImplant implant = new Implant("TestImplant", "Desc", new Stats());
			IHero hero = _heroBuilder.CreateHero("Test", job, implant);

			// Act
			var resultWeapon = _sut.CanEquip(_dataSource.GetAllWeapons().First(_=>_.EquipmentType == EquipmentType.Gun), hero);
			var resultArmor = _sut.CanEquip(_dataSource.GetDefaultArmor(), hero);
			var resultAura = _sut.CanEquip(_dataSource.GetDefaultAura(), hero);

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(resultWeapon, Is.False, "Inventory allowed un-equipable weapon to be equipped");
				Assert.That(resultArmor, Is.False, "Inventory allowed un-equipable armor to be equipped");
				Assert.That(resultAura, Is.False, "Inventory allowed un-equipable aura to be equipped");
			});
		}

		[Test]
		public void Should_EquipEquipmentAndReturnOldToInventory_When_Prompted()
		{
			// Arrange
			IJob job = new Job("TestJob", "Desc", new List<EquipmentType>()
			{ EquipmentType.None, EquipmentType.Blade, EquipmentType.Armor, EquipmentType.Aura }, new Stats());

			IImplant implant = new Implant("TestImplant", "Desc", new Stats());
			IHero hero = _heroBuilder.CreateHero("Test", job, implant);

			// Act
			IEquipment weapon = _dataSource.GetAllWeapons().First(_ => _.EquipmentType == EquipmentType.Blade);
			IEquipment armor = _dataSource.GetAllArmors().First(_ => _.EquipmentType == EquipmentType.Armor);
			IEquipment aura = _dataSource.GetAllAuras().First(_ => _.EquipmentType == EquipmentType.Aura);
			_sut.EquipEquipment(weapon, hero);
			_sut.EquipEquipment(armor, hero);
			_sut.EquipEquipment(aura, hero);
			var result = _sut.HeroInventory;

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(result.Count, Is.EqualTo(3), "Inventory did not equip equipment and put them in the inventory collection");
				Assert.That(hero.EquippedWeapon, Is.EqualTo(weapon), "Inventory did not equip hero with specified weapon");
				Assert.That(hero.EquippedArmor, Is.EqualTo(armor), "Inventory did not equip hero with specified armor");
				Assert.That(hero.EquippedAura, Is.EqualTo(aura), "Inventory did not equip hero with specified aura");
			});
		}

		[Test]
		public void Should_SellEquipment_When_Prompted()
		{
			// Arrange
			// Act
			// Assert
		}

		[Test]
		public void Should_SortEquipment_When_Prompted()
		{
			// Arrange
			// Act
			// Assert
		}
	}
}
