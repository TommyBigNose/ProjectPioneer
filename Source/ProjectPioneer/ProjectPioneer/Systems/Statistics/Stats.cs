using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjectPioneer.Systems.Statistics
{
	public class Stats
	{
		public int Level { get; set; }
		public int PhysicalAttack { get; set; }
		public int PhysicalDefense { get; set; }
		public int MagicalAttack { get; set; }
		public int MagicalDefense { get; set; }
		public int Speed { get; set; }
		public int FireAttack { get; set; }
		public int FireDefense { get; set; }
		public int IceAttack { get; set; }
		public int IceDefense { get; set; }
		public int LightningAttack { get; set; }
		public int LightningDefense { get; set; }
		public int EarthAttack { get; set; }
		public int EarthDefense { get; set; }

		public Stats()
		{
			Level = 1;
			PhysicalAttack = 1;
			PhysicalDefense = 1;
			MagicalAttack = 1;
			MagicalDefense = 1;
			Speed = 1;
			FireAttack = 0;
			FireDefense = 0;
			IceAttack = 0;
			IceDefense = 0;
			LightningAttack = 0;
			LightningDefense = 0;
			EarthAttack = 0;
			EarthDefense = 0;
		}

		public Stats(Stats clone)
		{
			Level = clone.Level;
			PhysicalAttack = clone.PhysicalAttack;
			PhysicalDefense = clone.PhysicalDefense;
			MagicalAttack = clone.MagicalAttack;
			MagicalDefense = clone.MagicalDefense;
			Speed = clone.Speed;
			FireAttack = clone.FireAttack;
			FireDefense = clone.FireDefense;
			IceAttack = clone.IceAttack;
			IceDefense = clone.IceDefense;
			LightningAttack = clone.LightningAttack;
			LightningDefense = clone.LightningDefense;
			EarthAttack = clone.EarthAttack;
			EarthDefense = clone.EarthDefense;
		}

        public List<string> GetLevelUpStatsAsList()
		{
            List<string> statList = new()
            {
                $"Physical Attack: {PhysicalAttack}",
                $"Physical Defense: {PhysicalDefense}",
                $"Magical Attack: {MagicalAttack}",
                $"Magical Defense: {MagicalDefense}",
                $"Speed: {Speed}"
            };

            return statList;
        }

        public List<string> GetElementalStatsAsList()
        {
            List<string> statList = new()
            {
                $"Fire Attack: {FireAttack}",
                $"Fire Defense: {FireDefense}",
                $"Ice Attack: {IceAttack}",
                $"Ice Defense: {IceDefense}",
                $"Lightning Attack: {LightningAttack}",
                $"Lightning Defense: {LightningDefense}",
                $"Earth Attack: {EarthAttack}",
                $"Earth Defense: {EarthDefense}"
            };

            return statList;
        }

        public List<string> GetStatsAsList()
        {
            List<string> statList = new()
            {
                $"Level: {Level}",
                $"Physical Attack: {PhysicalAttack}",
                $"Physical Defense: {PhysicalDefense}",
                $"Magical Attack: {MagicalAttack}",
                $"Magical Defense: {MagicalDefense}",
                $"Speed: {Speed}",
                $"Fire Attack: {FireAttack}",
                $"Fire Defense: {FireDefense}",
                $"Ice Attack: {IceAttack}",
                $"Ice Defense: {IceDefense}",
                $"Lightning Attack: {LightningAttack}",
                $"Lightning Defense: {LightningDefense}",
                $"Earth Attack: {EarthAttack}",
                $"Earth Defense: {EarthDefense}"
            };

            return statList;
        }
    }
}
