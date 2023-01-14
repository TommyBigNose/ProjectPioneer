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
	public class QuestLogTests
	{
		private IDataSource _dataSource;
		private IQuestLog _sut;

		[SetUp]
		public void SetUp()
		{
			_dataSource = new LocalDataSource();
			_sut = new QuestLog(_dataSource);
		}

		[TearDown]
		public void TearDown()
		{

		}

		[Test]
		public void Should_HaveSetUpQuests_When_Initialized()
		{
			// Arrange
			// Act
			var result = _sut.Quests;

			// Assert
			Assert.That(result.Count, Is.EqualTo(_dataSource.GetAllQuestInfos().Count()), "QuestLog did not initialize correctly");
		}

		[Test]
		public void Should_LogQuestAsCompleted_When_Prompted()
		{
			// Arrange
			var questToComplete = _sut.Quests.First();

			// Act
			_sut.CompleteQuest(questToComplete);
			var result = _sut.CompletedQuests;

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(result.Count, Is.EqualTo(1), "QuestLog did not complete a quest as expected");
				Assert.That(result.Contains(questToComplete), Is.True, "QuestLog did not contain completed quest");
			});
		}
	}
}
