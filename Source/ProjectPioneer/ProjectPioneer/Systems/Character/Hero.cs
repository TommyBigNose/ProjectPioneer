using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Statistics;

namespace ProjectPioneer.Systems.Character
{
	public class Hero : IHero, ICalculableStats
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

		#region ICalculableStats
		public int GetLevel()
		{
			throw new NotImplementedException();
		}

		public int GetBasePhysicalAttack()
		{
			throw new NotImplementedException();
		}

		public int GetBasePhysicalDefense()
		{
			throw new NotImplementedException();
		}

		public int GetBaseMagicalAttack()
		{
			throw new NotImplementedException();
		}

		public int GetBaseMagicalDefense()
		{
			throw new NotImplementedException();
		}

		public int GetBaseSpeed()
		{
			throw new NotImplementedException();
		}

		public int GetBaseFireAttack()
		{
			throw new NotImplementedException();
		}

		public int GetBaseFireDefense()
		{
			throw new NotImplementedException();
		}

		public int GetBaseIceAttack()
		{
			throw new NotImplementedException();
		}

		public int GetBaseIceDefense()
		{
			throw new NotImplementedException();
		}

		public int GetBaseLightningAttack()
		{
			throw new NotImplementedException();
		}

		public int GetBaseLightningDefense()
		{
			throw new NotImplementedException();
		}

		public int GetBaseEarthAttack()
		{
			throw new NotImplementedException();
		}

		public int GetBaseEarthDefense()
		{
			throw new NotImplementedException();
		}

		public int GetTotalPhysicalAttack()
		{
			throw new NotImplementedException();
		}

		public int GetTotalPhysicalDefense()
		{
			throw new NotImplementedException();
		}

		public int GetTotalMagicalAttack()
		{
			throw new NotImplementedException();
		}

		public int GetTotalMagicalDefense()
		{
			throw new NotImplementedException();
		}

		public int GetTotalSpeed()
		{
			throw new NotImplementedException();
		}

		public int GetTotalFireAttack()
		{
			throw new NotImplementedException();
		}

		public int GetTotalFireDefense()
		{
			throw new NotImplementedException();
		}

		public int GetTotalIceAttack()
		{
			throw new NotImplementedException();
		}

		public int GetTotalIceDefense()
		{
			throw new NotImplementedException();
		}

		public int GetTotalLightningAttack()
		{
			throw new NotImplementedException();
		}

		public int GetTotalLightningDefense()
		{
			throw new NotImplementedException();
		}

		public int GetTotalEarthAttack()
		{
			throw new NotImplementedException();
		}

		public int GetTotalEarthDefense()
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}
