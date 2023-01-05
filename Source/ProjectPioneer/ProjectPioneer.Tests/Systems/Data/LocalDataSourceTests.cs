using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Character;
using ProjectPioneer.Systems.Data;

namespace ProjectPioneer.Tests.Systems.Data
{
	[TestFixture]
	public class LocalDataSourceTests
	{
		private IDataSource _sut;

		[SetUp]
		public void SetUp()
		{
			_sut = new LocalDataSource();
		}

		[TearDown]
		public void TearDown()
		{

		}

		[Test]
		public void Should_GetAllJobs()
		{
			// Arrange
			// Act
			var result = _sut.GetAllJobs();

			// Assert
			Assert.That(result.Count, Is.GreaterThanOrEqualTo(3), "LocalDataSource did not return enough jobs.");
		}

		[Test]
		public void Should_GetAllImplants()
		{
			// Arrange
			// Act
			var result = _sut.GetAllImplants();

			// Assert
			Assert.That(result.Count, Is.GreaterThanOrEqualTo(3), "LocalDataSource did not return enough implants.");
		}


		[Test]
		public void Should_GetAllWeapons()
		{
			// Arrange
			// Act
			var result = _sut.GetAllWeapons();

			// Assert
			Assert.That(result.Count, Is.GreaterThanOrEqualTo(3), "LocalDataSource did not return enough weapons.");
		}

		[TestCase(1, 5)]
		[TestCase(1, 20)]
		[TestCase(0, 999)]
		public void Should_GetAllEquipmentWithinLevelRange_When_Prompted(int minLevel, int maxLevel)
		{
			// Arrange
			// Act
			var result = _sut.GetAllEquipment(minLevel, maxLevel);
			var totalEquipment = _sut.GetAllEquipment().ToList().Count;
			bool isEquipmentOutOfRange = result.ToList().Exists(_ => _.Stats.Level < minLevel || _.Stats.Level > maxLevel);

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(result.Count, Is.LessThanOrEqualTo(totalEquipment), "LocalDataSource returned too much equipment");
				Assert.That(result.Count, Is.GreaterThanOrEqualTo(0), "LocalDataSource did not return enough equipment between range");
				Assert.That(isEquipmentOutOfRange, Is.False, "LocalDataSource returned equipment out of specified range");
			});
		}

		[Test]
		public void Should_GetDefaultWeapon()
		{
			// Arrange
			// Act
			var result = _sut.GetDefaultWeapon();

			// Assert
			Assert.That(result.Name, Is.EqualTo("Nothing"), "LocalDataSource did not return the default weapon.");
		}

		[Test]
		public void Should_GetDefaultArmor()
		{
			// Arrange
			// Act
			var result = _sut.GetDefaultArmor();

			// Assert
			Assert.That(result.Name, Is.EqualTo("Clothes"), "LocalDataSource did not return the default armor.");
		}

		[Test]
		public void Should_GetDefaultAura()
		{
			// Arrange
			// Act
			var result = _sut.GetDefaultAura();

			// Assert
			Assert.That(result.Name, Is.EqualTo("Basic"), "LocalDataSource did not return the default aura.");
		}

		[Test]
		public void Should_GetAllQuests()
		{
			// Arrange
			// Act
			var result = _sut.GetAllQuestInfos();

			// Assert
			Assert.That(result.Count, Is.GreaterThanOrEqualTo(2), "LocalDataSource did not return enough quests.");
		}
	}
}
