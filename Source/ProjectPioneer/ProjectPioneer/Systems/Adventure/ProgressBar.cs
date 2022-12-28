using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace ProjectPioneer.Systems.Adventure
{
	public class ProgressBar : IProgressBar
	{
		private float _value = 0.0f;
		public float Value => _value;

		private float _valueMax = 1000.0f;
		public float ValueMax => _valueMax;

		private int _incrementRateInMs = 100;
		public int IncrementRateInMs => _incrementRateInMs;

		private float _increment = 16.67f; // 1000 / 60 seconds / (1000 / 100) == One minute by default
		public float Increment => _increment;

		public ProgressBar(TimeSpan seconds)
		{
			// Max is 1000, divde by seconds, then divide by the ratio of our refresh rate versus our max
			// So, 1000 / 60 seconds == 16.666 then divide by 1000 / 100, which equals 1.666
			_increment = (float)(ValueMax / seconds.TotalSeconds) / (float)(ValueMax / IncrementRateInMs);
		}

		public bool IsFinished()
		{
			// Margin of error due to floats
			return _value >= (ValueMax-0.2f);
		}

		public void IncrementProgressBar()
		{
			_value += Increment;
			if (_value >= ValueMax) _value = ValueMax;
		}

		public void ResetProgressBar()
		{
			_value = 0.0f;
		}
	}
}
