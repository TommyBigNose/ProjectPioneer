using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Statistics;

namespace ProjectPioneer.Systems.Character
{
	public class Implant : IImplant
	{
		private readonly string _name = string.Empty;
		public string Name => _name; private readonly Stats _stats;
		public Stats Stats => _stats;

		public Implant(string name, Stats stats)
		{
			_name = name;
			_stats = stats;
		}
	}
}
