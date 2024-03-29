﻿namespace ProjectPioneer.Systems.Character
{
	public class Hero : IHero
	{
		private readonly string _name = string.Empty;
		public string Name => _name;

		private int _exp;
		public int Exp => _exp;

		private readonly IJob _job;
		public IJob Job => _job;

		private readonly IImplant _implant;
		public IImplant Implant => _implant;

		private IEquipment _equippedWeapon;
		public IEquipment EquippedWeapon => _equippedWeapon;

		private IEquipment _equippedArmor;
		public IEquipment EquippedArmor => _equippedArmor;

		private IEquipment _equippedAura;
		public IEquipment EquippedAura => _equippedAura;

		private readonly Stats _stats;
		public Stats Stats => _stats;

		public Hero(string name, int exp, IJob job, IImplant implant, Stats stats, IEquipment weapon, IEquipment armor, IEquipment aura)
		{
			_name = name;
			_exp = exp;
			_job = job;
			_implant = implant;
			_stats = stats;
			_equippedWeapon = weapon;
			_equippedArmor = armor;
			_equippedAura = aura;
		}

		#region IHero

		public void AddExp(int exp)
		{
			_exp += exp;
		}

		public int GetRequiredExp()
		{
			return _stats.Level * Constants.HeroLevelExpScaling;
		}

		public void LevelUp()
		{
			if (CanLevelUp())
			{
				_exp -= GetRequiredExp();
				_stats.Level++;
				_stats.PhysicalAttack += 1 + _job.Stats.PhysicalAttack + _implant.Stats.PhysicalAttack;
				_stats.PhysicalDefense += 1 + _job.Stats.PhysicalDefense + _implant.Stats.PhysicalDefense;
				_stats.MagicalAttack += 1 + _job.Stats.MagicalAttack + _implant.Stats.MagicalAttack;
				_stats.MagicalDefense += 1 + _job.Stats.MagicalDefense + _implant.Stats.MagicalDefense;
				_stats.Speed += 1 + _job.Stats.Speed + _implant.Stats.Speed;
			}
		}

		public bool CanLevelUp()
		{
			return Exp >= GetRequiredExp();
		}


		public bool CanEquip(IEquipment equipment)
		{
			return _job.EquipableTypes.Contains(equipment.EquipmentType);
		}

		public IEquipment EquipWeaponAndReturnOldWeapon(IEquipment weapon)
		{
			var oldWeapon = EquippedWeapon;
			_equippedWeapon = weapon;
			return oldWeapon;
		}

		public IEquipment EquipArmorAndReturnOldArmor(IEquipment armor)
		{
			var oldArmor = EquippedArmor;
			_equippedArmor = armor;
			return oldArmor;
		}


		public IEquipment EquipAuraAndReturnOldAura(IEquipment aura)
		{
			var oldAura = EquippedAura;
			_equippedAura = aura;
			return oldAura;
		}
		#endregion

		#region ICalculableStats
		public int GetLevel()
		{
			return _stats.Level;
		}

		public int GetBasePhysicalAttack()
		{
			return _stats.PhysicalAttack +
				Job.Stats.PhysicalAttack +
				Implant.Stats.PhysicalAttack;
		}

		public int GetBasePhysicalDefense()
		{
			return _stats.PhysicalDefense +
				Job.Stats.PhysicalDefense +
				Implant.Stats.PhysicalDefense;
		}

		public int GetBaseMagicalAttack()
		{
			return _stats.MagicalAttack +
				Job.Stats.MagicalAttack +
				Implant.Stats.MagicalAttack;
		}

		public int GetBaseMagicalDefense()
		{
			return _stats.MagicalDefense +
				Job.Stats.MagicalDefense +
				Implant.Stats.MagicalDefense;
		}

		public int GetBaseSpeed()
		{
			return _stats.Speed +
				Job.Stats.Speed +
				Implant.Stats.Speed;
		}

		public int GetBaseFireAttack()
		{
			return _stats.FireAttack +
				Job.Stats.FireAttack +
				Implant.Stats.FireAttack;
		}

		public int GetBaseFireDefense()
		{
			return _stats.FireDefense +
				Job.Stats.FireDefense +
				Implant.Stats.FireDefense;
		}

		public int GetBaseIceAttack()
		{
			return _stats.IceAttack +
				Job.Stats.IceAttack +
				Implant.Stats.IceAttack;
		}

		public int GetBaseIceDefense()
		{
			return _stats.IceDefense +
				Job.Stats.IceDefense +
				Implant.Stats.IceDefense;
		}

		public int GetBaseLightningAttack()
		{
			return _stats.LightningAttack +
				Job.Stats.LightningAttack +
				Implant.Stats.LightningAttack;
		}

		public int GetBaseLightningDefense()
		{
			return _stats.LightningDefense +
				Job.Stats.LightningDefense +
				Implant.Stats.LightningDefense;
		}

		public int GetBaseEarthAttack()
		{
			return _stats.EarthAttack +
				Job.Stats.EarthAttack +
				Implant.Stats.EarthAttack;
		}

		public int GetBaseEarthDefense()
		{
			return _stats.EarthDefense +
				Job.Stats.EarthDefense +
				Implant.Stats.EarthDefense;
		}

		public int GetTotalPhysicalAttack()
		{
			return GetBasePhysicalAttack() +
				_equippedWeapon.Stats.PhysicalAttack +
				_equippedArmor.Stats.PhysicalAttack +
				_equippedAura.Stats.PhysicalAttack;
		}

		public int GetTotalPhysicalDefense()
		{
			return GetBasePhysicalDefense() +
				_equippedWeapon.Stats.PhysicalDefense +
				_equippedArmor.Stats.PhysicalDefense +
				_equippedAura.Stats.PhysicalDefense;
		}

		public int GetTotalMagicalAttack()
		{
			return GetBaseMagicalAttack() +
				_equippedWeapon.Stats.MagicalAttack +
				_equippedArmor.Stats.MagicalAttack +
				_equippedAura.Stats.MagicalAttack;
		}

		public int GetTotalMagicalDefense()
		{
			return GetBaseMagicalDefense() +
				_equippedWeapon.Stats.MagicalDefense +
				_equippedArmor.Stats.MagicalDefense +
				_equippedAura.Stats.MagicalDefense;
		}

		public int GetTotalSpeed()
		{
			return GetBaseSpeed() +
				_equippedWeapon.Stats.Speed +
				_equippedArmor.Stats.Speed +
				_equippedAura.Stats.Speed;
		}

		public int GetTotalFireAttack()
		{
			return GetBaseFireAttack() +
				_equippedWeapon.Stats.FireAttack +
				_equippedArmor.Stats.FireAttack +
				_equippedAura.Stats.FireAttack;
		}

		public int GetTotalFireDefense()
		{
			return GetBaseFireDefense() +
				_equippedWeapon.Stats.FireDefense +
				_equippedArmor.Stats.FireDefense +
				_equippedAura.Stats.FireDefense;
		}

		public int GetTotalIceAttack()
		{
			return GetBaseIceAttack() +
				_equippedWeapon.Stats.IceAttack +
				_equippedArmor.Stats.IceAttack +
				_equippedAura.Stats.IceAttack;
		}

		public int GetTotalIceDefense()
		{
			return GetBaseIceDefense() +
				_equippedWeapon.Stats.IceDefense +
				_equippedArmor.Stats.IceDefense +
				_equippedAura.Stats.IceDefense;
		}

		public int GetTotalLightningAttack()
		{
			return GetBaseLightningAttack() +
				_equippedWeapon.Stats.LightningAttack +
				_equippedArmor.Stats.LightningAttack +
				_equippedAura.Stats.LightningAttack;
		}

		public int GetTotalLightningDefense()
		{
			return GetBaseLightningDefense() +
				_equippedWeapon.Stats.LightningDefense +
				_equippedArmor.Stats.LightningDefense +
				_equippedAura.Stats.LightningDefense;
		}

		public int GetTotalEarthAttack()
		{
			return GetBaseEarthAttack() +
				_equippedWeapon.Stats.EarthAttack +
				_equippedArmor.Stats.EarthAttack +
				_equippedAura.Stats.EarthAttack;
		}

		public int GetTotalEarthDefense()
		{
			return GetBaseEarthDefense() +
				_equippedWeapon.Stats.EarthDefense +
				_equippedArmor.Stats.EarthDefense +
				_equippedAura.Stats.EarthDefense;
		}

		public Stats GetTotalsAsStats()
		{
			var stats = new Stats
			{
				Level = GetLevel(),
				PhysicalAttack = GetTotalPhysicalAttack(),
				PhysicalDefense = GetTotalPhysicalDefense(),
				MagicalAttack = GetTotalMagicalAttack(),
				MagicalDefense = GetTotalMagicalDefense(),
				Speed = GetTotalSpeed(),
				FireAttack = GetTotalFireAttack(),
				FireDefense = GetTotalFireDefense(),
				IceAttack = GetTotalIceAttack(),
				IceDefense = GetTotalIceDefense(),
				LightningAttack = GetTotalLightningAttack(),
				LightningDefense = GetTotalLightningDefense(),
				EarthAttack = GetTotalEarthAttack(),
				EarthDefense = GetTotalEarthDefense(),
			};

			return stats;
		}
		#endregion
	}
}
