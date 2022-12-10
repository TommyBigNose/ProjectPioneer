using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Character;
using ProjectPioneer.Systems.Statistics;

namespace ProjectPioneer.Tests.Systems.Character
{
	[TestFixture]
	public class HeroTests
	{
		private IHero _sut;

		[SetUp]
		public void SetUp()
		{
			//_sut = new Hero();
		}

		[TearDown]
		public void TearDown()
		{

		}

		[Test]
		public void Should_HaveUpgradedStats_When_LeveledUp()
		{
			// Arrange
			IJob job = new Job("TestJob", new Stats());
			IImplant implant = new Implant("TestImplant", new Stats());
			_sut = new Hero("Test", job, implant, new Stats());
			Stats initialStats = new Stats(_sut.Stats);

			// Act
			_sut.LevelUp();
			Stats resultingStats = new Stats(_sut.Stats);

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(resultingStats.Level, Is.GreaterThan(initialStats.Level), "HeroBuilder did not upgrade Level");

				Assert.That(resultingStats.PhysicalAttack, Is.GreaterThan(initialStats.PhysicalAttack), "HeroBuilder did not upgrade PhysicalAttack");
				Assert.That(resultingStats.PhysicalDefense, Is.GreaterThan(initialStats.PhysicalDefense), "HeroBuilder did not upgrade PhysicalDefense");
				Assert.That(resultingStats.MagicalAttack, Is.GreaterThan(initialStats.MagicalAttack), "HeroBuilder did not upgrade MagicalAttack");
				Assert.That(resultingStats.MagicalDefense, Is.GreaterThan(initialStats.MagicalDefense), "HeroBuilder did not upgrade MagicalDefense");
				Assert.That(resultingStats.Speed, Is.GreaterThan(initialStats.Speed), "HeroBuilder did not upgrade Speed");
			});
		}
	}
}
