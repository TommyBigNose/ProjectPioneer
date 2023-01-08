using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Character;
using ProjectPioneer.Systems.Equipment;

namespace ProjectPioneer.Systems
{
	public interface IGame
	{
		IHero Hero { get; }

		#region Hero
		void SetUpHero(string name, IJob job, IImplant implant);
		IEnumerable<IJob> GetAllJobs();
		IEnumerable<IImplant> GetAllImplants();
		#endregion

		#region Inventory
		#endregion

		#region Shop
		#endregion

		#region Quest
		#endregion
	}
}
