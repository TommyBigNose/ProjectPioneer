using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPioneer.Systems.Statistics
{
	public interface ICalculableStats
	{
		Stats Stats { get; }
		int GetLevel();

		// Base
		int GetBasePhysicalAttack();
		int GetBasePhysicalDefense();
		int GetBaseMagicalAttack();
		int GetBaseMagicalDefense();
		int GetBaseSpeed();
		int GetBaseFireAttack();
		int GetBaseFireDefense();
		int GetBaseIceAttack();
		int GetBaseIceDefense();
		int GetBaseLightningAttack();
		int GetBaseLightningDefense();
		int GetBaseEarthAttack();
		int GetBaseEarthDefense();
		
		// Total
		int GetTotalPhysicalAttack();
		int GetTotalPhysicalDefense();
		int GetTotalMagicalAttack();
		int GetTotalMagicalDefense();
		int GetTotalSpeed();
		int GetTotalFireAttack();
		int GetTotalFireDefense();
		int GetTotalIceAttack();
		int GetTotalIceDefense();
		int GetTotalLightningAttack();
		int GetTotalLightningDefense();
		int GetTotalEarthAttack();
		int GetTotalEarthDefense();
		Stats GetTotalsAsStats();
	}
}
