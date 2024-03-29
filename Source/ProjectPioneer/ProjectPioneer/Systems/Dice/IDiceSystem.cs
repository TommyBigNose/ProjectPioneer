﻿namespace ProjectPioneer.Systems.Dice
{
	public interface IDiceSystem
	{
		/// <summary>
		/// Random number greater than or equal to min, less than max
		/// min <= result < max
		/// </summary>
		/// <param name="min">Inclusive</param>
		/// <param name="max">Exclusive</param>
		/// <returns></returns>
		int GetDiceRoll(int min, int max);
	}
}