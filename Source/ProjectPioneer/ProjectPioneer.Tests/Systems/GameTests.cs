using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems;
using ProjectPioneer.Systems.Data;
using ProjectPioneer.Systems.Equipment;

namespace ProjectPioneer.Tests.Systems
{
	[TestFixture]
	public class GameTests
	{
		private IDataSource _dataSource;
		private IGame _sut;

		[SetUp]
		public void SetUp()
		{
			_dataSource = new LocalDataSource();
			_sut = new Game(_dataSource);
		}

		[TearDown]
		public void TearDown()
		{

		}

		[Test]
		public void Should_Pass_When_Valid()
		{
			// Arrange
			// Act
			var result = _sut;

			// Assert
			Assert.That(result, Is.Not.Null, "Result was null");
		}
	}
}
