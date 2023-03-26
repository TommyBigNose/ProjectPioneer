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
			_dataSource = new MemoryDataSource();
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

		[TestCase(1, 0)]
		[TestCase(1, 1)]
		[TestCase(1, 5)]
		[TestCase(2, 0)]
		[TestCase(2, 1)]
		[TestCase(2, 5)]
		public void Should_ReturnLootedEquipment_When_Prompted(int questLevel, int expectedAttemptedLootCount)
		{
			// Arrange
			_sut = new Quest(_dataSource.GetAllQuestInfos().First(_ => _.Stats.Level == questLevel));
			_sut.QuestInfo.TotalChancesForLoot = 5;
			Stats comparedStats = GetStatsScaledByLevel(questLevel);
			_sut.StartQuest(comparedStats);

			IncrementForSimulatedSeconds(60);
			for (int i = 0; i < expectedAttemptedLootCount; i++)
			{
				_sut.AttemptLootChance();
			}

			// Act
			var result = _sut.GetEquipmentReward();
			var totalRewardAttempts = _sut.OnGoingQuest.LootedEquipment.ToList();
			var totalRealRewards = totalRewardAttempts.FindAll(_ => _ != null).Sum(_ => 1);

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(result.Count, Is.EqualTo(totalRealRewards), "Real Quest loot was not properly added to loot collection and returned");
				Assert.That(totalRewardAttempts.Count, Is.EqualTo(expectedAttemptedLootCount), "Quest loot was not properly added to loot collection and returned");
			});
		}

		[TestCase(1)]
		[TestCase(2)]
		public void Should_GetStatsComparison_When_GivenHeroStats(int questLevel)
		{
			// Arrange
			_sut = new Quest(_dataSource.GetAllQuestInfos().First(_ => _.Stats.Level == questLevel));
			Stats questStats = _sut.QuestInfo.Stats;
			Stats heroStats = GetStatsScaledByLevel(1);

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


		[TestCase(1)]
		[TestCase(2)]
		[TestCase(4)]
		public void Should_GetReductionInSeconds_When_GivenStats(int questLevel)
		{
			// Arrange
			_sut = new Quest(_dataSource.GetAllQuestInfos().First(_ => _.Stats.Level == questLevel));
			Stats comparedStats = GetStatsScaledByLevel(questLevel);
			int multiplierSum = (int)Math.Ceiling((_sut.QuestInfo.StatTypeMultipliers.Count * questLevel) * _sut.QuestInfo.StatTypeMultiplierRatio);

			// 14 stats, scaling appropriately 
			int expectedSeconds = 14 * (2 * questLevel);

			// Act
			var result = _sut.GetSecondReductionFromStatComparison(comparedStats);

			// Assert
			Assert.That(result - multiplierSum, Is.EqualTo(expectedSeconds), "Quest second reduction calculation did not return as expected");
		}

		[TestCase(0)]
		[TestCase(10)]
		[TestCase(50)]
		[TestCase(100)]
		[TestCase(-10)]
		[TestCase(-50)]
		[TestCase(-100)]
		public void Should_GetFinalQuestLengthInSeconds_When_GivenStats(int secondReduction)
		{
			// Arrange
			_sut = new Quest(_dataSource.GetAllQuestInfos().First());
			int initialQuestLength = _sut.QuestInfo.QuestLengthInSeconds;

			// Act
			var result = _sut.GetFinalQuestLengthInSeconds(secondReduction);
			int expectedSeconds = Math.Max(Constants.QuestMinimumLengthInSeconds, initialQuestLength - secondReduction);

			// Assert
			Assert.That(result, Is.EqualTo(expectedSeconds), $"Quest final length check did not subtract/add as expected, with a minimum quest length of {Constants.QuestMinimumLengthInSeconds} seconds");
		}

		[TestCase(1)]
		[TestCase(2)]
		public void Should_StartQuest_When_Prompted(int questLevel)
		{
			// Arrange
			_sut = new Quest(_dataSource.GetAllQuestInfos().First(_ => _.Stats.Level == questLevel));
			Stats comparedStats = GetStatsScaledByLevel(questLevel);

			// Act
			_sut.StartQuest(comparedStats);
			var finalQuestLengthInSeconds = _sut.GetFinalQuestLengthInSeconds(_sut.GetSecondReductionFromStatComparison(comparedStats));
			var timer = _sut.OnGoingQuest.QuestTimer;
			Thread.Sleep(150);

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(finalQuestLengthInSeconds, Is.EqualTo(_sut.OnGoingQuest.FinalQuestLengthInSeconds), "Quest total time in seconds was not expected value");
				Assert.That(timer.Interval, Is.EqualTo(Constants.QuestProgressBarIncrementTickRateInMs), "Quest timer interface was not expected value");
				Assert.That(_sut.OnGoingQuest.ProgressBar.Value, Is.GreaterThanOrEqualTo(_sut.OnGoingQuest.ProgressBar.IncrementRate), "Quest progress bar did not increment");
				Assert.That(_sut.OnGoingQuest.LootIntervals, Is.EqualTo(_sut.OnGoingQuest.ProgressBar.ValueMax / _sut.QuestInfo.TotalChancesForLoot), "Quest loot interval was not setup properly");
				Assert.That(_sut.Status, Is.EqualTo(QuestStatus.OnGoing), "Quest status is not OnGoing");
			});
		}

		[TestCase(1)]
		[TestCase(2)]
		public void Should_AddLootedEquipment_When_OnGoingQuestHitsInterval(int questLevel)
		{
			// Arrange
			_sut = new Quest(_dataSource.GetAllQuestInfos().First(_ => _.Stats.Level == questLevel));
			_sut.QuestInfo.TotalChancesForLoot = 5;
			Stats comparedStats = GetStatsScaledByLevel(questLevel);
			_sut.StartQuest(comparedStats);
			_sut.QuestTimerElapsed(null, null);
			int initialLootCount = _sut.OnGoingQuest.LootedEquipment.Count;

			IncrementForSimulatedSeconds(60);
			_sut.QuestTimerElapsed(null, null);
			_sut.AttemptLootChance();
			_sut.QuestTimerElapsed(null, null);
			_sut.AttemptLootChance();
			_sut.QuestTimerElapsed(null, null);
			_sut.AttemptLootChance();
			_sut.QuestTimerElapsed(null, null);
			_sut.AttemptLootChance();
			_sut.QuestTimerElapsed(null, null);
			_sut.AttemptLootChance();

			// Act
			var result = _sut.OnGoingQuest.LootedEquipment.ToList();
			int expectedLootCount = (int)Math.Truncate(_sut.OnGoingQuest.ProgressBar.Value / _sut.OnGoingQuest.LootIntervals);

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(initialLootCount, Is.EqualTo(0), "Quest looted too quickly at the quest start");
				Assert.That(result.Count, Is.EqualTo(expectedLootCount), "Quest loot was not properly added to loot collection");
			});
		}

		[TestCase(1)]
		[TestCase(2)]
		public void Should_BeReadyForLootChance_When_OnGoingQuestHitsInterval(int questLevel)
		{
			// Arrange
			_sut = new Quest(_dataSource.GetAllQuestInfos().First(_ => _.Stats.Level == questLevel));
			_sut.QuestInfo.TotalChancesForLoot = 5;
			Stats comparedStats = GetStatsScaledByLevel(questLevel);
			_sut.StartQuest(comparedStats);

			// Act
			var result1 = _sut.IsProgressReadyForLootChance();
			IncrementForSimulatedSeconds(60);
			var result2 = _sut.IsProgressReadyForLootChance();

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(result1, Is.False, "Quest is ready to loot too soon");
				Assert.That(result2, Is.True, "Quest is not ready to loot despite enough time passing");
			});
		}

		[TestCase(1)]
		[TestCase(2)]
		public void Should_AddToLoot_When_Prompted(int questLevel)
		{
			// Arrange
			_sut = new Quest(_dataSource.GetAllQuestInfos().First(_ => _.Stats.Level == questLevel));
			_sut.QuestInfo.TotalChancesForLoot = 5;
			Stats comparedStats = GetStatsScaledByLevel(questLevel);
			_sut.StartQuest(comparedStats);

			// Act
			_sut.AttemptLootChance();
			int initialLootCount = _sut.OnGoingQuest.LootedEquipment.Count;
			IncrementForSimulatedSeconds(60);
			_sut.AttemptLootChance();
			int resultingLootCount = _sut.OnGoingQuest.LootedEquipment.Count;

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(initialLootCount, Is.EqualTo(0), "Quest attempted to a loot chance despite progress not being far enough");
				Assert.That(resultingLootCount, Is.EqualTo(1), "Quest didn't get any loot chances despite progress being far enough");
			});
		}

		[TestCase(1)]
		[TestCase(2)]
		public void Should_CompleteQuest_When_Prompted(int questLevel)
		{
			// Arrange
			_sut = new Quest(_dataSource.GetAllQuestInfos().First(_ => _.Stats.Level == questLevel));
			Stats comparedStats = GetStatsScaledByLevel(questLevel);
			_sut.StartQuest(comparedStats);

			// Act
			_sut.CompleteQuest();

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(_sut.Status, Is.EqualTo(QuestStatus.Completed), "Quest status is not Completed");
			});
		}

		[TestCase(1)]
		[TestCase(2)]
		public void Should_PauseQuest_When_Prompted(int questLevel)
		{
			// Arrange
			_sut = new Quest(_dataSource.GetAllQuestInfos().First(_ => _.Stats.Level == questLevel));
			Stats comparedStats = GetStatsScaledByLevel(questLevel);
			_sut.StartQuest(comparedStats);
			Thread.Sleep(150);

			// Act
			_sut.PauseQuest();
			float initialProgressBarValue = _sut.OnGoingQuest.ProgressBar.Value;
			Thread.Sleep(150);
			float pausedProgressBarValue = _sut.OnGoingQuest.ProgressBar.Value;

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(pausedProgressBarValue, Is.EqualTo(initialProgressBarValue), "Quest pause did not pause the timer");
				Assert.That(_sut.Status, Is.EqualTo(QuestStatus.Paused), "Quest status is not Paused");
			});
		}

		[TestCase(1)]
		[TestCase(2)]
		public void Should_CancelQuest_When_Prompted(int questLevel)
		{
			// Arrange
			_sut = new Quest(_dataSource.GetAllQuestInfos().First(_ => _.Stats.Level == questLevel));
			Stats comparedStats = GetStatsScaledByLevel(questLevel);
			_sut.StartQuest(comparedStats);
			Thread.Sleep(150);

			// Act
			_sut.CancelQuest();
			float initialProgressBarValue = _sut.OnGoingQuest.ProgressBar.Value;
			Thread.Sleep(150);
			float cancelledProgressBarValue = _sut.OnGoingQuest.ProgressBar.Value;

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(cancelledProgressBarValue, Is.EqualTo(initialProgressBarValue), "Quest cancel did not pause the timer");
				Assert.That(_sut.Status, Is.EqualTo(QuestStatus.Cancelled), "Quest status is not Cancelled");
			});
		}

		[TestCase(1)]
		[TestCase(2)]
		public void Should_ContinueQuest_When_PromptedAfterStopping(int questLevel)
		{
			// Arrange
			_sut = new Quest(_dataSource.GetAllQuestInfos().First(_ => _.Stats.Level == questLevel));
			Stats comparedStats = GetStatsScaledByLevel(questLevel);
			_sut.StartQuest(comparedStats);
			Thread.Sleep(150);
			_sut.PauseQuest();
			float initialProgressBarValue = _sut.OnGoingQuest.ProgressBar.Value;

			// Act
			_sut.ContinueQuest();
			Thread.Sleep(150);
			float continuedProgressBarValue = _sut.OnGoingQuest.ProgressBar.Value;

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(continuedProgressBarValue, Is.GreaterThan(initialProgressBarValue), "Quest continue did not resume the timer");
				Assert.That(_sut.Status, Is.EqualTo(QuestStatus.OnGoing), "Quest status is not OnGoing");
			});
		}

		[TestCase(1)]
		[TestCase(2)]
		public void Should_ResetQuest_When_Prompted(int questLevel)
		{
			// Arrange
			_sut = new Quest(_dataSource.GetAllQuestInfos().First(_ => _.Stats.Level == questLevel));
			Stats comparedStats = GetStatsScaledByLevel(questLevel);
			_sut.StartQuest(comparedStats);

			// Act
			_sut.ResetQuest();
			float resetProgressBarValue = _sut.OnGoingQuest.ProgressBar.Value;

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(resetProgressBarValue, Is.EqualTo(0.0f), "Quest reset did not reset the progress bar");
				Assert.That(_sut.Status, Is.EqualTo(QuestStatus.None), "Quest status did not reset");
			});
		}

		[TestCase(1)]
		[TestCase(2)]
		public void Should_BeCompleted_When_WaitedLongEnough(int questLevel)
		{
			// Arrange
			_sut = new Quest(_dataSource.GetAllQuestInfos().First(_ => _.Stats.Level == questLevel));
			_sut.QuestInfo.TotalChancesForLoot = 5;
			Stats comparedStats = GetStatsScaledByLevel(questLevel);
			_sut.StartQuest(comparedStats);
			int finalQuestLengthInSeconds = _sut.OnGoingQuest.FinalQuestLengthInSeconds;

			// Act
			IncrementForSimulatedSeconds(finalQuestLengthInSeconds);
			var result = _sut.IsQuestCompleted();

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(result, Is.True, "Quest did not complete properly when enough time lapsed was not properly added to loot collection");
				//Assert.That(_sut.Status, Is.EqualTo(QuestStatus.Completed), "Quest status is not Completed");
			});
		}

		[TestCase(1)]
		[TestCase(2)]
		public void Should_BeNotCompleted_When_WaitingLessThanTheFullLength(int questLevel)
		{
			// Arrange
			_sut = new Quest(_dataSource.GetAllQuestInfos().First(_ => _.Stats.Level == questLevel));
			_sut.QuestInfo.TotalChancesForLoot = 5;
			Stats comparedStats = GetStatsScaledByLevel(questLevel);
			_sut.StartQuest(comparedStats);
			int finalQuestLengthInSeconds = _sut.OnGoingQuest.FinalQuestLengthInSeconds;

			// Act
			IncrementForSimulatedSeconds(finalQuestLengthInSeconds / 2);
			var result = _sut.IsQuestCompleted();

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(result, Is.False, "Quest did completed despite not waiting enough time");
				Assert.That(_sut.Status, Is.EqualTo(QuestStatus.OnGoing), "Quest status is not OnGoing");
			});
		}

		[TestCase(1)]
		[TestCase(2)]
		public void Should_BeOnGoing_When_InTheMiddleOfAQuest(int questLevel)
		{
			// Arrange
			_sut = new Quest(_dataSource.GetAllQuestInfos().First(_ => _.Stats.Level == questLevel));
			_sut.QuestInfo.TotalChancesForLoot = 5;
			Stats comparedStats = GetStatsScaledByLevel(questLevel);
			_sut.StartQuest(comparedStats);
			int finalQuestLengthInSeconds = _sut.OnGoingQuest.FinalQuestLengthInSeconds;

			// Act
			IncrementForSimulatedSeconds(finalQuestLengthInSeconds / 2);
			var result = _sut.IsQuestOnGoing();

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(result, Is.True, "Quest completed despite not waiting enough time");
				Assert.That(_sut.Status, Is.EqualTo(QuestStatus.OnGoing), "Quest status is not OnGoing");
			});
		}

		[TestCase(1, true)]
		[TestCase(1, false)]
		public void Should_IndicateRareLoot_When_Prompted(int questLevel, bool expectedRare)
		{
			// Arrange
			_sut = new Quest(_dataSource.GetAllQuestInfos().First(_ => _.Stats.Level == questLevel));
			_sut.QuestInfo.TotalChancesForLoot = 5;
			_sut.QuestInfo.ChanceForRareLoot = (expectedRare) ? 1000 : 0;
			Stats comparedStats = GetStatsScaledByLevel(questLevel);
			_sut.StartQuest(comparedStats);
			int finalQuestLengthInSeconds = _sut.OnGoingQuest.FinalQuestLengthInSeconds;

			// Act
			IncrementForSimulatedSeconds(60);
			_sut.QuestTimerElapsed(null, null);
			_sut.AttemptLootChance();
			var result = _sut.IsLastLootRare();

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(result, Is.EqualTo(expectedRare), "Quest did not indicate whether or not loot was rare when it should have.");
			});
		}

		[TestCase(1, 1000, 0, 100)]
		[TestCase(1, 0, 1000, 100)]
		[TestCase(1, 500, 500, 100)]
		public void Should_RandomlyReturnEquipment_When_Prompted(int questLevel, int chanceForNormalLoot, int chanceForRareLoot, int totalLoot)
		{
			// Arrange
			List<IEquipment?> loot = new List<IEquipment?>();
			_sut = new Quest(_dataSource.GetAllQuestInfos().First(_ => _.Stats.Level == questLevel));
			_sut.QuestInfo.ChanceForNormalLoot = chanceForNormalLoot;
			_sut.QuestInfo.ChanceForRareLoot = chanceForRareLoot;

			// Act
			for (int i = 0; i < totalLoot; i++)
			{
				loot.Add(_sut.RollDiceForLoot());
			}
			var amountOfNormalLoot = loot.FindAll(_ => _sut.QuestInfo.NormalLoot.Contains(_)).Sum(_ => 1);
			var amountOfRareLoot = loot.FindAll(_ => _sut.QuestInfo.RareLoot == _).Sum(_ => 1);

			var expectedNormalLoot = (chanceForNormalLoot >= 500) ? 1 : 0;
			var expectedRareLoot = (chanceForRareLoot >= 500) ? 1 : 0;

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(loot.Count, Is.EqualTo(totalLoot), "Randomly returned loot did return expected amount of loot");
				Assert.That(amountOfNormalLoot, Is.GreaterThanOrEqualTo(expectedNormalLoot), "Randomly returned loot did return expected amount of Normal loot");
				Assert.That(amountOfRareLoot, Is.GreaterThanOrEqualTo(expectedRareLoot), "Randomly returned loot did return expected amount of Rare loot");
				Assert.That(amountOfNormalLoot + amountOfRareLoot, Is.GreaterThan(0), "Randomly returned loot was not an expected mixture");
			});
		}

		private Stats GetStatsScaledByLevel(int level)
		{
			Stats stats = new()
			{
				Level = 2 * level,
				PhysicalAttack = 2 * level,
				PhysicalDefense = 2 * level,
				MagicalAttack = 2 * level,
				MagicalDefense = 2 * level,
				Speed = 2 * level,
				FireAttack = 2 * level,
				FireDefense = 2 * level,
				IceAttack = 2 * level,
				IceDefense = 2 * level,
				LightningAttack = 2 * level,
				LightningDefense = 2 * level,
				EarthAttack = 2 * level,
				EarthDefense = 2 * level,
			};

			return stats;
		}

		private void IncrementForSimulatedSeconds(int seconds)
		{
			int numberOfTicksPerSecond = (int)(_sut.OnGoingQuest.ProgressBar.ValueMax / _sut.OnGoingQuest.ProgressBar.IncrementTickRateInMs);
			int totalNumberOfTicks = seconds * numberOfTicksPerSecond;

			for (int i = 0; i < totalNumberOfTicks; i++)
			{
				_sut.OnGoingQuest.ProgressBar.IncrementProgressBar();
			}
		}
	}
}
