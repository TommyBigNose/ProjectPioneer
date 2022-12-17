using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Character;
using ProjectPioneer.Systems.Data;

namespace ProjectPioneer.Tests.Systems.Data
{
	[TestFixture]
	public class LocalDataSourceTests
	{
		private IDataSource _sut;

		[SetUp]
		public void SetUp()
		{
			_sut = new LocalDataSource();
		}

		[TearDown]
		public void TearDown()
		{

		}

		[Test]
		public void Should_GetAllJobs()
		{
			// Arrange
			// Act
			var result = _sut.GetAllJobs();

			// Assert
			Assert.That(result.Count, Is.GreaterThanOrEqualTo(3), "LocalDataSource did not return enough jobs.");
		}

		[Test]
		public void Should_GetAllImplants()
		{
			// Arrange
			// Act
			var result = _sut.GetAllImplants();

			// Assert
			Assert.That(result.Count, Is.GreaterThanOrEqualTo(3), "LocalDataSource did not return enough implants.");
		}


		[Test]
		public void Should_GetAllWeapons()
		{
			// Arrange
			// Act
			var result = _sut.GetAllWeapons();

			// Assert
			Assert.That(result.Count, Is.GreaterThanOrEqualTo(3), "LocalDataSource did not return enough weapons.");
		}
	}
}
