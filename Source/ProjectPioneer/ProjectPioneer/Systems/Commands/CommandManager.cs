using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectPioneer.Systems.Commands
{
	public class CommandManager
	{
		private readonly Stack<ICommand> commands = new();
		private readonly Stack<string> commandHistory = new();

		public void Invoke(ICommand command, string[]? args = null)
		{
			if (command.CanExecute(args))
			{
				commands.Push(command);
				command.Execute(args);
				commandHistory.Push(command.ToString());
			}
			else
			{
				commandHistory.Push($"Failed to execute command | {command.Name}");
			}
		}

		public void Undo()
		{
			if (commands.Count > 0)
			{
				ICommand command = commands.Pop();
				command.Undo();
			}
		}

		public string GetCommandHistory()
		{
			StringBuilder stringBuilder = new();
			foreach (var command in commandHistory)
			{
				stringBuilder.AppendLine(command);
			}

			return stringBuilder.ToString();
		}
	}
}
