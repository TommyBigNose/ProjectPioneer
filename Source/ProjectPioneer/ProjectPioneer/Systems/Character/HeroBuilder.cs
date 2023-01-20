﻿using System;
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
		private readonly IDataSource _dataSource;

		public HeroBuilder(IDataSource dataSource)
		{
			_dataSource = dataSource;
		}

		public IHero CreateHero(string name, IJob job, IImplant implant)
		{
			Stats stats = new();
			IEquipment weapon = _dataSource.GetDefaultWeapon();
			IEquipment armor = _dataSource.GetDefaultArmor();
			IEquipment aura = _dataSource.GetDefaultAura();
			int exp = 0;

			IHero hero = new Hero(name, exp, job, implant, stats, weapon, armor, aura);

			return hero;
		}
	}
}
