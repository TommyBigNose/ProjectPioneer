namespace ProjectPioneer.Systems.Data
{
	public class SerializeableSaveData
	{
		#region Hero
		public string Name { get; set; }
		public int Exp { get; set; }
		public int JobID { get; set; }
		public int ImplantID { get; set; }
		public int EquippedWeaponID { get; set; }
		public int EquippedArmorID { get; set; }
		public int EquippedAuraID { get; set; }
		public Stats Stats { get; set; }
		#endregion

		#region Inventory
		public int Credits { get; set; }
		public List<int> HeroInventoryIDs { get; set; }
		#endregion

		#region QuestLog
		public HashSet<int> CompletedQuests { get; set; }
		#endregion

		public SaveData ConvertToSaveData(IDataSource dataSource)
		{
			IJob job = dataSource.GetAllJobs().First(_ => _.ID == JobID);
			IImplant implant = dataSource.GetAllImplants().First(_ => _.ID == ImplantID);
			IEquipment equippedWeapon = dataSource.GetEquipmentByID(EquippedWeaponID);
			IEquipment equippedArmor = dataSource.GetEquipmentByID(EquippedArmorID);
			IEquipment equippedAura = dataSource.GetEquipmentByID(EquippedAuraID);

			IHero hero = new Hero(Name, Exp, job, implant, Stats, equippedWeapon, equippedArmor, equippedAura);

			List<IEquipment> heroInventory = dataSource.GetEquipmentByIDs(HeroInventoryIDs).ToList();
			IInventory inventory = new Inventory(Credits, heroInventory);

			IQuestLog questLog = new QuestLog(CompletedQuests);

			SaveData data = new SaveData()
			{
				Hero = hero,
				Inventory = inventory,
				QuestLog = questLog
			};

			return data;
		}
	}
}
