using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPioneer.Systems.Character
{
	public interface IHero
	{
		string Name { get; }
		IJob Job { get; }
		IImplant Implant { get; }
	}
}
