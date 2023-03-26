namespace ProjectPioneer.Systems.Data
{
	public class JsonSaveDataReader : ISaveDataReader
	{
		private readonly IDataSource _dataSource;

		public JsonSaveDataReader(IDataSource dataSource)
		{
			_dataSource = dataSource;
		}

		public string GetStringFromSaveData(SaveData saveData)
		{
			SerializeableSaveData serializeableSaveData = saveData.ConvertToSerializeableSaveData();
			string json = JsonSerializer.Serialize(serializeableSaveData, new JsonSerializerOptions()
			{
				WriteIndented = true
			});

			return json;
		}

		public SaveData GetSaveDataFromString(string stringData)
		{
			SerializeableSaveData? serializeableSaveData = JsonSerializer.Deserialize<SerializeableSaveData?>(stringData);
			SaveData saveData = serializeableSaveData!.ConvertToSaveData(_dataSource);

			return saveData;
		}
	}
}
