using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Character;

namespace ProjectPioneer.Systems.Data
{
	public interface IDataSource
	{
		IEnumerable<IJob> GetAllJobs();
	}
}
