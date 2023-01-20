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
	public class MemoryDataSourceTests
	{
		private IDataSource _sut;

		[SetUp]
		public void SetUp()
		{
			_sut = new MemoryDataSource();
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
			Assert.That(result.Count, Is.GreaterThanOrEqualTo(3), "MemoryDataSourceTests did not return enough jobs.");
		}

		[Test]
		public void Should_GetAllImplants()
		{
			// Arrange
			// Act
			var result = _sut.GetAllImplants();

			// Assert
			Assert.That(result.Count, Is.GreaterThanOrEqualTo(3), "MemoryDataSourceTests did not return enough implants.");
		}


		[Test]
		public void Should_GetAllWeapons()
		{
			// Arrange
			// Act
			var result = _sut.GetAllWeapons();

			// Assert
			Assert.That(result.Count, Is.GreaterThanOrEqualTo(3), "MemoryDataSourceTests did not return enough weapons.");
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
				Assert.That(result.Count, Is.LessThanOrEqualTo(totalEquipment), "MemoryDataSourceTests returned too much equipment");
				Assert.That(result.Count, Is.GreaterThanOrEqualTo(0), "MemoryDataSourceTests did not return enough equipment between range");
				Assert.That(isEquipmentOutOfRange, Is.False, "MemoryDataSourceTests returned equipment out of specified range");
			});
		}

		[TestCase(1)]
		[TestCase(101)]
		[TestCase(301)]
		[TestCase(501)]
		public void Should_GetSpecificEquipment_When_GivenID(int id)
		{
			// Arrange
			// Act
			var result = _sut.GetEquipmentByID(id);

			// Assert
			Assert.That(result.ID, Is.EqualTo(id), "MemoryDataSourceTests did not return the expected equipment.");
		}

		[Test]
		public void Should_GetSpecificEquipmentList_When_GivenListOfIDs()
		{
			// Arrange
			List<int> ids = new List<int>() { 1, 101, 301, 501 };

			// Act
			var result = _sut.GetEquipmentByIDs(ids).Select(_ => _.ID);

			// Assert
			Assert.That(result.Except(ids).Any(), Is.False, "MemoryDataSourceTests did not return the expected equipment list.");
		}

		[Test]
		public void Should_GetDefaultWeapon()
		{
			// Arrange
			// Act
			var result = _sut.GetDefaultWeapon();

			// Assert
			Assert.That(result.Name, Is.EqualTo("Nothing"), "MemoryDataSourceTests did not return the default weapon.");
		}

		[Test]
		public void Should_GetDefaultArmor()
		{
			// Arrange
			// Act
			var result = _sut.GetDefaultArmor();

			// Assert
			Assert.That(result.Name, Is.EqualTo("Clothes"), "MemoryDataSourceTests did not return the default armor.");
		}

		[Test]
		public void Should_GetDefaultAura()
		{
			// Arrange
			// Act
			var result = _sut.GetDefaultAura();

			// Assert
			Assert.That(result.Name, Is.EqualTo("Basic"), "MemoryDataSourceTests did not return the default aura.");
		}

		[Test]
		public void Should_GetAllQuestsInfos()
		{
			// Arrange
			// Act
			var result = _sut.GetAllQuestInfos();

			// Assert
			Assert.That(result.Count, Is.GreaterThanOrEqualTo(2), "MemoryDataSourceTests did not return enough QuestsInfos.");
		}

		[Test]
		public void Should_GetAllQuests()
		{
			// Arrange
			// Act
			var result = _sut.GetAllQuests();

			// Assert
			Assert.That(result.Count, Is.GreaterThanOrEqualTo(2), "MemoryDataSourceTests did not return enough Quests.");
		}
	}
}
