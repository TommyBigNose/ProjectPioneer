using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Character;
using ProjectPioneer.Systems.Equipment;

namespace ProjectPioneer.Systems.Data
{
	public interface IDataSource
	{
		IEnumerable<IJob> GetAllJobs();
		IEnumerable<IImplant> GetAllImplants();
		IEnumerable<IWeapon> GetAllWeapons();
		IWeapon GetDefaultWeapon();
	}
}
