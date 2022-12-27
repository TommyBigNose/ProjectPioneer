using System;
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
		bool IsFinished();
		void IncrementActionBar(float increment);
		void ResetActionBar();
	}
}
