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
			float expected = (float)(_sut.ValueMax / seconds) / (float)(_sut.ValueMax / _sut.IncrementTickRateInMs);

			// Act
			var result = _sut.IncrementRate;

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

		[TestCase(10)]
		[TestCase(30)]
		[TestCase(60)]
		[TestCase(120)]
		public void Should_BeReset_When_Prompted(int seconds)
		{
			// Arrange
			_sut = new ProgressBar(TimeSpan.FromSeconds(seconds));

			// Act
			IncrementForSimulatedSeconds(seconds);
			_sut.ResetProgressBar();
			var result = _sut.IsFinished();
			Console.WriteLine($"Final result: {_sut.Value}");

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(_sut.Value, Is.EqualTo(0.0f), "ProgressBar was not completely reset");
				Assert.That(result, Is.False, "Progressbar marked as finished despite reset");
			});
		}

		private void IncrementForSimulatedSeconds(int seconds)
		{
			int numberOfTicksPerSecond = (int)(_sut.ValueMax / _sut.IncrementTickRateInMs);
			int totalNumberOfTicks = seconds * numberOfTicksPerSecond;

			for (int i = 0; i < totalNumberOfTicks; i++)
			{
				_sut.IncrementProgressBar();
			}
		}
	}
}
