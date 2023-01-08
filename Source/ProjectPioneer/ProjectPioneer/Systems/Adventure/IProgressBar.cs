﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPioneer.Systems.Adventure
{
	public interface IProgressBar
	{
		float Value { get; }
		float ValueMax { get; }
		int IncrementTickRateInMs { get; }
		float IncrementRate { get; }
		bool IsFinished();
		void IncrementProgressBar();
		void ResetProgressBar();
	}
}