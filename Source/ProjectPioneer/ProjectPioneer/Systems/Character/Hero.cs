using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public Hero(string name, IJob job, IImplant implant)
		{
			_name = name;
			_job = job;
			_implant = implant;
		}
	}
}
