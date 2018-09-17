namespace xBDD.Importing.Json
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using xBDD.Model;
    using xBDD;
    /// <summary>
    /// Converts json to a TestRun object.
    /// </summary>
    public class JsonImporter
    {
        /// <summary>
        /// Creates a test run object from a text file.
        /// </summary>
        /// <param name="text">The json to import.</param>
        /// <returns>TestRun object hydrated from the json.</returns>
        public TestRun ImportJson(string text) {
            var bytes = Encoding.UTF8.GetBytes(text);
            TestRun tr = null;
            using ( var stream = new MemoryStream( bytes ) )
            {
                var serializer = new DataContractJsonSerializer(typeof(TestRun));
                tr = (TestRun)serializer.ReadObject(stream);
				tr.CapabilityReasonStats = new System.Collections.Generic.Dictionary<string, int>();
				tr.CapabilityStats = new OutcomeStats();
				tr.FeatureReasonStats = new System.Collections.Generic.Dictionary<string, int>();
				tr.FeatureStats = new OutcomeStats();
				tr.ScenarioReasonStats = new System.Collections.Generic.Dictionary<string, int>();
				tr.ScenarioStats = new OutcomeStats();
				tr.StepStats = new OutcomeStats();
				tr.Capabilities.ForEach(capability => {
					capability.TestRun = tr;
					capability.FeatureReasonStats = new System.Collections.Generic.Dictionary<string, int>();
					capability.FeatureStats = new OutcomeStats();
					capability.ScenarioReasonStats = new System.Collections.Generic.Dictionary<string, int>();
					capability.ScenarioStats = new OutcomeStats();
					capability.StepStats = new OutcomeStats();
					capability.Features.ForEach(feature => {
						feature.Capability = capability;
						feature.ScenarioReasonStats = new System.Collections.Generic.Dictionary<string, int>();
						feature.ScenarioStats = new OutcomeStats();
						feature.StepStats = new OutcomeStats();
						feature.Scenarios.ForEach(scenario => {
							scenario.Feature = feature;
							scenario.StepStats = new OutcomeStats();
							scenario.Steps.ForEach(step => {
								step.Scenario = scenario;
							});
						});
					});
				});
            }
            return tr;   
        }
    }
}