using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPioneer.Systems.Equipment
{
	public interface IShop
	{
		IEnumerable<ISellableEquipment> GetShopInventory(int level);
		bool CanPlayerAffordEquipment(ISellableEquipment equipment, int credits);
	}
}
