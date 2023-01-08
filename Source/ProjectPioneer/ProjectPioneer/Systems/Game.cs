﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Character;
using ProjectPioneer.Systems.Data;
using ProjectPioneer.Systems.Equipment;

namespace ProjectPioneer.Systems
{
	public class Game : IGame
	{
		private IHero _hero;
		public IHero Hero => _hero;

		private readonly IInventory _inventory;
		public IInventory Inventory => _inventory;

		private readonly IDataSource _dataSource;
		private readonly IHeroBuilder _heroBuilder;

		public Game(IDataSource dataSource, IHeroBuilder heroBuilder, IInventory inventory)
		{
			_dataSource = dataSource;
			_heroBuilder = heroBuilder;

			_inventory = inventory;
		}

		#region Hero
		public void SetUpHero(string name, IJob job, IImplant implant)
		{
			_hero = _heroBuilder.CreateHero(name, job, implant);
		}

		public IEnumerable<IJob> GetAllJobs()
		{
			return _dataSource.GetAllJobs();
		}

		public IEnumerable<IImplant> GetAllImplants()
		{
			return _dataSource.GetAllImplants();
		}
		#endregion

		#region Inventory
		public int GetCredits()
		{
			return Inventory.Credits;
		}

		public IEnumerable<IEquipment> GetInventory()
		{
			return Inventory.HeroInventory;
		}

		public void SellEquipment(IEquipment equipment)
		{
			Inventory.SellEquipment(equipment);
		}

		public bool CanEquip(IEquipment equipment)
		{
			return Inventory.CanEquip(equipment, Hero);
		}
		#endregion

		#region Shop
		#endregion

		#region Quest
		#endregion
	}
}