using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPioneer.Systems.Dice
{
	public interface IDiceSystem
	{
		int GetDiceRoll(int min, int max);
	}
}
