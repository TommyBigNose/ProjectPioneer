using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Statistics;

namespace ProjectPioneer.Systems.Character
{
	public class Hero : IHero
	{
		private readonly string _name = string.Empty;
		public string Name => _name;

		private readonly IJob _job;
		public IJob Job => _job;

		private readonly IImplant _implant;
		public IImplant Implant => _implant;
		
		private readonly Stats _stats;
		public Stats Stats => _stats;

		public Hero(string name, IJob job, IImplant implant, Stats stats)
		{
			_name = name;
			_job = job;
			_implant = implant;
			_stats = stats;
		}

		#region IHero
		public void LevelUp()
		{
			_stats.Level++;
			_stats.PhysicalAttack += _job.Stats.PhysicalAttack + _implant.Stats.PhysicalAttack;
			_stats.PhysicalDefense+= _job.Stats.PhysicalDefense + _implant.Stats.PhysicalDefense;
			_stats.MagicalAttack += _job.Stats.MagicalAttack + _implant.Stats.MagicalAttack;
			_stats.MagicalDefense += _job.Stats.MagicalDefense + _implant.Stats.MagicalDefense;
			_stats.Speed += _job.Stats.Speed + _implant.Stats.Speed;
		}
		#endregion

		#region ICalculableStats
		public int GetLevel()
		{
			return _stats.Level;
		}

		public int GetBasePhysicalAttack()
		{
			return _stats.PhysicalAttack;
		}

		public int GetBasePhysicalDefense()
		{
			return _stats.PhysicalDefense;
		}

		public int GetBaseMagicalAttack()
		{
			return _stats.MagicalAttack;
		}

		public int GetBaseMagicalDefense()
		{
			return _stats.MagicalDefense;
		}

		public int GetBaseSpeed()
		{
			return _stats.Speed;
		}

		public int GetBaseFireAttack()
		{
			return _stats.FireAttack;
		}

		public int GetBaseFireDefense()
		{
			return _stats.FireDefense;
		}

		public int GetBaseIceAttack()
		{
			return _stats.IceAttack;
		}

		public int GetBaseIceDefense()
		{
			return _stats.IceDefense;
		}

		public int GetBaseLightningAttack()
		{
			return _stats.LightningAttack;
		}

		public int GetBaseLightningDefense()
		{
			return _stats.LightningDefense;
		}

		public int GetBaseEarthAttack()
		{
			return _stats.EarthAttack;
		}

		public int GetBaseEarthDefense()
		{
			return _stats.EarthDefense;
		}

		public int GetTotalPhysicalAttack()
		{
			return GetBasePhysicalAttack();
		}

		public int GetTotalPhysicalDefense()
		{
			return GetBasePhysicalDefense();
		}

		public int GetTotalMagicalAttack()
		{
			return GetBaseMagicalAttack();
		}

		public int GetTotalMagicalDefense()
		{
			return GetBaseMagicalDefense();
		}

		public int GetTotalSpeed()
		{
			return GetBaseSpeed();
		}

		public int GetTotalFireAttack()
		{
			return GetBaseFireAttack();
		}

		public int GetTotalFireDefense()
		{
			return GetBaseFireDefense();
		}

		public int GetTotalIceAttack()
		{
			return GetBaseIceAttack();
		}

		public int GetTotalIceDefense()
		{
			return GetBaseIceDefense();
		}

		public int GetTotalLightningAttack()
		{
			return GetBaseLightningAttack();
		}

		public int GetTotalLightningDefense()
		{
			return GetBaseLightningDefense();
		}

		public int GetTotalEarthAttack()
		{
			return GetBaseEarthAttack();
		}

		public int GetTotalEarthDefense()
		{
			return GetBaseEarthDefense();
		}
		#endregion
	}
}
