using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using ProjectPioneer.Systems.Adventure;
using ProjectPioneer.Systems.Character;
using ProjectPioneer.Systems.Equipment;
using ProjectPioneer.Systems.Statistics;

namespace ProjectPioneer.Systems.Data
{
	public class SaveableAttributeReader : ISaveableAttributeReader
	{
		public IEnumerable<string> ReadAllAttributesOfObject(object data)
		{
			List<string> attributes = new List<string>();
			//Type type = data.GetType();

			switch(data.GetType().Name)
			{
				case "Hero":
					attributes.AddRange(GetHeroSaveableAttributes(data));
					break;
				case "Inventory":
					attributes.AddRange(GetInventorySaveableAttributes(data));
					break;
				case "QuestLog":
					attributes.AddRange(GetQuestLogSaveableAttributes(data));
					break;
			}

			return attributes;
		}

		private List<string> GetHeroSaveableAttributes(object data)
		{
			List<string> attributes = new List<string>();

			foreach (var attrib in GetSaveableAttributes(data))
			{
				var val = attrib.Key.GetValue(data);

				switch (attrib.Key.PropertyType.Name)
				{
					case "IJob":
						val = ((IJob)val).ID;
						break;
					case "IImplant":
						val = ((IImplant)val).ID;
						break;
					case "IEquipment":
						val = ((IEquipment)val).ID;
						break;
					case "Stats":
						val = JsonSerializer.Serialize(val);
						break;
				}

				attributes.Add($"{attrib.Value.Name}|||{val}");
			}

			return attributes;
		}

		private List<string> GetInventorySaveableAttributes(object data)
		{
			List<string> attributes = new List<string>();

			foreach (var attrib in GetSaveableAttributes(data))
			{
				var val = attrib.Key.GetValue(data);

				switch (attrib.Key.PropertyType.Name)
				{
					case "List`1":
						val = string.Join(Constants.AttributeListSeparator, ((List<IEquipment>)val).Select(_=>_.ID));
						break;
				}

				attributes.Add($"{attrib.Value.Name}|||{val}");
			}

			return attributes;
		}

		private List<string> GetQuestLogSaveableAttributes(object data)
		{
			List<string> attributes = new List<string>();

			foreach (var attrib in GetSaveableAttributes(data))
			{
				var val = attrib.Key.GetValue(data);

				switch (attrib.Key.PropertyType.Name)
				{
					case "HashSet`1":
						val = string.Join(Constants.AttributeListSeparator, ((HashSet<IQuest>)val).Select(_ => _.QuestInfo.ID));
						break;
				}

				attributes.Add($"{attrib.Value.Name}|||{val}");
			}

			return attributes;
		}

		/// <summary>
		/// Gathers all the property information and saveable attribute data in a dictionary so you can parse out the actual value and the name of the attribute for easy reading/usage
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		private Dictionary<PropertyInfo, SaveableAttribute> GetSaveableAttributes(object data)
		{
			Dictionary<PropertyInfo, SaveableAttribute> dictionary = new Dictionary<PropertyInfo, SaveableAttribute>();

			PropertyInfo[] props = data.GetType().GetProperties();
			foreach (PropertyInfo prop in props)
			{
				object[] attrs = prop.GetCustomAttributes(true);
				foreach (object attr in attrs)
				{
					SaveableAttribute? saveableAttr = attr as SaveableAttribute;
					if (saveableAttr != null)
					{
						dictionary.Add(prop, saveableAttr);
					}
				}
			}

			return dictionary;
		}
	}
}
