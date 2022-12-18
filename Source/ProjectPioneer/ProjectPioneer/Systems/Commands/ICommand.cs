using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPioneer.Systems.Commands
{
	public interface ICommand
	{
		string Name { get; }
		bool CanExecute(string[]? args = null);
		void Execute(string[]? args = null);
		void Undo();
		string ToString();
	}
}
