using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Character;

namespace ProjectPioneer.Systems.Equipment
{
	public interface IShop
	{
		IEnumerable<IEquipment> GetShopInventory(int level);
		bool CanHeroAffordEquipment(IEquipment equipment, IInventory inventory);
		void BuyEquipmentAndAddToInventory(IEquipment equipment, IInventory inventory);
	}
}
