using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPioneer.Systems.Data
{
	public interface ISaveableAttributeReader
	{
		IEnumerable<string> ReadAllAttributesOfObject(SaveData saveData);
		//SaveData Read
	}
}
