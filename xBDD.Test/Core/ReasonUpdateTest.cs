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
    using System.Collections;

    [TestClass]
    public class ReasonUpdateTest
    {        
        [TestMethod]
        public async Task AllPassing()
        {
            var factory = new CoreFactory();
            xB.CurrentRun = factory.CreateTestRunBuilder("Test Run");
            var tr = await TestRunSetup.BuildTestRun();
            var reasons = new List<string>() {
                "Removing",
                "Building",
                "Untested",
                "Ready",
                "Defining"
            };
            xB.CurrentRun.TestRun.UpdateParentReasonsAndStats(reasons);
            this.ValidateTestResuls(tr);
        }

        [TestMethod]
        public async Task OneFailingFirstStepTest()
        {
            var factory = new CoreFactory();
            xB.CurrentRun = factory.CreateTestRunBuilder("Test Run");
            var skippedScenarioIds = new Dictionary<string,string>();
            skippedScenarioIds.Add("010101","Building");
            skippedScenarioIds.Add("010102","Untested");
            skippedScenarioIds.Add("010201","Untested");
            skippedScenarioIds.Add("010202","Ready");
            skippedScenarioIds.Add("010301","Ready");
            skippedScenarioIds.Add("010302","Defining");

            skippedScenarioIds.Add("020101","Building");
            skippedScenarioIds.Add("020201","Untested");
            skippedScenarioIds.Add("020301","Ready");

            var tr = await TestRunSetup.BuildTestRun(null, skippedScenarioIds);
            var reasons = new List<string>() {
                "Removing",
                "Building",
                "Untested",
                "Ready",
                "Defining"
            };
            xB.CurrentRun.TestRun.UpdateParentReasonsAndStats(reasons);
            var statsOverrides = new Dictionary<string, Dictionary<string, int>>();

            statsOverrides.Add("Testrun-areas", new Dictionary<string, int>() {
                {"Defining",1},{"Ready",1}});
            statsOverrides.Add("Testrun-features", new Dictionary<string, int>() {
                {"Building",1},{"Untested",2},{"Ready",2},{"Defining",1}});
            statsOverrides.Add("Testrun-scenarios", new Dictionary<string, int>() {
                {"Building",2},{"Untested",3},{"Ready",3},{"Defining",1}});

            statsOverrides.Add("Area01-features", new Dictionary<string, int>() {
                {"Untested",1},{"Ready",1},{"Defining",1}});
            statsOverrides.Add("Area01-scenarios", new Dictionary<string, int>() {
                {"Building",1},{"Untested",2},{"Ready",2},{"Defining",1}});

            statsOverrides.Add("Area02-features", new Dictionary<string, int>() {
                {"Building",1},{"Untested",1},{"Ready",1}});
            statsOverrides.Add("Area02-scenarios", new Dictionary<string, int>() {
                {"Building",1},{"Untested",1},{"Ready",1}});

            statsOverrides.Add("Feature0101-scenarios", new Dictionary<string, int>() {
                {"Building",1},{"Untested",1}});
            statsOverrides.Add("Feature0102-scenarios", new Dictionary<string, int>() {
                {"Untested",1},{"Ready",1}});
            statsOverrides.Add("Feature0103-scenarios", new Dictionary<string, int>() {
                {"Ready",1},{"Defining",1}});

            statsOverrides.Add("Feature0201-scenarios", new Dictionary<string, int>() {
                {"Building",1}});
            statsOverrides.Add("Feature0202-scenarios", new Dictionary<string, int>() {
                {"Untested",1}});
            statsOverrides.Add("Feature0203-scenarios", new Dictionary<string, int>() {
                {"Ready",1}});

            var outcomeOverrides = new Dictionary<string, string>();
            outcomeOverrides.Add("Testrun", "Defining");
            outcomeOverrides.Add("Area01", "Defining");
            outcomeOverrides.Add("Area02", "Ready");
            outcomeOverrides.Add("Feature0101", "Untested");
            outcomeOverrides.Add("Feature0102", "Ready");
            outcomeOverrides.Add("Feature0103", "Defining");
            outcomeOverrides.Add("Scenario010101", "Building");
            outcomeOverrides.Add("Scenario010102", "Untested");
            outcomeOverrides.Add("Scenario010201", "Untested");
            outcomeOverrides.Add("Scenario010202", "Ready");
            outcomeOverrides.Add("Scenario010301", "Ready");
            outcomeOverrides.Add("Scenario010302", "Defining");
            outcomeOverrides.Add("Feature0201", "Building");
            outcomeOverrides.Add("Feature0202", "Untested");
            outcomeOverrides.Add("Feature0203", "Ready");
            outcomeOverrides.Add("Scenario020101", "Building");
            outcomeOverrides.Add("Scenario020201", "Untested");
            outcomeOverrides.Add("Scenario020301", "Ready");

            this.ValidateTestResuls(tr, statsOverrides, outcomeOverrides);
        }

        public Dictionary<string, int> CopyStats(Dictionary<string, int> stats)
        {
            var copied = new Dictionary<string, int>();
            foreach(var entry in stats) {
                copied.Add(entry.Key, entry.Value);
            }
            return copied;
        }

        public void ValidateTestResuls(TestRun tr, 
            Dictionary<string, Dictionary<string, int>> statsOverrides = null, 
            Dictionary<string, string> reasonOverrides = null)
        {
            if(statsOverrides == null) {
                statsOverrides = new Dictionary<string, Dictionary<string, int>>();
            }
            if(reasonOverrides == null) {
                reasonOverrides = new Dictionary<string, string>();
            }

            string testRunReason = null;
            if(reasonOverrides.ContainsKey("Testrun")) {
                testRunReason = reasonOverrides["Testrun"];
            }
            Assert.AreEqual(tr.Reason, testRunReason);
            
            var testRunAreaStats = new Dictionary<string, int>();
            if(statsOverrides.ContainsKey("Testrun-areas")) {
                testRunAreaStats = statsOverrides["Testrun-areas"];
            }
            this.ValidateStats(tr.AreaReasonStats, testRunAreaStats);
            
            var testRunFeatureStats = new Dictionary<string, int>();
            if(statsOverrides.ContainsKey("Testrun-features")) {
                testRunFeatureStats = statsOverrides["Testrun-features"];
            }
            this.ValidateStats(tr.FeatureReasonStats, testRunFeatureStats);
            
            var testRunScenarioStats = new Dictionary<string, int>();
            if(statsOverrides.ContainsKey("Testrun-scenarios")) {
                testRunScenarioStats = statsOverrides["Testrun-scenarios"];
            }
            this.ValidateStats(tr.ScenarioReasonStats, testRunScenarioStats);
            
            tr.Areas.ForEach(area => {
                this.ValidateArea(area, statsOverrides, reasonOverrides);
            });
        }

        public void ValidateArea(Area area, Dictionary<string, Dictionary<string, int>> statsOverrides, Dictionary<string, string> reasonOverrides)
        {
            string areaReason = null;
            if(reasonOverrides.ContainsKey(area.Name)) {
                areaReason = reasonOverrides[area.Name];
            }
            Assert.AreEqual(area.Reason, areaReason);

            var areaFeatureStats = new Dictionary<string, int>();
            if(statsOverrides.ContainsKey($"{area.Name}-features")) {
                areaFeatureStats = statsOverrides[$"{area.Name}-features"];
            }
            this.ValidateStats(area.FeatureReasonStats, areaFeatureStats);
            
            var areaScenarioStats = new Dictionary<string, int>();
            if(statsOverrides.ContainsKey($"{area.Name}-scenarios")) {
                areaScenarioStats = statsOverrides[$"{area.Name}-scenarios"];
            }
            this.ValidateStats(area.ScenarioReasonStats, areaScenarioStats);
            
            area.Features.ForEach(feature => {
                this.ValidateFeature(feature, statsOverrides, reasonOverrides);
            });
        }

        public void ValidateFeature(Feature feature, Dictionary<string, Dictionary<string, int>> statsOverrides, Dictionary<string, string> reasonOverrides)
        {
            string featureReason = null;
            if(reasonOverrides.ContainsKey(feature.Name)) {
                featureReason = reasonOverrides[feature.Name];
            }
            Assert.AreEqual(feature.Reason, featureReason);

            var featureScenarioStats = new Dictionary<string, int>();
            if(statsOverrides.ContainsKey($"{feature.Name}-scenarios")) {
                featureScenarioStats = statsOverrides[$"{feature.Name}-scenarios"];
            }
            this.ValidateStats(feature.ScenarioReasonStats, featureScenarioStats);
            
            feature.Scenarios.ForEach(scenario => {
                string scenarioReason = null;
                if(reasonOverrides.ContainsKey(scenario.Name)) {
                    scenarioReason = reasonOverrides[scenario.Name];
                }
                Assert.AreEqual(scenario.Reason, scenarioReason);
            });
        }

        public void ValidateStats(Dictionary<string, int> stats, Dictionary<string, int> statsExpect)
        {
            Assert.IsTrue(stats.Count == statsExpect.Count);
            foreach(var expectStat in stats) {
                Assert.IsTrue(stats.Keys.Contains(expectStat.Key));
                Assert.IsTrue(stats[expectStat.Key] == expectStat.Value);
            }
        }
    }
}
