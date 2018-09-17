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
		internal void CascadeStepStats(Step step, bool scenarioSkipped)
		{
			CascadeStepOutcome(step, scenarioSkipped);
			CascadeStepStartTime(step);
			CascadeStepEndTime(step);
		}
		internal void CascadeSkippedOrNotRunScenarioStats(Scenario scenario)
		{
			CascadeNotRunScenarioOutcome(scenario);
			CascadeStartTime(scenario);
			CascadeEndTime(scenario);
		}
        private void CascadeStepOutcome(Step step, bool scenarioSkipped)
        {
            UpdateMultipleStats(Outcome.NotRun, step.Outcome,
				step.Scenario.StepStats,
                step.Scenario.Feature.StepStats,
                step.Scenario.Feature.Capability.StepStats,
                step.Scenario.Feature.Capability.TestRun.StepStats);
            CascadeScenarioOutcome(step, scenarioSkipped);
			CascadeFeatureOutcome(step);
			CascadeCapabilityOutcome(step);
            step.Scenario.Feature.Capability.TestRun.Outcome = outcomeAggregator.GetNewParentOutcome(
				step.Scenario.Feature.Capability.TestRun.Outcome, 
				step.Scenario.Feature.Capability.Outcome);
        }
        private void CascadeNotRunScenarioOutcome(Scenario scenario)
        {
            UpdateMultipleStats(Outcome.NotRun, scenario.Outcome,
                scenario.Feature.ScenarioStats,
                scenario.Feature.Capability.ScenarioStats,
                scenario.Feature.Capability.TestRun.ScenarioStats);
			CascadeFeatureOutcome(scenario);
			CascadeCapabilityOutcome(scenario);
            scenario.Feature.Capability.TestRun.Outcome = outcomeAggregator.GetNewParentOutcome(
				scenario.Feature.Capability.TestRun.Outcome, 
				scenario.Feature.Capability.Outcome);
        }
        private void CascadeScenarioOutcome(Step step, bool scenarioSkipped)
        {
            var scenarioOutcome = step.Scenario.Outcome;
            step.Scenario.Outcome = outcomeAggregator.GetNewScenarioOutcome(
				step.Scenario.Outcome, 
				step.Outcome, 
				scenarioSkipped);
            UpdateMultipleStats(scenarioOutcome, 
				step.Scenario.Outcome,
                step.Scenario.Feature.ScenarioStats,
                step.Scenario.Feature.Capability.ScenarioStats,
                step.Scenario.Feature.Capability.TestRun.ScenarioStats);
        }
        private void CascadeFeatureOutcome(Step step)
        {
            var featureOutcome = step.Scenario.Feature.Outcome;
            step.Scenario.Feature.Outcome = outcomeAggregator.GetNewParentOutcome(
				step.Scenario.Feature.Outcome, 
				step.Scenario.Outcome);
            UpdateMultipleStats(featureOutcome, step.Scenario.Feature.Outcome,
                step.Scenario.Feature.Capability.FeatureStats,
                step.Scenario.Feature.Capability.TestRun.FeatureStats);
        }
        private void CascadeFeatureOutcome(Scenario scenario)
        {
            var featureOutcome = scenario.Feature.Outcome;
            scenario.Feature.Outcome = outcomeAggregator.GetNewParentOutcome(
				scenario.Feature.Outcome, 
				scenario.Outcome);
            UpdateMultipleStats(featureOutcome, scenario.Feature.Outcome,
                scenario.Feature.Capability.FeatureStats,
                scenario.Feature.Capability.TestRun.FeatureStats);
        }
        private void CascadeCapabilityOutcome(Step step)
        {
            var capabilityOutcome = step.Scenario.Feature.Capability.Outcome;
            step.Scenario.Feature.Capability.Outcome = outcomeAggregator.GetNewParentOutcome(
				step.Scenario.Feature.Capability.Outcome, 
				step.Scenario.Feature.Outcome);
            UpdateMultipleStats(capabilityOutcome, step.Scenario.Feature.Capability.Outcome,
                step.Scenario.Feature.Capability.TestRun.CapabilityStats);
        }

        private void CascadeCapabilityOutcome(Scenario scenario)
        {
            var capabilityOutcome = scenario.Feature.Capability.Outcome;
            scenario.Feature.Capability.Outcome = outcomeAggregator.GetNewParentOutcome(
				scenario.Feature.Capability.Outcome, scenario.Feature.Outcome);
            UpdateMultipleStats(capabilityOutcome, scenario.Feature.Capability.Outcome,
                scenario.Feature.Capability.TestRun.CapabilityStats);
        }

        private void UpdateMultipleStats(Outcome previousOutcome, Outcome newOutcome, params OutcomeStats[] stats)
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


        private void CascadeStepStartTime(Step step)
        {
			if(step.Scenario.StartTime.Equals(DateTime.MinValue) || step.Scenario.StartTime > step.StartTime)
            	step.Scenario.StartTime = step.StartTime;
			if(step.Scenario.Feature.StartTime.Equals(DateTime.MinValue) || step.Scenario.Feature.StartTime > step.StartTime)
            	step.Scenario.Feature.StartTime = step.StartTime;
			if(step.Scenario.Feature.Capability.StartTime.Equals(DateTime.MinValue) || step.Scenario.Feature.Capability.StartTime > step.StartTime)
            	step.Scenario.Feature.Capability.StartTime = step.StartTime;
			if(step.Scenario.Feature.Capability.TestRun.StartTime.Equals(DateTime.MinValue) || step.Scenario.Feature.Capability.TestRun.StartTime > step.StartTime)
            	step.Scenario.Feature.Capability.TestRun.StartTime =  step.StartTime;
        }
        private void CascadeStartTime(Scenario scenario)
        {
			if(scenario.Feature.StartTime.Equals(DateTime.MinValue) || scenario.Feature.StartTime > scenario.StartTime)
            	scenario.Feature.StartTime = scenario.StartTime;
			if(scenario.Feature.Capability.StartTime.Equals(DateTime.MinValue) || scenario.Feature.Capability.StartTime > scenario.StartTime)
            	scenario.Feature.Capability.StartTime = scenario.StartTime;
			if(scenario.Feature.Capability.TestRun.StartTime.Equals(DateTime.MinValue) || scenario.Feature.Capability.TestRun.StartTime > scenario.StartTime)
            	scenario.Feature.Capability.TestRun.StartTime =  scenario.StartTime;
        }
        private void CascadeStepEndTime(Step step)
        {
			if(step.Scenario.EndTime > DateTime.MinValue)
            	step.Scenario.EndTime =  step.EndTime;
			if(step.Scenario.Feature.EndTime > DateTime.MinValue)
            	step.Scenario.Feature.EndTime =  step.EndTime;
			if(step.Scenario.Feature.Capability.EndTime > DateTime.MinValue)
            	step.Scenario.Feature.Capability.EndTime = step.EndTime;
			if(step.Scenario.Feature.Capability.TestRun.EndTime > DateTime.MinValue)
            	step.Scenario.Feature.Capability.TestRun.EndTime = step.EndTime;
        }
        private void CascadeEndTime(Scenario scenario)
        {
			if(scenario.Feature.EndTime > DateTime.MinValue)
            	scenario.Feature.EndTime =  scenario.EndTime;
			if(scenario.Feature.Capability.EndTime > DateTime.MinValue)
            	scenario.Feature.Capability.EndTime = scenario.EndTime;
			if(scenario.Feature.Capability.TestRun.EndTime > DateTime.MinValue)
            	scenario.Feature.Capability.TestRun.EndTime = scenario.EndTime;
        }
	}
}