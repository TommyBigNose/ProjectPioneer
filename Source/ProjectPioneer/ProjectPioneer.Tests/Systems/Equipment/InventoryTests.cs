using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Data;
using ProjectPioneer.Systems.Equipment;

namespace ProjectPioneer.Tests.Systems.Equipment
{
	[TestFixture]
	public class InventoryTests
	{
		private IDataSource _dataSource;
		private IInventory _sut;

		[SetUp]
		public void SetUp()
		{
			_dataSource = new LocalDataSource();
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
			// Assert
		}

		[Test]
		public void Should_BeAbleToEquipNonWeapons_When_PlayerIsAnyJob()
		{
			// Arrange
			// Act
			// Assert
		}

		[Test]
		public void Should_BeAbleToEquipBasedOnJob_When_PlayerIsAnyJob()
		{
			// Arrange
			// Act
			// Assert
		}

		[Test]
		public void Should_EquipEquipmentAndReturnOldToInventory_When_Prompted()
		{
			// Arrange
			// Act
			// Assert
		}

		[Test]
		public void Should_SellEquipment_When_Prompted()
		{
			// Arrange
			// Act
			// Assert
		}
	}
}
