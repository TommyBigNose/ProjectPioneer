using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Data;

namespace ProjectPioneer.Systems.Equipment
{
	public class Shop : IShop
	{
		private IDataSource _dataSource;

		public Shop(IDataSource dataSource)
		{
			_dataSource= dataSource;
		}

		public IEnumerable<IEquipment> GetShopInventory(int level)
		{
			List<IEquipment> returnedEquipment = _dataSource.GetAllWeapons().ToList().FindAll(_ => _.Stats.Level <= level + 1);
			returnedEquipment.AddRange(_dataSource.GetAllArmors().ToList().FindAll(_ => _.Stats.Level <= level + 1));
			returnedEquipment.AddRange(_dataSource.GetAllAuras().ToList().FindAll(_ => _.Stats.Level <= level + 1));

			return returnedEquipment;
		}

		public bool CanHeroAffordEquipment(IEquipment equipment, IInventory inventory)
		{
			return equipment.GetPurchaseValue() <= inventory.Credits;
		}

		public void BuyEquipmentAndAddToInventory(IEquipment equipment, IInventory inventory)
		{
			inventory.AddEquipment(equipment);
			inventory.RemoveCredits(equipment.GetPurchaseValue());
		}
	}
}
