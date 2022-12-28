using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Adventure;

namespace ProjectPioneer.Tests.Systems.Adventure
{
	[TestFixture]
	public class ProgressBarTests
	{
		private IProgressBar _sut;

		[SetUp]
		public void SetUp()
		{

		}

		[TearDown]
		public void TearDown()
		{

		}

		[TestCase(10)]
		[TestCase(30)]
		[TestCase(60)]
		[TestCase(120)]
		public void Should_IncrementShouldBeBasedOnTime_When_GivenDifferentTimeInSeconds(int seconds)
		{
			// Arrange
			_sut = new ProgressBar(TimeSpan.FromSeconds(seconds));
			float expected = (float)(_sut.ValueMax / seconds) / (float)(_sut.ValueMax / _sut.IncrementRateInMs);

			// Act
			var result = _sut.Increment;

			// Assert
			Assert.That(result, Is.EqualTo(expected), "ProgressBar Increment rate was not at the expected amount");
		}

		[TestCase(10)]
		[TestCase(30)]
		[TestCase(60)]
		[TestCase(120)]
		public void Should_BeFinished_When_ValueIsAtMax(int seconds)
		{
			// Arrange
			_sut = new ProgressBar(TimeSpan.FromSeconds(seconds));

			// Act
			IncrementForSimulatedSeconds(seconds);
			var result = _sut.IsFinished();
			Console.WriteLine($"Final result: {_sut.Value}");

			// Assert
			Assert.That(result, Is.True, "Progressbar did not finish at expected rate");
		}

		private void IncrementForSimulatedSeconds(int seconds)
		{
			int numberOfTicksPerSecond = (int)(_sut.ValueMax / _sut.IncrementRateInMs);
			int totalNumberOfTickets = seconds * numberOfTicksPerSecond;

			for (int i = 0; i < totalNumberOfTickets; i++)
			{
				_sut.IncrementProgressBar();
			}
		}
	}
}
