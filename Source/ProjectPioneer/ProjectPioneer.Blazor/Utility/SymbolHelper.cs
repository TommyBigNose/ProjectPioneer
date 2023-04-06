namespace ProjectPioneer.Blazor.Utility
{
	public static class SymbolHelper
	{
		public static string GetEquipmentSymbol(IEquipment equipment)
		{
			string symbol = "";
			switch (equipment.EquipmentType)
			{
				case EquipmentType.Blade:
					symbol = "⚔️";
					break;
				case EquipmentType.Gun:
					symbol = "🔫";
					break;
				case EquipmentType.Staff:
					symbol = "🧙‍";
					break;
				case EquipmentType.Armor:
					symbol = "🧥";
					break;
				case EquipmentType.Aura:
					symbol = "🛡️";
					break;
			}

			return symbol;
		}
	}
}