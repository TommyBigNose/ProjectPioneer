using ProjectPioneer.Systems;
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
			_dataSource = new MemoryDataSource();
			//_sut = new Hero();
		}

		[TearDown]
		public void TearDown()
		{

		}

		[TestCase(0, 100)]
		[TestCase(50, 100)]
		public void Should_GetExp_When_Prompted(int initialExp, int addedExp)
		{
			// Arrange
			_sut = GetTestHero();
			_sut.AddExp(initialExp);

			// Act
			_sut.AddExp(addedExp);

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(_sut.Exp, Is.EqualTo(initialExp + addedExp), "Hero did not add exp as expected");
			});
		}

		[Test]
		public void Should_GetRequiredExpIsBasedOnlevel_When_Prompted()
		{
			// Arrange
			_sut = GetTestHero();
			_sut.AddExp(10000);
			int initialRequiredExp = _sut.GetRequiredExp();

			// Act
			_sut.Stats.Level++;
			int finalRequiredExp = _sut.GetRequiredExp();

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(finalRequiredExp, Is.GreaterThan(initialRequiredExp), "Hero did increase in required exp as expected");
			});
		}

		[TestCase(0)]
		[TestCase(10)]
		[TestCase(10000)]
		public void Should_BeAbleToLevelUp_When_ThereIsEnoughExp(int expToAdd)
		{
			// Arrange
			_sut = GetTestHero();
			_sut.AddExp(expToAdd);
			bool expected = expToAdd >= _sut.GetRequiredExp();

			// Act
			var result = _sut.CanLevelUp();

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(result, Is.EqualTo(expected), "Hero's expected ");
			});
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
			IJob job = _dataSource.GetAllJobs().First(_ => _.Name.Equals(jobName));
			IImplant implant = _dataSource.GetAllImplants().First(_ => _.Name.Equals(implantName));
			IEquipment weapon = _dataSource.GetDefaultWeapon();
			IEquipment armor = _dataSource.GetDefaultArmor();
			IEquipment aura = _dataSource.GetDefaultAura();
			_sut = new Hero("Test", 10000, job, implant, new Stats(), weapon, armor, aura);
			Stats initialStats = new Stats(_sut.Stats);

			// Act
			for (int i = 0; i < levelUpCount; i++)
			{
				_sut.LevelUp();
			}
			Stats resultingStats = new Stats(_sut.Stats);
			int requiredExp = _sut.GetRequiredExp();

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(_sut.Exp, Is.LessThan(10000), "Hero current exp did not reduce upon leveling");
				Assert.That(requiredExp, Is.EqualTo(_sut.Stats.Level * Constants.HeroLevelExpScaling), "Hero required exp did not increase upon leveling");
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

		[TestCase("Vanguard", EquipmentType.Gun)]
		[TestCase("Ranger", EquipmentType.Staff)]
		[TestCase("Technician", EquipmentType.Blade)]
		public void Should_NotBeAbleToEquip_When_JobCannot(string jobName, EquipmentType weaponType)
		{
			// Arrange
			IJob job = _dataSource.GetAllJobs().First(_ => _.Name.Equals(jobName));
			IImplant implant = new Implant(999, "Test", "Test", new Stats());
			IEquipment defaultWeapon = _dataSource.GetDefaultWeapon();
			IEquipment defaultArmor = _dataSource.GetDefaultArmor();
			IEquipment defaultAura = _dataSource.GetDefaultAura();
			_sut = new Hero("Test", 0, job, implant, new Stats(), defaultWeapon, defaultArmor, defaultAura);
			IEquipment weapon = _dataSource.GetAllWeapons().First(_ => _.EquipmentType == weaponType);

			// Act
			var result = _sut.CanEquip(weapon);

			// Assert
			Assert.That(result, Is.False, "Hero was allowed to equip a weapon that its job didn't allow");
		}

		[Test]
		public void Should_ChangeEquippedWeapon_When_EquippingNewWeapon()
		{
			// Arrange
			_sut = GetTestHero();
			IEquipment weapon = _dataSource.GetAllWeapons().First();

			// Act
			var oldWeapon = _sut.EquipWeaponAndReturnOldWeapon(weapon);
			var equippedWeapon = _sut.EquippedWeapon;

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(equippedWeapon, Is.Not.EqualTo(oldWeapon), "Hero's EquippedWeapon is still the same as the old weapon");
				Assert.That(equippedWeapon, Is.EqualTo(weapon), "Hero's EquippedWeapon did not change");
			});
		}

		[Test]
		public void Should_ChangeEquippedArmor_When_EquippingNewArmor()
		{
			// Arrange
			_sut = GetTestHero();
			IEquipment armor = _dataSource.GetAllArmors().First();

			// Act
			var oldArmor = _sut.EquipArmorAndReturnOldArmor(armor);
			var equippedArmor = _sut.EquippedArmor;

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(equippedArmor, Is.Not.EqualTo(oldArmor), "Hero's EquippedArmor is still the same as the old armor");
				Assert.That(equippedArmor, Is.EqualTo(armor), "Hero's EquippedArmor did not change");
			});
		}

		[Test]
		public void Should_ChangeEquippedAura_When_EquippingNewAura()
		{
			// Arrange
			_sut = GetTestHero();
			IEquipment aura = _dataSource.GetAllAuras().First();

			// Act
			var oldAura = _sut.EquipAuraAndReturnOldAura(aura);
			var equippedAura = _sut.EquippedAura;

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(equippedAura, Is.Not.EqualTo(oldAura), "Hero's EquippedAura is still the same as the old aura");
				Assert.That(equippedAura, Is.EqualTo(aura), "Hero's EquippedAura did not change");
			});
		}

		[Test]
		public void Should_UpdateTotalStats_When_EquippingNewWeapon()
		{
			// Arrange
			_sut = GetTestHero();
			Stats oldStats = _sut.GetTotalsAsStats();
			IEquipment weapon = new Weapon(999, "Test", "Test", EquipmentType.None, new Stats()
			{
				Level = 1,
				PhysicalAttack = 1,
				PhysicalDefense = 2,
				MagicalAttack = 3,
				MagicalDefense = 4,
				Speed = 5,
				FireAttack = 6,
				FireDefense = 7,
				IceAttack = 8,
				IceDefense = 9,
				LightningAttack = 10,
				LightningDefense = 11,
				EarthAttack = 12,
				EarthDefense = 13,
			});

			// Act
			_sut.EquipWeaponAndReturnOldWeapon(weapon);
			Stats newStats = _sut.GetTotalsAsStats();

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(newStats.Level, Is.EqualTo(oldStats.Level), "Equipping weapon changed level");
				Assert.That(newStats.PhysicalAttack,
					Is.EqualTo(oldStats.PhysicalAttack + weapon.Stats.PhysicalAttack),
					"Equipping weapon did not alter PhysicalAttack");
				Assert.That(newStats.PhysicalDefense,
					Is.EqualTo(oldStats.PhysicalDefense + weapon.Stats.PhysicalDefense),
					"Equipping weapon did not alter PhysicalAttack");
				Assert.That(newStats.MagicalAttack,
					Is.EqualTo(oldStats.MagicalAttack + weapon.Stats.MagicalAttack),
					"Equipping weapon did not alter MagicalAttack");
				Assert.That(newStats.MagicalDefense,
					Is.EqualTo(oldStats.MagicalDefense + weapon.Stats.MagicalDefense),
					"Equipping weapon did not alter MagicalDefense");
				Assert.That(newStats.Speed,
					Is.EqualTo(oldStats.Speed + weapon.Stats.Speed),
					"Equipping weapon did not alter Speed");
				Assert.That(newStats.FireAttack,
					Is.EqualTo(oldStats.FireAttack + weapon.Stats.FireAttack),
					"Equipping weapon did not alter FireAttack");
				Assert.That(newStats.FireDefense,
					Is.EqualTo(oldStats.FireDefense + weapon.Stats.FireDefense),
					"Equipping weapon did not alter FireDefense");
				Assert.That(newStats.IceAttack,
					Is.EqualTo(oldStats.IceAttack + weapon.Stats.IceAttack),
					"Equipping weapon did not alter IceAttack");
				Assert.That(newStats.IceDefense,
					Is.EqualTo(oldStats.IceDefense + weapon.Stats.IceDefense),
					"Equipping weapon did not alter IceDefense");
				Assert.That(newStats.LightningAttack,
					Is.EqualTo(oldStats.LightningAttack + weapon.Stats.LightningAttack),
					"Equipping weapon did not alter LightningAttack");
				Assert.That(newStats.LightningDefense,
					Is.EqualTo(oldStats.LightningDefense + weapon.Stats.LightningDefense),
					"Equipping weapon did not alter LightningDefense");
				Assert.That(newStats.EarthAttack,
					Is.EqualTo(oldStats.EarthAttack + weapon.Stats.EarthAttack),
					"Equipping weapon did not alter EarthAttack");
				Assert.That(newStats.EarthDefense,
					Is.EqualTo(oldStats.EarthDefense + weapon.Stats.EarthDefense),
					"Equipping weapon did not alter EarthDefense");
			});
		}

		[Test]
		public void Should_UpdateTotalStats_When_EquippingNewArmor()
		{
			// Arrange
			_sut = GetTestHero();
			Stats oldStats = _sut.GetTotalsAsStats();
			IEquipment armor = new Armor(999, "Test", "Test", EquipmentType.Armor, new Stats()
			{
				Level = 1,
				PhysicalAttack = 1,
				PhysicalDefense = 2,
				MagicalAttack = 3,
				MagicalDefense = 4,
				Speed = 5,
				FireAttack = 6,
				FireDefense = 7,
				IceAttack = 8,
				IceDefense = 9,
				LightningAttack = 10,
				LightningDefense = 11,
				EarthAttack = 12,
				EarthDefense = 13,
			});

			// Act
			_sut.EquipArmorAndReturnOldArmor(armor);
			Stats newStats = _sut.GetTotalsAsStats();

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(newStats.Level, Is.EqualTo(oldStats.Level), "Equipping armor changed level");
				Assert.That(newStats.PhysicalAttack,
					Is.EqualTo(oldStats.PhysicalAttack + armor.Stats.PhysicalAttack),
					"Equipping armor did not alter PhysicalAttack");
				Assert.That(newStats.PhysicalDefense,
					Is.EqualTo(oldStats.PhysicalDefense + armor.Stats.PhysicalDefense),
					"Equipping armor did not alter PhysicalAttack");
				Assert.That(newStats.MagicalAttack,
					Is.EqualTo(oldStats.MagicalAttack + armor.Stats.MagicalAttack),
					"Equipping armor did not alter MagicalAttack");
				Assert.That(newStats.MagicalDefense,
					Is.EqualTo(oldStats.MagicalDefense + armor.Stats.MagicalDefense),
					"Equipping armor did not alter MagicalDefense");
				Assert.That(newStats.Speed,
					Is.EqualTo(oldStats.Speed + armor.Stats.Speed),
					"Equipping armor did not alter Speed");
				Assert.That(newStats.FireAttack,
					Is.EqualTo(oldStats.FireAttack + armor.Stats.FireAttack),
					"Equipping armor did not alter FireAttack");
				Assert.That(newStats.FireDefense,
					Is.EqualTo(oldStats.FireDefense + armor.Stats.FireDefense),
					"Equipping armor did not alter FireDefense");
				Assert.That(newStats.IceAttack,
					Is.EqualTo(oldStats.IceAttack + armor.Stats.IceAttack),
					"Equipping armor did not alter IceAttack");
				Assert.That(newStats.IceDefense,
					Is.EqualTo(oldStats.IceDefense + armor.Stats.IceDefense),
					"Equipping armor did not alter IceDefense");
				Assert.That(newStats.LightningAttack,
					Is.EqualTo(oldStats.LightningAttack + armor.Stats.LightningAttack),
					"Equipping armor did not alter LightningAttack");
				Assert.That(newStats.LightningDefense,
					Is.EqualTo(oldStats.LightningDefense + armor.Stats.LightningDefense),
					"Equipping armor did not alter LightningDefense");
				Assert.That(newStats.EarthAttack,
					Is.EqualTo(oldStats.EarthAttack + armor.Stats.EarthAttack),
					"Equipping armor did not alter EarthAttack");
				Assert.That(newStats.EarthDefense,
					Is.EqualTo(oldStats.EarthDefense + armor.Stats.EarthDefense),
					"Equipping armor did not alter EarthDefense");
			});
		}

		[Test]
		public void Should_UpdateTotalStats_When_EquippingNewAura()
		{
			// Arrange
			_sut = GetTestHero();
			Stats oldStats = _sut.GetTotalsAsStats();
			IEquipment aura = new Aura(999, "Test", "Test", EquipmentType.Aura, new Stats()
			{
				Level = 1,
				PhysicalAttack = 1,
				PhysicalDefense = 2,
				MagicalAttack = 3,
				MagicalDefense = 4,
				Speed = 5,
				FireAttack = 6,
				FireDefense = 7,
				IceAttack = 8,
				IceDefense = 9,
				LightningAttack = 10,
				LightningDefense = 11,
				EarthAttack = 12,
				EarthDefense = 13,
			});

			// Act
			_sut.EquipAuraAndReturnOldAura(aura);
			Stats newStats = _sut.GetTotalsAsStats();

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(newStats.Level, Is.EqualTo(oldStats.Level), "Equipping aura changed level");
				Assert.That(newStats.PhysicalAttack,
					Is.EqualTo(oldStats.PhysicalAttack + aura.Stats.PhysicalAttack),
					"Equipping aura did not alter PhysicalAttack");
				Assert.That(newStats.PhysicalDefense,
					Is.EqualTo(oldStats.PhysicalDefense + aura.Stats.PhysicalDefense),
					"Equipping aura did not alter PhysicalAttack");
				Assert.That(newStats.MagicalAttack,
					Is.EqualTo(oldStats.MagicalAttack + aura.Stats.MagicalAttack),
					"Equipping aura did not alter MagicalAttack");
				Assert.That(newStats.MagicalDefense,
					Is.EqualTo(oldStats.MagicalDefense + aura.Stats.MagicalDefense),
					"Equipping aura did not alter MagicalDefense");
				Assert.That(newStats.Speed,
					Is.EqualTo(oldStats.Speed + aura.Stats.Speed),
					"Equipping aura did not alter Speed");
				Assert.That(newStats.FireAttack,
					Is.EqualTo(oldStats.FireAttack + aura.Stats.FireAttack),
					"Equipping aura did not alter FireAttack");
				Assert.That(newStats.FireDefense,
					Is.EqualTo(oldStats.FireDefense + aura.Stats.FireDefense),
					"Equipping aura did not alter FireDefense");
				Assert.That(newStats.IceAttack,
					Is.EqualTo(oldStats.IceAttack + aura.Stats.IceAttack),
					"Equipping aura did not alter IceAttack");
				Assert.That(newStats.IceDefense,
					Is.EqualTo(oldStats.IceDefense + aura.Stats.IceDefense),
					"Equipping aura did not alter IceDefense");
				Assert.That(newStats.LightningAttack,
					Is.EqualTo(oldStats.LightningAttack + aura.Stats.LightningAttack),
					"Equipping aura did not alter LightningAttack");
				Assert.That(newStats.LightningDefense,
					Is.EqualTo(oldStats.LightningDefense + aura.Stats.LightningDefense),
					"Equipping aura did not alter LightningDefense");
				Assert.That(newStats.EarthAttack,
					Is.EqualTo(oldStats.EarthAttack + aura.Stats.EarthAttack),
					"Equipping aura did not alter EarthAttack");
				Assert.That(newStats.EarthDefense,
					Is.EqualTo(oldStats.EarthDefense + aura.Stats.EarthDefense),
					"Equipping aura did not alter EarthDefense");
			});
		}

		private IHero GetTestHero()
		{
			IJob job = _dataSource.GetAllJobs().First();
			IImplant implant = _dataSource.GetAllImplants().First();
			IEquipment defaultWeapon = _dataSource.GetDefaultWeapon();
			IEquipment defaultArmor = _dataSource.GetDefaultArmor();
			IEquipment defaultAura = _dataSource.GetDefaultAura();
			return new Hero("Test Hero", 0, job, implant, new Stats(), defaultWeapon, defaultArmor, defaultAura);
		}
	}
}
