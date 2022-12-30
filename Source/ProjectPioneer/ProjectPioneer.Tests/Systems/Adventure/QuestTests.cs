using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using ProjectPioneer.Systems;
using ProjectPioneer.Systems.Adventure;
using ProjectPioneer.Systems.Character;
using ProjectPioneer.Systems.Data;
using ProjectPioneer.Systems.Statistics;

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

		[TestCase(1)]
		[TestCase(2)]
		public void Should_GetCreditsReward_When_Prompted(int questLevel)
		{
			// Arrange
			_sut = new Quest(_dataSource.GetAllQuestInfos().First(_ => _.Stats.Level == questLevel));

			// Act
			var result = _sut.GetCreditsReward();

			// Assert
			Assert.That(result, Is.EqualTo(questLevel * Constants.QuestRewardCreditScaling), "Quest did not return expected reward in credits");
		}

		[TestCase(1)]
		[TestCase(2)]
		public void Should_GetExpReward_When_Prompted(int questLevel)
		{
			// Arrange
			_sut = new Quest(_dataSource.GetAllQuestInfos().First(_ => _.Stats.Level == questLevel));

			// Act
			var result = _sut.GetExpReward();

			// Assert
			Assert.That(result, Is.EqualTo(questLevel * Constants.QuestRewardExpScaling), "Quest did not return expected reward in exp");
		}

		[TestCase(1)]
		[TestCase(2)]
		public void Should_GetStatsComparison_When_GivenHeroStats(int questLevel)
		{
			// Arrange
			_sut = new Quest(_dataSource.GetAllQuestInfos().First(_ => _.Stats.Level == questLevel));
			Stats questStats = _sut.QuestInfo.Stats;
			Stats heroStats = new Stats()
			{
				Level = 2,
				PhysicalAttack = 2,
				PhysicalDefense = 2,
				MagicalAttack = 2,
				MagicalDefense = 2,
				Speed = 2,
				FireAttack = 2,
				FireDefense = 2,
				IceAttack = 2,
				IceDefense = 2,
				LightningAttack = 2,
				LightningDefense = 2,
				EarthAttack = 2,
				EarthDefense = 2,
			};

			// Act
			var result = _sut.GetStatComparison(heroStats);

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(result.Level, 
					Is.EqualTo(heroStats.Level - questStats.Level), 
					"Quest stat comparison failed for Level");
				
				Assert.That(result.PhysicalAttack, 
					Is.EqualTo(heroStats.PhysicalAttack - questStats.PhysicalDefense),
					"Quest stat comparison failed for PhysicalAttack");
				Assert.That(result.PhysicalDefense, 
					Is.EqualTo(heroStats.PhysicalDefense - questStats.PhysicalAttack),
					"Quest stat comparison failed for PhysicalDefense");

				Assert.That(result.MagicalAttack,
					Is.EqualTo(heroStats.MagicalAttack - questStats.MagicalDefense),
					"Quest stat comparison failed for MagicalAttack");
				Assert.That(result.MagicalDefense,
					Is.EqualTo(heroStats.MagicalDefense - questStats.MagicalAttack),
					"Quest stat comparison failed for MagicalDefense");

				Assert.That(result.Speed,
					Is.EqualTo(heroStats.Speed - questStats.Speed),
					"Quest stat comparison failed for Speed");

				Assert.That(result.FireAttack,
					Is.EqualTo(heroStats.FireAttack - questStats.FireDefense),
					"Quest stat comparison failed for FireAttack");
				Assert.That(result.FireDefense,
					Is.EqualTo(heroStats.FireDefense - questStats.FireAttack),
					"Quest stat comparison failed for FireDefense");

				Assert.That(result.IceAttack,
					Is.EqualTo(heroStats.IceAttack - questStats.IceDefense),
					"Quest stat comparison failed for IceAttack");
				Assert.That(result.IceDefense,
					Is.EqualTo(heroStats.IceDefense - questStats.IceAttack),
					"Quest stat comparison failed for IceDefense");

				Assert.That(result.LightningAttack,
					Is.EqualTo(heroStats.LightningAttack - questStats.LightningDefense),
					"Quest stat comparison failed for LightningAttack");
				Assert.That(result.LightningDefense,
					Is.EqualTo(heroStats.LightningDefense - questStats.LightningAttack),
					"Quest stat comparison failed for LightningDefense");

				Assert.That(result.EarthAttack,
					Is.EqualTo(heroStats.EarthAttack - questStats.EarthDefense),
					"Quest stat comparison failed for EarthAttack");
				Assert.That(result.EarthDefense,
					Is.EqualTo(heroStats.EarthDefense - questStats.EarthAttack),
					"Quest stat comparison failed for EarthDefense");
			});
		}
	}
}
