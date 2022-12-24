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

		public IEnumerable<ISellableEquipment> GetShopInventory(int level)
		{
			List<IWeapon> weapons = _dataSource.GetAllWeapons().ToList().FindAll(_ => _.Stats.Level <= level + 1);
			List<IArmor> armors = _dataSource.GetAllArmors().ToList().FindAll(_ => _.Stats.Level <= level + 1);
			List<IAura> auras = _dataSource.GetAllAuras().ToList().FindAll(_ => _.Stats.Level <= level + 1);

			List<ISellableEquipment> returnedEquipment = weapons.Cast<ISellableEquipment>().ToList();
			returnedEquipment.AddRange(armors.Cast<ISellableEquipment>().ToList());
			returnedEquipment.AddRange(auras.Cast<ISellableEquipment>().ToList());

			return returnedEquipment;
		}

		public bool CanPlayerAffordEquipment(ISellableEquipment equipment, int credits)
		{
			return equipment.GetPurchaseValue() <= credits;
		}
	}
}
