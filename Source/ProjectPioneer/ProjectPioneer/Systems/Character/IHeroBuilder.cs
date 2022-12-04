using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPioneer.Systems.Character
{
	public interface IHeroBuilder
	{
		IHero CreateHero(string name, IJob job, IImplant implant);
	}
}
