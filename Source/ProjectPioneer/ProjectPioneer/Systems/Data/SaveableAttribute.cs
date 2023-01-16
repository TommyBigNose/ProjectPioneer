using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPioneer.Systems.Data
{
	[AttributeUsage(AttributeTargets.Property)]
	public class SaveableAttribute : Attribute
	{
		private string _name;
		public string Name => _name;

		public SaveableAttribute(string name)
		{
			_name = name;
		}
	}
}
