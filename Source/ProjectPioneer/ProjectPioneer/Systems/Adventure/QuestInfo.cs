﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Equipment;
using ProjectPioneer.Systems.Statistics;

namespace ProjectPioneer.Systems.Adventure
{
	public class QuestInfo
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public int QuestLengthInSeconds { get; set; }
		public int ChanceForNormalLoot { get; set; }
		public int ChanceForRareLoot { get; set; }
		public int TotalChancesForLoot { get; set; }
		public Stats Stats { get; set; }
		public IEnumerable<IEquipment> NormalLoot { get; set; }
		public IEquipment RareLoot { get; set; }
	}
}