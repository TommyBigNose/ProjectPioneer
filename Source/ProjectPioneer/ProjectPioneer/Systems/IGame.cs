using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Character;

namespace ProjectPioneer.Systems
{
	public interface IGame
	{
		IHero Hero { get; }

		#region Hero
		void SetUpHero(string name, IJob job, IImplant implant);
		#endregion

		#region Inventory
		#endregion

		#region Shop
		#endregion

		#region Quest
		#endregion
	}
}
