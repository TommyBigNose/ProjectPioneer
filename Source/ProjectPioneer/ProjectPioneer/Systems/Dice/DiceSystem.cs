using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPioneer.Systems.Dice
{
	public class DiceSystem : IDiceSystem
	{
		Random _random;

		public DiceSystem()
		{
			_random = new Random();
		}

		public int GetDiceRoll(int min, int max)
		{
			return _random.Next(min, max);
		}
	}
}
