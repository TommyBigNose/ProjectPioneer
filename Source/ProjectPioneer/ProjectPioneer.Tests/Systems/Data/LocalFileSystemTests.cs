using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Adventure;
using ProjectPioneer.Systems.Data;

namespace ProjectPioneer.Tests.Systems.Data
{
	[TestFixture]
	public class LocalFileSystemTests
	{
		private IDataSource _dataSource;
		private IFileSystem _sut;

		[SetUp]
		public void SetUp()
		{
			_dataSource = new MemoryDataSource();
			_sut = new LocalFileSystem();
		}

		[TearDown]
		public void TearDown()
		{

		}

		[Test]
		public void Should_CreateFile_When_SavingAndNoFileExists()
		{
			// Arrange
			// Act
			var result = _sut;

			// Assert
			Assert.Fail("Not implemented yet");
			//Assert.That(result, Is.Not.Null, "Result was null");
		}
	}
}
