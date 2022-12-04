using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPioneer.Systems.Character
{
	public class Job : IJob
	{
		private readonly string _name = string.Empty;
		public string Name => _name;
	}
}
