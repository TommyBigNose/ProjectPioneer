using System.Collections;
using ProjectPioneer.Systems.Dice;

namespace ProjectPioneer.Tests.Systems.Dice
{
	public class DiceSystemTests
	{
		private IDiceSystem _sut;

		[SetUp]
		public void SetUp()
		{
			_sut = new DiceSystem();
		}

		[TearDown]
		public void TearDown()
		{

		}

		[TestCaseSource(nameof(GetDiceSystemMinMaxesValid))]
		public void Should_GetRandomNumberFromDiceRoll_When_MinIsLessThanMax(int min, int max)
		{
			// Arrange
			// Act
			var result = _sut.GetDiceRoll(min, max);

			// Assert
			Assert.That(result, Is.InRange(min, max), "Dice roll was not within specified ranges.");
		}

		[TestCaseSource(nameof(GetDiceSystemMinMaxesInvalid))]
		public void Should_ThrowError_When_MaxIsLessThanMin(int min, int max)
		{
			// Arrange
			// Act
			// Assert
			Assert.Throws<ArgumentOutOfRangeException>(() => _sut.GetDiceRoll(min, max), "Dice roll inputs Max > Min didn't error as expected");
		}

		private static IEnumerable GetDiceSystemMinMaxesValid()
		{
			for (int i = 0; i < 10; i++)
			{
				for (int j = i; j < 10; j++)
				{
					yield return new object[] { i, j };
				}
			}
		}

		private static IEnumerable GetDiceSystemMinMaxesInvalid()
		{
			for (int i = 1; i < 10; i++)
			{
				for (int j = i - 1; j > 0; j--)
				{
					yield return new object[] { i, j };
				}
			}
		}

		private static readonly object[] DiceSystemTestCases =
		{
			new object[] { 1, 6 },
			new object[] { 0, 6 },
			new object[] { 1, 20 },
			new object[] { 0, 20 },
			new object[] { 1, 100 },
			new object[] { 0, 100 },
			new object[] { 1, 1000 },
			new object[] { 0, 1000 },
		};
	}
}
