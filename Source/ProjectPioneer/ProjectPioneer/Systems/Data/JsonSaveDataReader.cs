using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;
using ProjectPioneer.Systems.Adventure;
using ProjectPioneer.Systems.Character;
using ProjectPioneer.Systems.Equipment;
using ProjectPioneer.Systems.Statistics;

namespace ProjectPioneer.Systems.Data
{
	public class JsonSaveDataReader : ISaveDataReader
	{
		public string GetStringFromSaveData(SaveData saveData)
		{
			string json = JsonSerializer.Serialize<SaveData>(saveData, new JsonSerializerOptions()
			{
				WriteIndented = true
			});

			return json;
		}
	}
}
