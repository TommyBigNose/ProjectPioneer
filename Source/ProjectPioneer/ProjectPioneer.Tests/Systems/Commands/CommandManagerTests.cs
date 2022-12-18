using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Commands;

namespace ProjectPioneer.Tests.Systems.Commands
{
	public class CommandManagerTests
	{
		private CommandManager _sut;

		[SetUp]
		public void Setup()
		{
			_sut = new CommandManager();
		}

		[TearDown]
		public void TearDown()
		{
		}

		//[Test]
		//public void Should_RunCommand()
		//{
		//	// Arrange
		//	IGuidGenerator guidGenerator = new GuidGenerator();
		//	IClipboardTool clipboardTool = new WindowsClipboardTool();
		//	ICommand command = new GuidGeneratorCommand(guidGenerator, clipboardTool);

		//	// Act
		//	// Assert
		//	Assert.DoesNotThrow(() => _sut.Invoke(command), "CommandManager failed invoke a single command");
		//}

		//[Test]
		//public void Should_GetCommandHistory()
		//{
		//	// Arrange
		//	IGuidGenerator guidGenerator = new GuidGenerator();
		//	IClipboardTool clipboardTool = new WindowsClipboardTool();
		//	ICommand command = new GuidGeneratorCommand(guidGenerator, clipboardTool);

		//	// Act
		//	_sut.Invoke(command);
		//	var result = _sut.GetCommandHistory();

		//	// Assert
		//	Assert.That(result, Does.Contain(command.ToString()), "CommandManager failed to get history of commands");
		//}

		//[Test]
		//public void Should_OutputToCommandHistory_When_CommandCannotExecute()
		//{
		//	// Arrange
		//	IStringFormatter jsonFormatter = new JsonStringFormatter();
		//	IClipboardTool clipboardTool = new WindowsClipboardTool();
		//	ICommand command = new JsonStringFormatterCommand(jsonFormatter, clipboardTool);
		//	clipboardTool.SetText("This is not valid json {}");

		//	// Act
		//	_sut.Invoke(command);
		//	var result = _sut.GetCommandHistory();

		//	// Assert
		//	Assert.That(result, Does.Contain("Failed to execute command"), "CommandManager failed to get history of commands");
		//}
	}
}
