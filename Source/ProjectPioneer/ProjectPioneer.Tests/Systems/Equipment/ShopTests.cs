﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Data;
using ProjectPioneer.Systems.Equipment;

namespace ProjectPioneer.Tests.Systems.Equipment
{
	[TestFixture]
	public class ShopTests
	{
		private IDataSource _dataSource;
		private IShop _sut;

		[SetUp]
		public void SetUp()
		{
			_dataSource = new LocalDataSource();
			_sut = new Shop(_dataSource);
		}

		[TearDown]
		public void TearDown()
		{

		}

		[TestCase(100)]
		[TestCase(1000)]
		public void Should_CanPurchaseEquipment_When_PlayerHasEnoughCredits(int credits)
		{
			// Arrange
			ISellableEquipment sellableWeapon = _dataSource.GetAllWeapons().First(_ => _.GetPurchaseValue() <= credits);

			// Act
			var result = _sut.CanPlayerAffordEquipment(sellableWeapon, credits);

			// Assert
			Assert.That(result, Is.True, "Shop said the equipment was not affordable despite being within the player's budget");
		}

		[TestCase(0)]
		[TestCase(99)]
		public void Should_CannotPurchaseEquipment_When_PlayerIsBroke(int credits)
		{
			// Arrange
			ISellableEquipment sellableWeapon = _dataSource.GetAllWeapons().First(_ => _.GetPurchaseValue() >= credits);

			// Act
			var result = _sut.CanPlayerAffordEquipment(sellableWeapon, credits);

			// Assert
			Assert.That(result, Is.False, "Shop said the equipment was affordable despite being broke");
		}
	}
}
