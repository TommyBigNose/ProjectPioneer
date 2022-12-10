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
	public class HeroBuilderTests
	{
		private IHeroBuilder _sut;

		[SetUp]
		public void SetUp()
		{
			_sut = new HeroBuilder();
		}

		[TearDown]
		public void TearDown()
		{

		}

		[Test]
		public void Should_CreateHero_When_InputsAreValid()
		{
			// Arrange
			IJob job = new Job("TestJob", new Stats());
			IImplant implant = new Implant("TestImplant", new Stats());

			// Act
			var result = _sut.CreateHero("Test", job, implant);

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(result, Is.Not.Null);
				Assert.That(result.GetLevel(), Is.EqualTo(1), "HeroBuilder did not set initial level");
			});
		}
	}
}
