namespace ProjectPioneer.Systems.Adventure
{
	public class QuestInfo
	{
		public int ID { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public int QuestLengthInSeconds { get; set; }
		public int ChanceForNormalLoot { get; set; }
		public int ChanceForRareLoot { get; set; }
		public int TotalChancesForLoot { get; set; }
		public float StatTypeMultiplierRatio { get; set; }
		public List<StatType>? StatTypeMultipliers { get; set; }
		public Stats? Stats { get; set; }
		public IEnumerable<IEquipment>? NormalLoot { get; set; }
		public IEquipment? RareLoot { get; set; }
	}
}
