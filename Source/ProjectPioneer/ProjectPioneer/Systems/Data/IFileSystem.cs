using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPioneer.Systems.Data
{
	public interface IFileSystem
	{
		void SaveGame(SaveData saveData);
		SaveData LoadGame();
	}
}
