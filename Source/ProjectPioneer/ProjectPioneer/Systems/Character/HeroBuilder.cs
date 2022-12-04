using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPioneer.Systems.Character
{
	public class HeroBuilder : IHeroBuilder
	{
		public IHero CreateHero(string name, IJob job, IImplant implant)
		{
			IHero hero = new Hero(name, job, implant);

			return hero;
		}
	}
}
