using System;
using xBDD.Model;
using xBDD.Utility;
namespace xBDD.Core

{
	internal class StatsCascader
	{
        Utility.OutcomeAggregator outcomeAggregator;
		internal StatsCascader(UtilityFactory factory)
		{
			outcomeAggregator = factory.CreateOutcomeAggregator();
		}
		internal void CascadeStats(Step step, bool scenarioSkipped)
		{
			CascadeOutcome(step, scenarioSkipped);
			CascadeStartTime(step);
			CascadeEndTime(step);
		}
		internal void CascadeStats(Scenario scenario)
		{
			CascadeOutcome(scenario);
			CascadeStartTime(scenario);
			CascadeEndTime(scenario);
		}
        private void CascadeOutcome(Step step, bool scenarioSkipped)
        {
            UpdateOutcome(Outcome.NotRun, step.Outcome,
				step.Scenario.StepStats,
                step.Scenario.Feature.StepStats,
                step.Scenario.Feature.Area.StepStats,
                step.Scenario.Feature.Area.TestRun.StepStats);
            CascadeScenarioOutcome(step, scenarioSkipped);
			CascadeFeatureOutcome(step);
			CascadeAreaOutcome(step);
            step.Scenario.Feature.Area.TestRun.Outcome = outcomeAggregator.GetNewParentOutcome(step.Scenario.Feature.Area.Outcome, step.Scenario.Feature.Outcome);
        }
        private void CascadeOutcome(Scenario scenario)
        {
            UpdateOutcome(Outcome.NotRun, scenario.Outcome,
                scenario.Feature.ScenarioStats,
                scenario.Feature.Area.ScenarioStats,
                scenario.Feature.Area.TestRun.ScenarioStats);
			CascadeFeatureOutcome(scenario);
			CascadeAreaOutcome(scenario);
            scenario.Feature.Area.TestRun.Outcome = outcomeAggregator.GetNewParentOutcome(scenario.Feature.Area.Outcome, scenario.Feature.Outcome);
        }
        private void CascadeScenarioOutcome(Step step, bool scenarioSkipped)
        {
            var scenarioOutcome = step.Scenario.Outcome;
            step.Scenario.Outcome = outcomeAggregator.GetNewScenarioOutcome(step.Scenario.Outcome, step.Outcome, scenarioSkipped);
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
            scenario.Feature.Area.Outcome = outcomeAggregator.GetNewParentOutcome(
				scenario.Feature.Area.Outcome, scenario.Feature.Outcome);
            UpdateOutcome(areaOutcome, scenario.Feature.Area.Outcome,
                scenario.Feature.Area.TestRun.AreaStats);
        }

        private void UpdateOutcome(Outcome previousOutcome, Outcome newOutcome, params OutcomeStats[] stats)
		{
			if(previousOutcome != newOutcome)
			{
				foreach(var stat in stats)
				{
					UpdateStats(previousOutcome, newOutcome, stat);
				}
			}
		}
		
		private void UpdateStats(Outcome previousOutcome, Outcome newOutcome, OutcomeStats stats)
		{
			DecrementStat(previousOutcome, stats);
			IncrementStat(newOutcome, stats);
		}

        private void DecrementStat(Outcome previousOutcome, OutcomeStats stats)
        {
            switch (previousOutcome)
			{
				case Outcome.Failed:
					stats.Failed--;
					stats.Total--;
					break;
				case Outcome.NotRun:
					break;
				case Outcome.Passed:
					stats.Passed--;
					stats.Total--;
					break;
				case Outcome.Skipped:
					stats.Skipped--;
					stats.Total--;
					break;
			}
        }
        private void IncrementStat(Outcome newOutcome, OutcomeStats stats)
        {
            switch (newOutcome)
			{
				case Outcome.Failed:
					stats.Failed++;
					stats.Total++;
					break;
				case Outcome.NotRun:
					break;
				case Outcome.Passed:
					stats.Passed++;
					stats.Total++;
					break;
				case Outcome.Skipped:
					stats.Skipped++;
					stats.Total++;
					break;
			}
        }


        private void CascadeStartTime(Step step)
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
        private void CascadeStartTime(Scenario scenario)
        {
			if(scenario.Feature.StartTime.Equals(DateTime.MinValue) || scenario.Feature.StartTime > scenario.StartTime)
            	scenario.Feature.StartTime = scenario.StartTime;
			if(scenario.Feature.Area.StartTime.Equals(DateTime.MinValue) || scenario.Feature.Area.StartTime > scenario.StartTime)
            	scenario.Feature.Area.StartTime = scenario.StartTime;
			if(scenario.Feature.Area.TestRun.StartTime.Equals(DateTime.MinValue) || scenario.Feature.Area.TestRun.StartTime > scenario.StartTime)
            	scenario.Feature.Area.TestRun.StartTime =  scenario.StartTime;
        }
        private void CascadeEndTime(Step step)
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
        private void CascadeEndTime(Scenario scenario)
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