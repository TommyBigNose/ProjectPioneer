using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Character;
using ProjectPioneer.Systems.Data;
using ProjectPioneer.Systems.Equipment;
using ProjectPioneer.Systems.Statistics;

namespace ProjectPioneer.Tests.Systems.Character
{
	[TestFixture]
	public class HeroTests
	{
		private IDataSource _dataSource;
		private IHero _sut;

		[SetUp]
		public void SetUp()
		{
			_dataSource = new LocalDataSource();
			//_sut = new Hero();
		}

		[TearDown]
		public void TearDown()
		{

		}

		[TestCase(1, "Vanguard", "Reinforced Skin")]
		[TestCase(5, "Vanguard", "Reinforced Skin")]
		[TestCase(1, "Ranger", "Reinforced Joints")]
		[TestCase(5, "Ranger", "Reinforced Joints")]
		[TestCase(1, "Technician", "Focus Injector")]
		[TestCase(5, "Technician", "Focus Injector")]
		public void Should_HaveUpgradedStats_When_LeveledUp(int levelUpCount, string jobName, string implantName)
		{
			// Arrange
			IJob job = _dataSource.GetAllJobs().First(_=>_.Name.Equals(jobName));
			IImplant implant = _dataSource.GetAllImplants().First(_ => _.Name.Equals(implantName));
			_sut = new Hero("Test", job, implant, new Stats());
			Stats initialStats = new Stats(_sut.Stats);

			// Act
			for (int i = 0; i < levelUpCount; i++)
			{
				_sut.LevelUp();
			}
			Stats resultingStats = new Stats(_sut.Stats);

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(resultingStats.Level, Is.EqualTo(initialStats.Level + levelUpCount), "Hero did not upgrade Level");

				Assert.That(resultingStats.PhysicalAttack, 
					Is.EqualTo(initialStats.PhysicalAttack + levelUpCount + (job.Stats.PhysicalAttack * levelUpCount) + (implant.Stats.PhysicalAttack * levelUpCount)), 
					"Hero did not upgrade PhysicalAttack");

				Assert.That(resultingStats.PhysicalDefense,
					Is.EqualTo(initialStats.PhysicalDefense + levelUpCount + (job.Stats.PhysicalDefense * levelUpCount) + (implant.Stats.PhysicalDefense * levelUpCount)),
					"Hero did not upgrade PhysicalDefense");

				Assert.That(resultingStats.MagicalAttack,
					Is.EqualTo(initialStats.MagicalAttack + levelUpCount + (job.Stats.MagicalAttack * levelUpCount) + (implant.Stats.MagicalAttack * levelUpCount)),
					"Hero did not upgrade MagicalAttack");

				Assert.That(resultingStats.MagicalDefense,
					Is.EqualTo(initialStats.MagicalDefense + levelUpCount + (job.Stats.MagicalDefense * levelUpCount) + (implant.Stats.MagicalDefense * levelUpCount)),
					"Hero did not upgrade MagicalDefense");

				Assert.That(resultingStats.Speed,
					Is.EqualTo(initialStats.Speed + levelUpCount + (job.Stats.Speed * levelUpCount) + (implant.Stats.Speed * levelUpCount)),
					"Hero did not upgrade Speed");
			});
		}

		[TestCase("Vanguard", WeaponType.Gun)]
		[TestCase("Ranger", WeaponType.Staff)]
		[TestCase("Technician", WeaponType.Blade)]
		public void Should_NotBeAbleToEquipWeapon_When_JobCannot(string jobName, WeaponType weaponType)
		{
			// Arrange
			IJob job = _dataSource.GetAllJobs().First(_ => _.Name.Equals(jobName));
			IImplant implant = new Implant("Test", "Test", new Stats());
			_sut = new Hero("Test", job, implant, new Stats());
			IWeapon weapon = _dataSource.GetAllWeapons().First(_ => _.WeaponType == weaponType);

			// Act
			var result = _sut.CanEquipWeapon(weapon);

			// Assert
			Assert.That(result, Is.False, "Hero was allowed to equip a weapon that its job didn't allow");
		}
	}
}
