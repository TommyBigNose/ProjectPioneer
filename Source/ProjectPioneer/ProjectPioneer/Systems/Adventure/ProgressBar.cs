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

		public const float ValueMax = 1000.0f;

		public ProgressBar()
		{

		}

		public bool IsFinished()
		{
			return _value >= ValueMax;
		}

		public void IncrementActionBar(float increment)
		{
			_value += increment;
			if (_value >= ValueMax) _value = ValueMax;
		}

		public void ResetActionBar()
		{
			_value = 0.0f;
		}
	}
}
