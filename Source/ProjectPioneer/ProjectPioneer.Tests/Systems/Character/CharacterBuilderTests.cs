using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Character;

namespace ProjectPioneer.Tests.Systems.Character
{
	[TestFixture]
	public class CharacterBuilderTests
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
			IJob job = new Job();
			IImplant implant = new Implant();

			// Act
			var result = _sut.CreateHero("Test", job, implant);

			// Assert
			Assert.That(result, Is.Not.Null);
		}
	}
}
