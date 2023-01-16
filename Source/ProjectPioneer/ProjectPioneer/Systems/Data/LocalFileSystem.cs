using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPioneer.Systems.Data
{
	public class LocalFileSystem : IFileSystem
	{
		public LocalFileSystem() 
		{

		}

		public SaveData LoadGame()
		{
			throw new NotImplementedException();
		}

		public void SaveGame(SaveData saveData)
		{
			throw new NotImplementedException();
		}
	}
}
