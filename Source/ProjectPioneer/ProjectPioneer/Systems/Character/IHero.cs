using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Statistics;

namespace ProjectPioneer.Systems.Character
{
	public interface IHero: ICalculableStats
	{
		string Name { get; }
		IJob Job { get; }
		IImplant Implant { get; }
		void LevelUp();
	}
}
