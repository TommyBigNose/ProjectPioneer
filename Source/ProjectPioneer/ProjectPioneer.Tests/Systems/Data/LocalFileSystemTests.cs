namespace ProjectPioneer.Tests.Systems.Data
{
	[TestFixture]
	public class LocalFileSystemTests
	{
		private readonly string _SaveDataFullFilePath = Path.Combine(Directory.GetCurrentDirectory(), "ProjectPioneerSaveData.json");

		private IDataSource _dataSource;
		private IHeroBuilder _heroBuilder;
		private IInventory _inventory;
		private IQuestLog _questLog;
		private SaveData _saveData;
		private ISaveDataReader _saveDataReader;

		private IFileSystem _sut;

		[SetUp]
		public void SetUp()
		{
			_dataSource = new MemoryDataSource();
			_heroBuilder = new HeroBuilder(_dataSource);
			_inventory = new Inventory();
			_questLog = new QuestLog();
			_saveData = new SaveData()
			{
				Hero = _heroBuilder.CreateHero("", _dataSource.GetAllJobs().First(), _dataSource.GetAllImplants().First()),
				Inventory = _inventory,
				QuestLog = _questLog
			};

			_saveDataReader = new JsonSaveDataReader(_dataSource);

			_sut = new LocalFileSystem(_saveDataReader);
		}

		[TearDown]
		public void TearDown()
		{
			if (File.Exists(_SaveDataFullFilePath))
			{
				File.Delete(_SaveDataFullFilePath);
			}
		}

		[Test]
		public void Should_CreateFile_When_Saving()
		{
			// Arrange
			IHero hero = _heroBuilder.CreateHero("TestHeroName", _dataSource.GetAllJobs().First(), _dataSource.GetAllImplants().First());

			_saveData.Hero = hero;

			// Inventory
			_dataSource.GetAllEquipment().ToList().ForEach(_ => _inventory.AddEquipment(_));
			_inventory.AddCredits(9999);

			// QuestLog
			_dataSource.GetAllQuests().ToList().ForEach(_ => _questLog.CompleteQuest(_));

			// Act
			_sut.SaveGame(_saveData);

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(File.Exists(_SaveDataFullFilePath), Is.True, "LocalFileSystem did not create a save file");
			});
		}

		[Test]
		public void Should_GenerateMatchingSaveData_When_LoadingASavedFile()
		{
			// Arrange
			IHero hero = _heroBuilder.CreateHero("TestHeroName", _dataSource.GetAllJobs().First(), _dataSource.GetAllImplants().First());

			_saveData.Hero = hero;

			// Inventory
			_dataSource.GetAllEquipment().ToList().ForEach(_ => _inventory.AddEquipment(_));
			_inventory.AddCredits(9999);

			// QuestLog
			_dataSource.GetAllQuests().ToList().ForEach(_ => _questLog.CompleteQuest(_));

			_sut.SaveGame(_saveData);

			// Act
			var result = _sut.LoadGame();

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(result.Hero.Name, Is.EqualTo(_saveData.Hero.Name), "LocalFileSystem loaded a mismatching Hero's Name");
				Assert.That(result.Hero.Stats.Level, Is.EqualTo(_saveData.Hero.Stats.Level), "LocalFileSystem loaded a mismatching Hero's Level");
				Assert.That(result.Hero.Stats.PhysicalAttack, Is.EqualTo(_saveData.Hero.Stats.PhysicalAttack), "LocalFileSystem loaded a mismatching Hero's PhysicalAttack");
				Assert.That(result.Hero.Stats.PhysicalDefense, Is.EqualTo(_saveData.Hero.Stats.PhysicalDefense), "LocalFileSystem loaded a mismatching Hero's PhysicalDefense");
				Assert.That(result.Hero.Stats.MagicalAttack, Is.EqualTo(_saveData.Hero.Stats.MagicalAttack), "LocalFileSystem loaded a mismatching Hero's MagicalAttack");
				Assert.That(result.Hero.Stats.MagicalDefense, Is.EqualTo(_saveData.Hero.Stats.MagicalDefense), "LocalFileSystem loaded a mismatching Hero's MagicalDefense");
				Assert.That(result.Hero.Stats.Speed, Is.EqualTo(_saveData.Hero.Stats.Speed), "LocalFileSystem loaded a mismatching Hero's Speed");

				Assert.That(result.Hero.Stats.FireAttack, Is.EqualTo(_saveData.Hero.Stats.FireAttack), "LocalFileSystem loaded a mismatching Hero's FireAttack");
				Assert.That(result.Hero.Stats.FireDefense, Is.EqualTo(_saveData.Hero.Stats.FireDefense), "LocalFileSystem loaded a mismatching Hero's FireDefense");
				Assert.That(result.Hero.Stats.IceAttack, Is.EqualTo(_saveData.Hero.Stats.IceAttack), "LocalFileSystem loaded a mismatching Hero's IceAttack");
				Assert.That(result.Hero.Stats.IceDefense, Is.EqualTo(_saveData.Hero.Stats.IceDefense), "LocalFileSystem loaded a mismatching Hero's IceDefense");
				Assert.That(result.Hero.Stats.LightningAttack, Is.EqualTo(_saveData.Hero.Stats.LightningAttack), "LocalFileSystem loaded a mismatching Hero's LightningAttack");
				Assert.That(result.Hero.Stats.LightningDefense, Is.EqualTo(_saveData.Hero.Stats.LightningDefense), "LocalFileSystem loaded a mismatching Hero's LightningDefense");
				Assert.That(result.Hero.Stats.EarthAttack, Is.EqualTo(_saveData.Hero.Stats.EarthAttack), "LocalFileSystem loaded a mismatching Hero's EarthAttack");
				Assert.That(result.Hero.Stats.EarthDefense, Is.EqualTo(_saveData.Hero.Stats.EarthDefense), "LocalFileSystem loaded a mismatching Hero's EarthDefense");

				Assert.That(result.Inventory.HeroInventory.Count, Is.EqualTo(_saveData.Inventory.HeroInventory.Count), "LocalFileSystem loaded a mismatching HeroInventory count");
				Assert.That(result.Inventory.HeroInventory.Select(_ => _.ID).Except(_saveData.Inventory.HeroInventory.Select(_ => _.ID)).Any(), Is.False, "LocalFileSystem loaded a mismatching HeroInventory");

				Assert.That(result.QuestLog.CompletedQuests.Count, Is.EqualTo(_saveData.QuestLog.CompletedQuests.Count), "LocalFileSystem loaded a mismatching Completed QuestLog count");
				Assert.That(result.QuestLog.CompletedQuests.Except(_saveData.QuestLog.CompletedQuests).Any(), Is.False, "LocalFileSystem loaded a mismatching Completed QuestLog");
			});
		}
	}
}
