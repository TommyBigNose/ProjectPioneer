using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Statistics;

namespace ProjectPioneer.Systems.Equipment
{
	public interface IArmor
	{
		string Name { get; }
		string Description { get; }
		Stats Stats { get; }
	}
}
