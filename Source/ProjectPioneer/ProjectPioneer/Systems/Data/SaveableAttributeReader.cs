using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPioneer.Systems.Data
{
	public class SaveableAttributeReader : ISaveableAttributeReader
	{
		public IEnumerable<string> ReadAllAttributesOfObject(object data)
		{
			List<string> attributes = new List<string>();
			Type type = data.GetType();

			switch(type.Name)
			{
				case "Hero":

					Dictionary<string, string> _dict = new Dictionary<string, string>();

					PropertyInfo[] props = type.GetProperties();
					foreach (PropertyInfo prop in props)
					{
						object[] attrs = prop.GetCustomAttributes(true);
						foreach (object attr in attrs)
						{
							SaveableAttribute saveableAttr = attr as SaveableAttribute;
							if (saveableAttr != null)
							{
								string propName = prop.Name;
								var val = prop.GetValue(data);
								string? val2 = val.ToString();

								//_dict.Add(propName, val);
								attributes.Add($"{saveableAttr.Name}|||{val}");
							}
						}
					}

					//var dict = type
					//			  .GetProperty("Name")
					//			  .GetCustomAttributes(true)
					//			  .ToDictionary(a => a.GetType().Name, a => a);

					//var dict = new Dictionary<MemberInfo, string>();
					//var members = type.GetMembers(BindingFlags.Public | BindingFlags.Instance)
					//					.Where(x => x.MemberType == MemberTypes.Field || x.MemberType == MemberTypes.Property);

					//foreach (MemberInfo member in members)
					//{
					//	var attr = member.GetCustomAttribute<SaveableAttribute>(true);

					//	if (attr != null)
					//	{
					//		dict.Add(member, attr.Name);
					//	}
					//}



					//// Using reflection.  
					//System.Attribute[] attrs = System.Attribute.GetCustomAttributes(type);  // Reflection.  

					//// Displaying output.  
					//foreach (System.Attribute attr in attrs)
					//{
					//	if (attr is SaveableAttribute)
					//	{
					//		SaveableAttribute a = (SaveableAttribute)attr;
					//		System.Console.WriteLine("Attribuate name {0}, value {1}", a.Name, a);
					//	}
					//}
					break;
			}

			return attributes;
		}
	}
}
