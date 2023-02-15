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
