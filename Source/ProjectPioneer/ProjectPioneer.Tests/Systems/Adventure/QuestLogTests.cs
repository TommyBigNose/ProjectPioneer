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
			_dataSource = new MemoryDataSource();
			_sut = new QuestLog();
		}

		[TearDown]
		public void TearDown()
		{

		}

		[Test]
		public void Should_LogQuestAsCompleted_When_Prompted()
		{
			// Arrange
			var questToComplete1 = _dataSource.GetAllQuests().First();
			var questToComplete2 = _dataSource.GetAllQuests().Last();

			// Act
			_sut.CompleteQuest(questToComplete1);
			_sut.CompleteQuest(questToComplete2);
			var result = _sut.CompletedQuests;

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(result.Count, Is.EqualTo(2), "QuestLog did not complete a quest as expected");
				Assert.That(result.Contains(questToComplete1.QuestInfo.ID), Is.True, "QuestLog did not contain completed quest");
				Assert.That(result.Contains(questToComplete2.QuestInfo.ID), Is.True, "QuestLog did not contain completed quest");
			});
		}
	}
}
