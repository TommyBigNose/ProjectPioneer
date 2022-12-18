using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Data;
using ProjectPioneer.Systems.Equipment;
using ProjectPioneer.Systems.Statistics;

namespace ProjectPioneer.Systems.Character
{
	public class HeroBuilder : IHeroBuilder
	{
		private IDataSource _dataSource;

		public HeroBuilder(IDataSource dataSource)
		{
			_dataSource = dataSource;
		}

		public IHero CreateHero(string name, IJob job, IImplant implant)
		{
			Stats stats = new();
			IWeapon weapon = _dataSource.GetDefaultWeapon();
			IArmor armor = _dataSource.GetDefaultArmor();
			IAura aura = _dataSource.GetDefaultAura();

			IHero hero = new Hero(name, job, implant, stats, weapon, armor, aura);

			return hero;
		}
	}
}
