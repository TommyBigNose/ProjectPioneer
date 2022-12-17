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
		public string Name => _name;
		private readonly string _description = string.Empty;
		public string Description => _description;
		private readonly Stats _stats;
		public Stats Stats => _stats;

		public Implant(string name, string description, Stats stats)
		{
			_name = name;
			_description = description;
			_stats = stats;
		}
	}
}
