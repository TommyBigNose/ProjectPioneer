namespace ProjectPioneer.Systems.Data
{
	public interface ISaveDataReader
	{
		string GetStringFromSaveData(SaveData saveData);
		SaveData GetSaveDataFromString(string stringData);
	}
}
