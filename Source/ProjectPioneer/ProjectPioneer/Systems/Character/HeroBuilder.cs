using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Statistics;

namespace ProjectPioneer.Systems.Character
{
	public class HeroBuilder : IHeroBuilder
	{
		public IHero CreateHero(string name, IJob job, IImplant implant)
		{
			Stats stats = new();

			IHero hero = new Hero(name, job, implant, stats);

			return hero;
		}
	}
}
