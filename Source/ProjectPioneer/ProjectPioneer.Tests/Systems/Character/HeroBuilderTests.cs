using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Character;
using ProjectPioneer.Systems.Data;
using ProjectPioneer.Systems.Equipment;
using ProjectPioneer.Systems.Statistics;

namespace ProjectPioneer.Tests.Systems.Character
{
	[TestFixture]
	public class HeroBuilderTests
	{
		private IDataSource _dataSource;
		private IHeroBuilder _sut;

		[SetUp]
		public void SetUp()
		{
			_dataSource = new LocalDataSource();
			_sut = new HeroBuilder(_dataSource);
		}

		[TearDown]
		public void TearDown()
		{

		}

		[Test]
		public void Should_CreateHero_When_InputsAreValid()
		{
			// Arrange
			IJob job = new Job(999, "TestJob", "Desc", new List<EquipmentType>() { EquipmentType.None }, new Stats());
			IImplant implant = new Implant(999, "TestImplant", "Desc", new Stats());

			// Act
			var result = _sut.CreateHero("Test", job, implant);

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(result, Is.Not.Null);
				Assert.That(result.GetLevel(), Is.EqualTo(1), "HeroBuilder did not set initial level");
				Assert.That(result.EquippedWeapon.Name, Is.EqualTo("Nothing"), "HeroBuilder did not equip default weapon");
			});
		}
	}
}
