using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPioneer.Systems.Data
{
	public class LocalFileSystem : IFileSystem
	{
        private readonly string _SaveDataFullFilePath = Path.Combine(Directory.GetCurrentDirectory(), "ProjectPioneerSaveData.json");

        private ISaveDataReader _saveDataReader;

		public LocalFileSystem(ISaveDataReader saveDataReader)
		{
			this._saveDataReader = saveDataReader;
		}

		public SaveData LoadGame()
		{
			List<String> lines = new();

			using (var sr = new StreamReader(_SaveDataFullFilePath))
			{
				string? line;

				// Read all lines
				while ((line = sr.ReadLine()) != null)
				{
					lines.Add(line);
				}
			}

			string fileContent = string.Join(Environment.NewLine, lines.ToArray());

			return _saveDataReader.GetSaveDataFromString(fileContent);
		}

		public void SaveGame(SaveData saveData)
		{
			using (var fs = new FileStream(_SaveDataFullFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
			using (var sw = new StreamWriter(fs))
			{
				string saveDataString = _saveDataReader.GetStringFromSaveData(saveData);

				// Discard the contents of the file by setting the length to 0
				fs.SetLength(0);

				// Write the new content
				sw.Write(saveDataString);
			}
		}
	}
}
