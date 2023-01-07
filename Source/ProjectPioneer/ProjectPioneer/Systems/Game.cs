using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Character;
using ProjectPioneer.Systems.Data;

namespace ProjectPioneer.Systems
{
	public class Game : IGame
	{
		private IHero _hero;
		public IHero Hero => _hero;

		private readonly IDataSource _dataSource;
		private readonly IHeroBuilder _heroBuilder;

		public Game(IDataSource dataSource, IHeroBuilder heroBuilder)
		{
			_dataSource = dataSource;
			_heroBuilder = heroBuilder;
		}

		#region Hero
		public void SetUpHero(string name, IJob job, IImplant implant)
		{
			_hero = _heroBuilder.CreateHero(name, job, implant);
		}
		#endregion

		#region Inventory
		#endregion

		#region Shop
		#endregion

		#region Quest
		#endregion
	}
}
