using System;
using xBDD.Model;
using xBDD.Utility;
namespace xBDD.Core

{
	public class StatsCascader
	{
        Utility.OutcomeAggregator outcomeAggregator;
		public StatsCascader(UtilityFactory factory)
		{
			outcomeAggregator = factory.CreateOutcomeAggregator();
		}
		public void CascadeStats(Step step)
		{
			CascadeOutcome(step);
			CascadeStartTime(step);
			CascadeEndTime(step);
		}
		public void CascadeStats(Scenario scenario)
		{
			CascadeOutcome(scenario);
			CascadeStartTime(scenario);
			CascadeEndTime(scenario);
		}
        void CascadeOutcome(Step step)
        {
            CascadeScenarioOutcome(step);
			CascadeFeatureOutcome(step);
			CascadeAreaOutcome(step);
            step.Scenario.Feature.Area.TestRun.Outcome = outcomeAggregator.GetNewParentOutcome(step.Scenario.Feature.Area.Outcome, step.Scenario.Feature.Outcome);
        }
        void CascadeOutcome(Scenario scenario)
        {
			CascadeFeatureOutcome(scenario);
			CascadeAreaOutcome(scenario);
            scenario.Feature.Area.TestRun.Outcome = outcomeAggregator.GetNewParentOutcome(scenario.Feature.Area.Outcome, scenario.Feature.Outcome);
        }
        private void CascadeScenarioOutcome(Step step)
        {
            var scenarioOutcome = step.Scenario.Outcome;
            step.Scenario.Outcome = outcomeAggregator.GetNewScenarioOutcome(step.Scenario.Outcome, step.Outcome);
            UpdateOutcome(scenarioOutcome, step.Scenario.Outcome,
                step.Scenario.Feature.ScenarioStats,
                step.Scenario.Feature.Area.ScenarioStats,
                step.Scenario.Feature.Area.TestRun.ScenarioStats);
        }
        private void CascadeFeatureOutcome(Step step)
        {
            var featureOutcome = step.Scenario.Feature.Outcome;
            step.Scenario.Feature.Outcome = outcomeAggregator.GetNewParentOutcome(step.Scenario.Feature.Outcome, step.Scenario.Outcome);
            UpdateOutcome(featureOutcome, step.Scenario.Feature.Outcome,
                step.Scenario.Feature.Area.FeatureStats,
                step.Scenario.Feature.Area.TestRun.FeatureStats);
        }
        private void CascadeFeatureOutcome(Scenario scenario)
        {
            var featureOutcome = scenario.Feature.Outcome;
            scenario.Feature.Outcome = outcomeAggregator.GetNewParentOutcome(scenario.Feature.Outcome, scenario.Outcome);
            UpdateOutcome(featureOutcome, scenario.Feature.Outcome,
                scenario.Feature.Area.FeatureStats,
                scenario.Feature.Area.TestRun.FeatureStats);
        }
        private void CascadeAreaOutcome(Step step)
        {
            var areaOutcome = step.Scenario.Feature.Area.Outcome;
            step.Scenario.Feature.Area.Outcome = outcomeAggregator.GetNewParentOutcome(step.Scenario.Feature.Area.Outcome, step.Scenario.Feature.Outcome);
            UpdateOutcome(areaOutcome, step.Scenario.Feature.Area.Outcome,
                step.Scenario.Feature.Area.TestRun.AreaStats);
        }

        private void CascadeAreaOutcome(Scenario scenario)
        {
            var areaOutcome = scenario.Feature.Area.Outcome;
            scenario.Feature.Area.Outcome = outcomeAggregator.GetNewParentOutcome(scenario.Feature.Area.Outcome, scenario.Feature.Outcome);
            UpdateOutcome(areaOutcome, scenario.Feature.Area.Outcome,
                scenario.Feature.Area.TestRun.AreaStats);
        }

        void UpdateOutcome(Outcome previousOutcome, Outcome newOutcome, params OutcomeStats[] stats)
		{
			if(previousOutcome != newOutcome)
			{
				foreach(var stat in stats)
				{
					UpdateStats(previousOutcome, newOutcome, stat);
				}
			}
		}
		
		void UpdateStats(Outcome previousOutcome, Outcome newOutcome, OutcomeStats stats)
		{
			DecrementStat(previousOutcome, stats);
			IncrementStat(newOutcome, stats);
		}

        void DecrementStat(Outcome previousOutcome, OutcomeStats stats)
        {
            switch (previousOutcome)
			{
				case Outcome.Failed:
					stats.Failed--;
					break;
				case Outcome.NotRun:
					break;
				case Outcome.Passed:
					stats.Passed--;
					break;
				case Outcome.Skipped:
					stats.Skipped--;
					break;
			}
        }
        void IncrementStat(Outcome newOutcome, OutcomeStats stats)
        {
            switch (newOutcome)
			{
				case Outcome.Failed:
					stats.Failed++;
					break;
				case Outcome.NotRun:
					break;
				case Outcome.Passed:
					stats.Passed++;
					break;
				case Outcome.Skipped:
					stats.Skipped++;
					break;
			}
        }


        void CascadeStartTime(Step step)
        {
			if(step.Scenario.StartTime.Equals(DateTime.MinValue) || step.Scenario.StartTime > step.StartTime)
            	step.Scenario.StartTime = step.StartTime;
			if(step.Scenario.Feature.StartTime.Equals(DateTime.MinValue) || step.Scenario.Feature.StartTime > step.StartTime)
            	step.Scenario.Feature.StartTime = step.StartTime;
			if(step.Scenario.Feature.Area.StartTime.Equals(DateTime.MinValue) || step.Scenario.Feature.Area.StartTime > step.StartTime)
            	step.Scenario.Feature.Area.StartTime = step.StartTime;
			if(step.Scenario.Feature.Area.TestRun.StartTime.Equals(DateTime.MinValue) || step.Scenario.Feature.Area.TestRun.StartTime > step.StartTime)
            	step.Scenario.Feature.Area.TestRun.StartTime =  step.StartTime;
        }
        void CascadeStartTime(Scenario scenario)
        {
			if(scenario.Feature.StartTime.Equals(DateTime.MinValue) || scenario.Feature.StartTime > scenario.StartTime)
            	scenario.Feature.StartTime = scenario.StartTime;
			if(scenario.Feature.Area.StartTime.Equals(DateTime.MinValue) || scenario.Feature.Area.StartTime > scenario.StartTime)
            	scenario.Feature.Area.StartTime = scenario.StartTime;
			if(scenario.Feature.Area.TestRun.StartTime.Equals(DateTime.MinValue) || scenario.Feature.Area.TestRun.StartTime > scenario.StartTime)
            	scenario.Feature.Area.TestRun.StartTime =  scenario.StartTime;
        }
        void CascadeEndTime(Step step)
        {
			if(step.Scenario.EndTime > DateTime.MinValue)
            	step.Scenario.EndTime =  step.EndTime;
			if(step.Scenario.Feature.EndTime > DateTime.MinValue)
            	step.Scenario.Feature.EndTime =  step.EndTime;
			if(step.Scenario.Feature.Area.EndTime > DateTime.MinValue)
            	step.Scenario.Feature.Area.EndTime = step.EndTime;
			if(step.Scenario.Feature.Area.TestRun.EndTime > DateTime.MinValue)
            	step.Scenario.Feature.Area.TestRun.EndTime = step.EndTime;
        }
        void CascadeEndTime(Scenario scenario)
        {
			if(scenario.Feature.EndTime > DateTime.MinValue)
            	scenario.Feature.EndTime =  scenario.EndTime;
			if(scenario.Feature.Area.EndTime > DateTime.MinValue)
            	scenario.Feature.Area.EndTime = scenario.EndTime;
			if(scenario.Feature.Area.TestRun.EndTime > DateTime.MinValue)
            	scenario.Feature.Area.TestRun.EndTime = scenario.EndTime;
        }
	}
}