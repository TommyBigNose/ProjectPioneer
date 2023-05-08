namespace ProjectPioneer.Blazor.Utility
{
	public static class SymbolHelper
	{
		public static string GetEquipmentSymbol(IEquipment? equipment)
		{
			string symbol = "";
			switch (equipment?.EquipmentType)
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
				default:
					symbol = "❔";
					break;
			}

			return symbol;
		}

		public static string GetCheckmarkOrX(bool value)
		{
			return (value) ? "✅" : "❌";
		}

		public static object GetChestSymbol()
		{
			return "🧰";
		}
		
		public static string GetItemArt(IEquipment? equipment)
		{
			return $"art/equipment/{equipment?.ImageName}.png";
		}
    
		public static string GetItemArtAlt(IEquipment? equipment)
		{
			return $"{equipment?.ImageName}.png";
		}

		public static string GetELementalSymbol(StatType statType)
		{
			string symbol = "";
			switch (statType)
			{
				case StatType.FireAttack:
				case StatType.FireDefense:
					symbol = "🔥";
					break;
				case StatType.IceAttack:
				case StatType.IceDefense:
					symbol = "❄️";
					break;
				case StatType.LightningAttack:
				case StatType.LightningDefense:
					symbol = "⚡";
					break;
				case StatType.EarthAttack:
				case StatType.EarthDefense:
					symbol = "⛰️";
					break;
				default:
					symbol = "❔";
					break;
			}

			return symbol;
		}
	}
}