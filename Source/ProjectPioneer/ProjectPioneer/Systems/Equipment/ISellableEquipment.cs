using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPioneer.Systems.Equipment
{
	public interface ISellableEquipment
	{
		int GetPurchaseValue();
		int GetSellableValue();
		
	}
}
