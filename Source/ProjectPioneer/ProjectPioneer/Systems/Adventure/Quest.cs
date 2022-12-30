using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using ProjectPioneer.Systems.Equipment;
using ProjectPioneer.Systems.Statistics;

namespace ProjectPioneer.Systems.Adventure
{
	public class Quest : IQuest
	{
		private bool _completed = false;
		public bool Completed => _completed;

		private QuestInfo _questInfo;
		public QuestInfo QuestInfo => _questInfo;

		private IProgressBar _progressBar;
		public IProgressBar ProgressBar => _progressBar;

		public Quest(QuestInfo questInfo)
		{
			_questInfo = questInfo;
			_progressBar = new ProgressBar(TimeSpan.FromSeconds(_questInfo.QuestLengthInSeconds));
		}

		public int GetRecommendedLevel()
		{
			return _questInfo.Stats.Level;
		}

		public int GetCreditsReward()
		{
			throw new NotImplementedException();
		}

		public int GetExpReward()
		{
			throw new NotImplementedException();
		}

		public Stats GetStatComparison(Stats heroStats)
		{
			throw new NotImplementedException();
		}

		public int GetSecondReductionFromStatComparison(Stats comparedStats)
		{
			throw new NotImplementedException();
		}

		public void StartQuest()
		{
			throw new NotImplementedException();
		}


		public void EndQuest()
		{
			throw new NotImplementedException();
		}

		public void CancelQuest()
		{
			throw new NotImplementedException();
		}

		public IEquipment? RollDiceForLoot()
		{
			throw new NotImplementedException();
		}
	}
}
