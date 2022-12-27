using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Equipment;
using ProjectPioneer.Systems.Statistics;

namespace ProjectPioneer.Systems.Adventure
{
	public interface IQuest
	{
		string Name { get; }
		string Description { get; }
		Stats Stats { get; }
		int GetRecommendedLevel();
		int GetCreditsReward();
		IEnumerable<IEquipment> GetPossibleEquipmentRewards();
	}
}
