using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace xBDD.Test
{
    using xBDD.Core;
    using xBDD.Model;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [TestClass]
    public class StatsCascaderTest
    {
        private OutcomeStats defaultLevel1 = new OutcomeStats(){Total=3,Passed=3,Skipped=0,Failed=0};
        private OutcomeStats defaultLevel2 = new OutcomeStats(){Total=9,Passed=9,Skipped=0,Failed=0};
        private OutcomeStats defaultLevel3 = new OutcomeStats(){Total=27,Passed=27,Skipped=0,Failed=0};
        private OutcomeStats defaultLevel4 = new OutcomeStats(){Total=81,Passed=81,Skipped=0,Failed=0};
        
        [TestMethod]
        public async Task AllPassing()
        {
            var tr = await TestRunSetup.BuildTestRun();
            this.ValidateTestResuls(tr);
        }

        [TestMethod]
        public async Task OneFailingFirstStepTest()
        {
            var failingStepIds = new List<string>(){"1-1-1-1"};
            var tr = await TestRunSetup.BuildTestRun(failingStepIds);
            var statsOverrides = new Dictionary<string, OutcomeStats>();

            statsOverrides.Add("testrun-areas", new OutcomeStats() {Total = 3, Passed = 2, Skipped = 0, Failed = 1});
            statsOverrides.Add("testrun-features", new OutcomeStats() {Total = 9, Passed = 8, Skipped = 0, Failed = 1});
            statsOverrides.Add("testrun-scenarios", new OutcomeStats() {Total = 27, Passed = 26, Skipped = 0, Failed = 1});
            statsOverrides.Add("testrun-steps", new OutcomeStats() {Total = 81, Passed = 78, Skipped = 2, Failed = 1});

            statsOverrides.Add("area 1-features", new OutcomeStats() {Total = 3, Passed = 2, Skipped = 0, Failed = 1});
            statsOverrides.Add("area 1-scenarios", new OutcomeStats() {Total = 9, Passed = 8, Skipped = 0, Failed = 1});
            statsOverrides.Add("area 1-steps", new OutcomeStats() {Total = 27, Passed = 24, Skipped = 2, Failed = 1});

            statsOverrides.Add("feature 1 1-scenarios", new OutcomeStats() {Total = 3, Passed = 2, Skipped = 0, Failed = 1});
            statsOverrides.Add("feature 1 1-steps", new OutcomeStats() {Total = 9, Passed = 6, Skipped = 2, Failed = 1});

            statsOverrides.Add("scenario 1 1 1-steps", new OutcomeStats() {Total = 3, Passed = 0, Skipped = 2, Failed = 1});

            var outcomeOverrides = new Dictionary<string, Outcome>();
            outcomeOverrides.Add("testrun", Outcome.Failed);
            outcomeOverrides.Add("area 1", Outcome.Failed);
            outcomeOverrides.Add("feature 1 1", Outcome.Failed);
            outcomeOverrides.Add("scenario 1 1 1", Outcome.Failed);
            outcomeOverrides.Add("step-1-1-1-1", Outcome.Failed);
            outcomeOverrides.Add("step-1-1-1-2", Outcome.Skipped);
            outcomeOverrides.Add("step-1-1-1-3", Outcome.Skipped);

            this.ValidateTestResuls(tr, statsOverrides, outcomeOverrides);
        }

        public OutcomeStats CopyStats(OutcomeStats stats)
        {
            return new OutcomeStats() { Total = stats.Total, Passed = stats.Passed, Skipped = stats.Skipped, Failed = stats.Failed };
        }

        public void ValidateTestResuls(TestRun tr, 
            Dictionary<string, OutcomeStats> statsOverrides = null, 
            Dictionary<string, Outcome> outcomeOverrides = null)
        {
            if(statsOverrides == null) {
                statsOverrides = new Dictionary<string, OutcomeStats>();
            }
            if(outcomeOverrides == null) {
                outcomeOverrides = new Dictionary<string, Outcome>();
            }

            var testRunOutcome = Outcome.Passed;
            if(outcomeOverrides.ContainsKey("testrun")) {
                testRunOutcome = outcomeOverrides["testrun"];
            }
            Assert.AreEqual(tr.Outcome, testRunOutcome);
            
            var testRunAreaStats = this.CopyStats(defaultLevel1);
            if(statsOverrides.ContainsKey("testrun-areas")) {
                testRunAreaStats = statsOverrides["testrun-areas"];
            }
            this.ValidateStats(tr.AreaStats, testRunAreaStats);
            
            var testRunFeatureStats = this.CopyStats(defaultLevel2);
            if(statsOverrides.ContainsKey("testrun-features")) {
                testRunFeatureStats = statsOverrides["testrun-features"];
            }
            this.ValidateStats(tr.FeatureStats, testRunFeatureStats);
            
            var testRunScenarioStats = this.CopyStats(defaultLevel3);
            if(statsOverrides.ContainsKey("testrun-scenarios")) {
                testRunScenarioStats = statsOverrides["testrun-scenarios"];
            }
            this.ValidateStats(tr.ScenarioStats, testRunScenarioStats);
            
            var testRunStepStats = this.CopyStats(defaultLevel4);
            if(statsOverrides.ContainsKey("testrun-steps")) {
                testRunStepStats = statsOverrides["testrun-steps"];
            }
            this.ValidateStats(tr.StepStats, testRunStepStats);
            
            tr.Areas.ForEach(area => {
                this.ValidateArea(area, statsOverrides, outcomeOverrides);
            });
        }

        public void ValidateArea(Area area, Dictionary<string, OutcomeStats> statsOverrides, Dictionary<string, Outcome> outcomeOverrides)
        {
            var areaOutcome = Outcome.Passed;
            if(outcomeOverrides.ContainsKey(area.Name)) {
                areaOutcome = outcomeOverrides[area.Name];
            }
            Assert.AreEqual(area.Outcome, areaOutcome);

            var areaFeatureStats = this.CopyStats(defaultLevel1);
            if(statsOverrides.ContainsKey($"{area.Name}-features")) {
                areaFeatureStats = statsOverrides[$"{area.Name}-features"];
            }
            this.ValidateStats(area.FeatureStats, areaFeatureStats);
            
            var areaScenarioStats = this.CopyStats(defaultLevel2);
            if(statsOverrides.ContainsKey($"{area.Name}-scenarios")) {
                areaScenarioStats = statsOverrides[$"{area.Name}-scenarios"];
            }
            this.ValidateStats(area.ScenarioStats, areaScenarioStats);
            
            var areaStepStats = this.CopyStats(defaultLevel3);
            if(statsOverrides.ContainsKey($"{area.Name}-steps")) {
                areaStepStats = statsOverrides[$"{area.Name}-steps"];
            }
            this.ValidateStats(area.StepStats, areaStepStats);
            
            area.Features.ForEach(feature => {
                this.ValidateFeature(feature, statsOverrides, outcomeOverrides);
            });
        }

        public void ValidateFeature(Feature feature, Dictionary<string, OutcomeStats> statsOverrides, Dictionary<string, Outcome> outcomeOverrides)
        {
            var featureOutcome = Outcome.Passed;
            if(outcomeOverrides.ContainsKey(feature.Name)) {
                featureOutcome = outcomeOverrides[feature.Name];
            }
            Assert.AreEqual(feature.Outcome, featureOutcome);

            var featureScenarioStats = this.CopyStats(defaultLevel1);
            if(statsOverrides.ContainsKey($"{feature.Name}-scenarios")) {
                featureScenarioStats = statsOverrides[$"{feature.Name}-scenarios"];
            }
            this.ValidateStats(feature.ScenarioStats, featureScenarioStats);
            
            var featureStepStats = this.CopyStats(defaultLevel2);
            if(statsOverrides.ContainsKey($"{feature.Name}-steps")) {
                featureStepStats = statsOverrides[$"{feature.Name}-steps"];
            }
            this.ValidateStats(feature.StepStats, featureStepStats);
            
            feature.Scenarios.ForEach(scenario => {
                this.ValidateScenario(scenario, statsOverrides, outcomeOverrides);
            });
        }

        public void ValidateScenario(Scenario scenario, 
            Dictionary<string, OutcomeStats> statsOverrides, 
            Dictionary<string, Outcome> outcomeOverrides)
        {
            var scenarioOutcome = Outcome.Passed;
            if(outcomeOverrides.ContainsKey(scenario.Name)) {
                scenarioOutcome = outcomeOverrides[scenario.Name];
            }
            Assert.AreEqual(scenario.Outcome, scenarioOutcome);

            var scenarioStepStats = this.CopyStats(defaultLevel1);
            if(statsOverrides.ContainsKey($"{scenario.Name}-steps")) {
                scenarioStepStats = statsOverrides[$"{scenario.Name}-steps"];
            }
            this.ValidateStats(scenario.StepStats, scenarioStepStats);
            
            scenario.Steps.ForEach(step => {
                var stepOutcome = Outcome.Passed;
                if(outcomeOverrides.ContainsKey(step.Name)) {
                    stepOutcome = outcomeOverrides[step.Name];
                }
                Assert.AreEqual(step.Outcome, stepOutcome);
            });
        }

        public void ValidateStats(OutcomeStats stats, OutcomeStats statsExpect)
        {
            Assert.AreEqual(stats.Total, statsExpect.Total);
            Assert.AreEqual(stats.Passed, statsExpect.Passed);
            Assert.AreEqual(stats.Skipped, statsExpect.Skipped);
            Assert.AreEqual(stats.Failed, statsExpect.Failed);
        }
    }
}
