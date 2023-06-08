namespace ProjectPioneer.Systems.Data
{
	public interface IDataSource
	{
		IEnumerable<IJob> GetAllJobs();
		IEnumerable<IImplant> GetAllImplants();
		IEnumerable<IEquipment> GetAllWeapons();
		IEnumerable<IEquipment> GetAllArmors();
		IEnumerable<IEquipment> GetAllAuras();
		IEnumerable<IEquipment> GetAllEquipment(int minLevel = 0, int maxLevel = 999);
		IEquipment GetEquipmentByID(int id);
		IEnumerable<IEquipment> GetEquipmentByIDs(List<int> ids);
		IEnumerable<IEquipment> GetEquipmentByNames(List<string> names);
		IEquipment GetDefaultWeapon();
		IEquipment GetDefaultArmor();
		IEquipment GetDefaultAura();
		IEnumerable<QuestInfo> GetAllQuestInfos();
		IEnumerable<IQuest> GetAllQuests(int minlevel = 0, int maxLevel = 999);
	}
}
