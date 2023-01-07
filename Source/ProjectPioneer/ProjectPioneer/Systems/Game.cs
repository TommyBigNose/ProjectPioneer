using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Data;

namespace ProjectPioneer.Systems
{
	public class Game : IGame
	{
		private readonly IDataSource _dataSource;

		public Game(IDataSource dataSource)
		{
			_dataSource = dataSource;
		}
	}
}
