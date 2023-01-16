using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

		private ISaveableAttributeReader _sut;

		[SetUp]
		public void SetUp()
		{
			_dataSource = new MemoryDataSource();
			_heroBuilder = new HeroBuilder(_dataSource);
			_inventory = new Inventory();
			_questLog = new QuestLog(_dataSource);
			_sut = new SaveableAttributeReader();
		}

		[TearDown]
		public void TearDown()
		{

		}

		[Test]
		public void Should_ReturnCollectionOfStrings_When_GivenAnObjectWithSaveableAttributes()
		{
			// Arrange
			IJob job = new Job(999, "TestJob", "Desc", new List<EquipmentType>()
			{ EquipmentType.None, EquipmentType.Blade, EquipmentType.Armor, EquipmentType.Aura }, new Stats());

			IImplant implant = new Implant(999, "TestImplant", "Desc", new Stats());
			IHero hero = _heroBuilder.CreateHero("TestHeroName", job, implant);
			hero.AddExp(100);
			// Act
			var result = _sut.ReadAllAttributesOfObject(hero);

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(result, Does.Contain("HeroName|||TestHeroName"), "SaveableAttributeReader did not HeroName");
			});
		}
	}
}
