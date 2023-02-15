namespace ProjectPioneer.Systems.Data
{
	public interface IFileSystem
	{
		void SaveGame(SaveData saveData);
		SaveData LoadGame();
	}
}
