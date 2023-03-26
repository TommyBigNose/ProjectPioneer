namespace ProjectPioneer.Systems.Character
{
	public interface IJob
	{
		int ID { get; }
		string Name { get; }
		string Description { get; }
		IEnumerable<EquipmentType> EquipableTypes { get; }
		Stats Stats { get; }
	}
}
