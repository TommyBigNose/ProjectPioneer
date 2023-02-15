using ProjectPioneer.Systems.Data;
using ProjectPioneer.Systems.Equipment;

namespace ProjectPioneer.Tests.Systems.Equipment
{
	[TestFixture]
	public class ShopTests
	{
		private IDataSource _dataSource;
		private IInventory _inventory;
		private IShop _sut;

		[SetUp]
		public void SetUp()
		{
			_dataSource = new MemoryDataSource();
			_inventory = new Inventory();
			_sut = new Shop(_dataSource);
		}

		[TearDown]
		public void TearDown()
		{

		}

		[TestCase(1)]
		[TestCase(20)]
		public void Should_GetShopInventoryInLevelRange(int level)
		{
			// Arrange
			// Act
			var result = _sut.GetShopInventory(level).ToList();
			int maxLevel = result.Max(_ => _.Stats.Level);

			// Assert
			Assert.That(maxLevel, Is.LessThanOrEqualTo(level + 1), "Shop invetory returned wrong equipment level range");
		}

		[TestCase(100)]
		[TestCase(1000)]
		public void Should_CanPurchaseEquipment_When_PlayerHasEnoughCredits(int credits)
		{
			// Arrange
			_inventory.AddCredits(credits);
			IEquipment sellableWeapon = _dataSource.GetAllWeapons().First(_ => _.GetPurchaseValue() <= credits);

			// Act
			var result = _sut.CanHeroAffordEquipment(sellableWeapon, _inventory);

			// Assert
			Assert.That(result, Is.True, "Shop said the equipment was not affordable despite being within the player's budget");
		}

		[TestCase(0)]
		[TestCase(99)]
		public void Should_CannotPurchaseEquipment_When_PlayerIsBroke(int credits)
		{
			// Arrange
			_inventory.AddCredits(credits);
			IEquipment sellableWeapon = _dataSource.GetAllWeapons().First(_ => _.GetPurchaseValue() >= credits);

			// Act
			var result = _sut.CanHeroAffordEquipment(sellableWeapon, _inventory);

			// Assert
			Assert.That(result, Is.False, "Shop said the equipment was affordable despite being broke");
		}


		[TestCase(1000)]
		public void Should_AddEquipmentToInventoryAndRemoveCredits_When_PlayerBuysEquipment(int credits)
		{
			// Arrange
			_inventory.AddCredits(credits);
			IEquipment sellableWeapon = _dataSource.GetAllWeapons().First();

			// Act
			_sut.BuyEquipmentAndAddToInventory(sellableWeapon, _inventory);

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(_inventory.HeroInventory.Contains(sellableWeapon), Is.True, "Shop did not add sold Weapon to Inventory");
				Assert.That(_inventory.Credits, Is.EqualTo(credits - sellableWeapon.GetPurchaseValue()), "Shop did not remove credits from Inventory");
			});
		}
	}
}
