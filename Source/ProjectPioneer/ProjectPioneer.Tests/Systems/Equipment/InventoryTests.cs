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

		[TestCase(0, 0, 0)]
		[TestCase(0, 100, 100)]
		[TestCase(100, 100, 200)]
		public void Should_AddCredits_When_Prompted(int initialCredits, int credits, int expected)
		{
			// Arrange
			_sut.AddCredits(initialCredits);
			
			// Act
			_sut.AddCredits(credits);

			// Assert
			Assert.That(_sut.Credits, Is.EqualTo(expected), "Inventory did not add credits");
		}

		[TestCase(0, 0, 0)]
		[TestCase(0, 100, 0)]
		[TestCase(100, 100, 0)]
		public void Should_RemoveCredits_When_Prompted(int initialCredits, int credits, int expected)
		{
			// Arrange
			_sut.AddCredits(initialCredits);

			// Act
			_sut.RemoveCredits(credits);

			// Assert
			Assert.That(_sut.Credits, Is.EqualTo(expected), "Inventory did not remove credits");
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
			IJob job = new Job(999, "TestJob", "Desc", new List<EquipmentType>() 
			{ EquipmentType.None, EquipmentType.Blade, EquipmentType.Armor, EquipmentType.Aura }, new Stats());

			IImplant implant = new Implant(999, "TestImplant", "Desc", new Stats());
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
			IJob job = new Job(999, "TestJob", "Desc", new List<EquipmentType>()
			{ EquipmentType.None, EquipmentType.Blade }, new Stats());

			IImplant implant = new Implant(999, "TestImplant", "Desc", new Stats());
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
			IJob job = new Job(999, "TestJob", "Desc", new List<EquipmentType>()
			{ EquipmentType.None, EquipmentType.Blade, EquipmentType.Armor, EquipmentType.Aura }, new Stats());

			IImplant implant = new Implant(999, "TestImplant", "Desc", new Stats());
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
			_dataSource.GetAllWeapons().ToList().ForEach(_ => _sut.AddEquipment(_));
			_dataSource.GetAllArmors().ToList().ForEach(_ => _sut.AddEquipment(_));
			_dataSource.GetAllAuras().ToList().ForEach(_ => _sut.AddEquipment(_));
			IEquipment equipmentToBeSold = _sut.HeroInventory.First();
			int initialInventoryAmount = _sut.HeroInventory.Count;

			// Act
			var result = _sut.SellEquipment(equipmentToBeSold);

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(result, Is.EqualTo(equipmentToBeSold.GetSellableValue()), "Inventory did not sell equipment at expected amount");
				Assert.That(_sut.Credits, Is.EqualTo(result), "Inventory did not gain credits from sold equipment");
				Assert.That(_sut.HeroInventory.Count, Is.EqualTo(initialInventoryAmount-1), "Inventory did not remove sold equipment from inventory collection");
				Assert.That(_sut.HeroInventory.Contains(equipmentToBeSold), Is.False, "Inventory still has sold equipment");
			});
		}

		[Test]
		public void Should_SellSingleEquipment_When_ThereAreDuplicates()
		{
			// Arrange
			_dataSource.GetAllWeapons().ToList().ForEach(_ => _sut.AddEquipment(_));
			_dataSource.GetAllWeapons().ToList().ForEach(_ => _sut.AddEquipment(_));
			IEquipment equipmentToBeSold = _sut.HeroInventory.First();
			int initialInventoryAmount = _sut.HeroInventory.Count;
			int initialDuplicateAmount = _sut.HeroInventory.Count(_ => _.Name == equipmentToBeSold.Name);

			// Act
			var result = _sut.SellEquipment(equipmentToBeSold);

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(_sut.Credits, Is.EqualTo(result), "Inventory did not gain credits from sold equipment");
				Assert.That(_sut.HeroInventory.Count, Is.EqualTo(initialInventoryAmount - 1), "Inventory did not remove sold equipment from inventory collection");
				Assert.That(_sut.HeroInventory.Contains(equipmentToBeSold), Is.False, "Inventory still has sold equipment");
				Assert.That(_sut.HeroInventory.Count(_=>_.Name == equipmentToBeSold.Name), Is.LessThan(initialDuplicateAmount), "Inventory still has other duplicates as expected");
			});
		}

		[Test]
		public void Should_SortEquipment_When_Prompted()
		{
			// Arrange
			_dataSource.GetAllAuras().ToList().ForEach(_ => _sut.AddEquipment(_));
			_dataSource.GetAllArmors().ToList().ForEach(_ => _sut.AddEquipment(_));
			_dataSource.GetAllWeapons().ToList().ForEach(_ => _sut.AddEquipment(_));
			IEquipment initialFirstEquipment = _sut.HeroInventory.First();

			// Act
			_sut.SortEquipment();
			IEquipment resultFirstEquipment = _sut.HeroInventory.First();
			IEquipment resultLastEquipment = _sut.HeroInventory.Last();
			int maxLevel = _sut.HeroInventory.Max(_ => _.Stats.Level);

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(resultFirstEquipment, Is.Not.EqualTo(initialFirstEquipment), "First item was not sorted as expected");
				Assert.That(resultFirstEquipment.EquipmentType, Is.EqualTo(EquipmentType.Blade), "First item was not in the order of expected");
				Assert.That(resultLastEquipment.Stats.Level, Is.EqualTo(maxLevel), "Secondary sort by level did not apply");
			});
		}
	}
}
