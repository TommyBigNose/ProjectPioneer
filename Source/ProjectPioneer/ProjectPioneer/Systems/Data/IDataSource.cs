﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPioneer.Systems.Adventure;
using ProjectPioneer.Systems.Character;
using ProjectPioneer.Systems.Equipment;

namespace ProjectPioneer.Systems.Data
{
	public interface IDataSource
	{
		IEnumerable<IJob> GetAllJobs();
		IEnumerable<IImplant> GetAllImplants();
		IEnumerable<IEquipment> GetAllWeapons();
		IEnumerable<IEquipment> GetAllArmors();
		IEnumerable<IEquipment> GetAllAuras();
		IEnumerable<IEquipment> GetAllEquipment(int minlevel = 0, int maxLevel = 999);
		IEquipment GetEquipmentByID(int id);
		IEnumerable<IEquipment> GetEquipmentByIDs(List<int> ids);
		IEquipment GetDefaultWeapon();
		IEquipment GetDefaultArmor();
		IEquipment GetDefaultAura();
		IEnumerable<QuestInfo> GetAllQuestInfos();
		IEnumerable<IQuest> GetAllQuests();
	}
}
