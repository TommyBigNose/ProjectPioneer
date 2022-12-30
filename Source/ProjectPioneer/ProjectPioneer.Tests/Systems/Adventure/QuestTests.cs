using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Adventure;
using ProjectPioneer.Systems.Data;

namespace ProjectPioneer.Tests.Systems.Adventure
{
	[TestFixture]
	internal class QuestTests
	{
		private IDataSource _dataSource;
		private IQuest _sut;

		[SetUp]
		public void SetUp()
		{
			_dataSource = new LocalDataSource();
		}

		[TearDown]
		public void TearDown()
		{

		}


		[TestCase(1)]
		[TestCase(2)]
		public void Should_GetRecommendedLevel_When_Prompted(int questLevel)
		{
			// Arrange
			_sut = new Quest(_dataSource.GetAllQuestInfos().First(_ => _.Stats.Level == questLevel));

			// Act
			var result = _sut.GetRecommendedLevel();

			// Assert
			Assert.That(result, Is.EqualTo(questLevel), "Quest did not return expected recommend level");
		}
	}
}
