namespace xBDD
{
    using System.Globalization;
    using System.Threading.Tasks;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using System.Threading;
	using System.Collections.Generic;
    using xBDD.Model;
    using xBDD.Reporting;
    using xBDD.Reporting.Html;
    using xBDD.Reporting.Text;
    using xBDD.Reporting.Database;
    using xBDD.Reporting.Database.Core;
    using xBDD.Reporting.Code;
    using xBDD.Reporting.Outline;

    /// <summary>
    /// List of extension methods for the TestRun class.
    /// </summary>
    public static class TestRunExtensions
    {
        /// <summary>
        /// Calculates the start and end time for the test run, 
        /// areas, and features.
        /// </summary>
        /// <param name="testrun">The test run to set the start and end times for.</param>
        public static void CalculateStartAndEndTimes(this xBDD.Model.TestRun testrun)
        {
            testrun.Areas.ForEach(area => {
                var featuresStart = area.Features.OrderBy(feature => feature.StartTime);
                featuresStart.ToList().ForEach(feature => {
                    var scenariosStart = feature.Scenarios.OrderBy(scenario => scenario.StartTime);
                    feature.StartTime = scenariosStart.First().StartTime;
                    var scenariosEnd = feature.Scenarios.OrderByDescending(scenario => scenario.EndTime);
                    feature.EndTime = scenariosEnd.First().EndTime;
                });
                area.StartTime = featuresStart.First().StartTime;
                var featuresEnd = area.Features.OrderByDescending(feature => feature.EndTime);
                area.EndTime = featuresEnd.First().EndTime;
            });
            if(testrun.Areas.Count > 0) {
                var areasStart = testrun.Areas.OrderBy(area => area.StartTime);
                testrun.StartTime = areasStart.First().StartTime;
                var areasEnd = testrun.Areas.OrderByDescending(area => area.EndTime);
                testrun.EndTime = areasEnd.First().EndTime;
            }
        }
        /// <summary>
        /// Writes a text representation of a test run's test results.
        /// </summary>
        /// <param name="testRun">The test run whose results you want to write to text.</param>
        /// <param name="includeExceptions">Sets the text writer to include 
        /// exceptions for failed steps. Default value is true.</param>
        /// <returns>String that is a multiline text format of the test results.</returns>
        public static string WriteToText(this xBDD.Model.TestRun testRun, bool includeExceptions = true)
        {
            ReportingFactory factory = new ReportingFactory();
            TextWriter saver = factory.GetTextWriter();
            return saver.WriteToText(testRun, includeExceptions);
        }

        /// <summary>
        /// Writes an OMPL representation of a test run's test results.
        /// </summary>
        /// <param name="testRun">The test run whose results you want to write to text.</param>
        /// <param name="areaNameClip">The part to remove from the beginning of each area name.</param>
        /// <returns>String that is a OPML format of the test results.</returns>
        public static string WriteToOpml(this xBDD.Model.TestRun testRun, string areaNameClip = null)
        {
            ReportingFactory factory = new ReportingFactory();
            OpmlWriter saver = factory.GetOpmlWriter();
            return saver.WriteToOpml(testRun, areaNameClip);
        }

        /// <summary>
        /// Writes a code representation of a test run's test results.
        /// This includes all the files for a fully functional test project.
        /// The generated code files can be used to execute a test run that
        /// would regenerate the test results.
        /// </summary>
        /// <param name="testRun">The test run whose results you want to write to code.</param>
        /// <param name="rootNamespace">The root namespace to use for generating the project files.</param>
        /// <param name="directory">The directory to write the files to.</param>
        /// <param name="removeFromAreaNameStart">Sets the Remove Area Name Start setting for xBDD.</param>
        public static void WriteToCode(this xBDD.Model.TestRun testRun, string rootNamespace, string directory, string removeFromAreaNameStart)
        {
            ReportingFactory factory = new ReportingFactory();
            CodeWriter saver = factory.GetCodeWriter();
            saver.WriteToCode(testRun, rootNamespace, directory, removeFromAreaNameStart);
        }

        /// <summary>
        /// Writes a code representation of a test run's test results.
        /// This includes all the files for a fully functional test project.
        /// The generated code files can be used to execute a test run that
        /// would regenerate the test results.
        /// </summary>
        /// <param name="testRun">The test run whose results you want to write to code.</param>
        /// <param name="rootNamespace">The root namespace to use for generating the project files.</param>
        /// <param name="directory">The directory to write the files to.</param>
        public static void WriteFeaturesToCode(this xBDD.Model.TestRun testRun, string rootNamespace, string directory)
        {
            ReportingFactory factory = new ReportingFactory();
            CodeWriter saver = factory.GetCodeWriter();
            saver.WriteFeaturesToCode(testRun, rootNamespace, directory);
        }

        /// <summary>
        /// Writes a text representation of a test run's test results.
        /// </summary>
        /// <param name="testRun">The test run whose results you want to write to text.</param>
        /// <param name="removeFromAreaNameStart">The starting part of the area names you want to remove.</param>
        /// <param name="failuresOnly">Tells the html writer to only write out failed scenarios.</param>
        /// <returns>String that is a multiline text format of the test results.</returns>
        public static string WriteToHtmlTestRunReport(this xBDD.Model.TestRun testRun, string removeFromAreaNameStart = "", bool failuresOnly = false)
        {
            ReportingFactory factory = new ReportingFactory();
            HtmlTestRunReportWriter saver = factory.GetHtmlTestRunReportWriter(removeFromAreaNameStart, failuresOnly);
            return saver.WriteToHtmlTestRunReport(testRun);
        }
        /// <summary>
        /// Writes a a test run's test results to a sql database.
        /// </summary>
        /// <param name="testRun">The test run whose results you want to write to the database.</param>
        /// <param name="connectionName">The name of the connection string to use to connect to the database.</param>
        /// <remarks>By default xBDD will look for a connection string in a config.json file or the 
        /// environment variables settings with a name: Data:DefaultConnection:ConnectionString</remarks>
        /// <returns>Count of scenarios written to the database.</returns>
        public static int SaveToDatabase(this xBDD.Model.TestRun testRun, string connectionName)
        {
            DatabaseFactory factory = new DatabaseFactory();
            TestRunDatabaseSaver saver = factory.CreateTestRunDatabaseSaver(connectionName);
            return saver.SaveTestRun(testRun);
        }
        /// <summary>
        /// Writes the test run results to json.
        /// Only writes the bare minimum properties and does not 
        /// write calculated properties like test stats.
        /// </summary>
        /// <param name="testRun">The test run to serialize.</param>
        /// <param name="addIndentation">Adds indentation to the json.</param>
        /// <returns>A json string representation of the test results.</returns>
        public static string WriteToJson(this xBDD.Model.TestRun testRun, bool addIndentation = false)
        {
            var json = "";
            using(var ms = new System.IO.MemoryStream()) {
                using(var writer = JsonReaderWriterFactory.CreateJsonWriter(ms, Encoding.UTF8, true, addIndentation))
                {
                    var currentCulture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
                    try {
                        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Model.TestRun));  
                        ser.WriteObject(writer, testRun);
                        writer.Flush();
                        byte[] jsonBytes = ms.ToArray();
                        json = Encoding.UTF8.GetString(jsonBytes, 0, jsonBytes.Length);
                    } finally {
                        Thread.CurrentThread.CurrentCulture = currentCulture;
                    }
                }
            }
            return json;
        }
        /// <summary>
        /// Cascades the scenario skipped reasons up the hierarchy.
        /// Also calculates the count of children for each skipped reason.
        /// </summary>
        /// <param name="sortedReasons">The list of reasons sorted from least to highest precedent.
        /// <param name="testRun">The test run to update parent reasons and stats for.</param> 
        /// A parent that has both reasons will assume the reason with the highest precedent.</param>
        public static void UpdateParentReasonsAndStats(this xBDD.Model.TestRun testRun, List<string> sortedReasons)
        {
            if(!sortedReasons.Contains("Failed"))
                sortedReasons.Add("Failed");

            var additionalReasons = testRun.Scenarios
                .Select(scenario => scenario.Reason)
                .Distinct()
                .Where(reason => !sortedReasons.Contains(reason) && reason != null)
                .OrderBy(reason => reason)
                .ToList();

            sortedReasons.InsertRange(0,additionalReasons);

            sortedReasons.ForEach(reason => {
                testRun.Scenarios
                    .Where(scenario => scenario.Reason == reason)
                    .ToList().ForEach(scenario => {
                        scenario.Feature.Reason = reason;
                        if(scenario.Feature.ScenarioReasonStats.Keys.Contains(reason)) {
                            scenario.Feature.ScenarioReasonStats[reason] = scenario.Feature.ScenarioReasonStats[reason] + 1;
                        } else {
                            scenario.Feature.ScenarioReasonStats.Add(reason, 1);
                        }
                        scenario.Feature.Area.Reason = reason;
                        if(scenario.Feature.Area.ScenarioReasonStats.Keys.Contains(reason)) {
                            scenario.Feature.Area.ScenarioReasonStats[reason] = scenario.Feature.Area.ScenarioReasonStats[reason] + 1;
                        } else {
                            scenario.Feature.Area.ScenarioReasonStats.Add(reason, 1);
                        }
                        testRun.Reason = reason;
                        if(testRun.ScenarioReasonStats.Keys.Contains(reason)) {
                            testRun.ScenarioReasonStats[reason] = testRun.ScenarioReasonStats[reason] + 1;
                        } else {
                            testRun.ScenarioReasonStats.Add(reason, 1);
                        }
                    });
                
            });

            sortedReasons.ForEach(reason => {
                testRun.Scenarios.
                    Select(scenario => scenario.Feature)
                    .ToList()
                    .Where(feature => feature.Reason == reason)
                    .ToList().ForEach(feature => {
                        if(feature.Area.FeatureReasonStats.Keys.Contains(reason)) {
                            feature.Area.FeatureReasonStats[reason] = feature.Area.FeatureReasonStats[reason] + 1;
                        } else {
                            feature.Area.FeatureReasonStats.Add(reason, 1);
                        }
                        if(testRun.FeatureReasonStats.Keys.Contains(reason)) {
                            testRun.FeatureReasonStats[reason] = testRun.FeatureReasonStats[reason] + 1;
                        } else {
                            testRun.FeatureReasonStats.Add(reason, 1);
                        }
                    });
                
            });

            sortedReasons.ForEach(reason => {
                testRun.Areas
                    .Where(area => area.Reason == reason)
                    .ToList().ForEach(area => {
                        if(testRun.AreaReasonStats.Keys.Contains(reason)) {
                            testRun.AreaReasonStats[reason] = testRun.AreaReasonStats[reason] + 1;
                        } else {
                            testRun.AreaReasonStats.Add(reason, 1);
                        }
                    });
                
            });
        }

        private static void UpdateOutcomeStats(this OutcomeStats stats, Outcome outcome) {
            switch(outcome) {
                case Outcome.Failed:
                    stats.Failed = stats.Failed + 1;
                    stats.Total = stats.Total + 1;
                break;
                case Outcome.Skipped:
                    stats.Skipped = stats.Skipped + 1;
                    stats.Total = stats.Total + 1;
                break;
                case Outcome.Passed:
                    stats.Passed = stats.Passed + 1;
                    stats.Total = stats.Total + 1;
                break;
            }
        }

        private static void ClearStats(this OutcomeStats stats) {
            stats.Total = 0;
            stats.Failed = 0;
            stats.Passed = 0;
            stats.Skipped = 0;
        }

        /// <summary>
        /// Updates the feature, area, and test outcomes and stats based on the scenario outcomes.
        /// </summary>
        public static void UpdateStats(this xBDD.Model.TestRun testRun)
        {
            List<Outcome> outcomes = new List<Outcome>() {
                Outcome.NotRun,
                Outcome.Passed,
                Outcome.Skipped,
                Outcome.Failed
            };
            testRun.Scenarios.ToList().ForEach(scenario => {
                scenario.Feature.Outcome = Outcome.NotRun;
                scenario.Feature.Area.Outcome = Outcome.NotRun;
                scenario.Feature.Area.TestRun.Outcome = Outcome.NotRun;
                scenario.Feature.ScenarioStats.ClearStats();
                scenario.Feature.Area.ScenarioStats.ClearStats();
                scenario.Feature.Area.FeatureStats.ClearStats();
                scenario.Feature.Area.TestRun.ScenarioStats.ClearStats();
                scenario.Feature.Area.TestRun.FeatureStats.ClearStats();
                scenario.Feature.Area.TestRun.AreaStats.ClearStats();
            });
            outcomes.ForEach(outcome => {
                testRun.Scenarios
                    .Where(scenario => scenario.Outcome == outcome)
                    .ToList().ForEach(scenario => {
                        scenario.Feature.Outcome = outcome;
                        scenario.Feature.ScenarioStats.UpdateOutcomeStats(outcome);
                        scenario.Feature.Area.Outcome = outcome;
                        scenario.Feature.Area.ScenarioStats.UpdateOutcomeStats(outcome);
                        testRun.Outcome = outcome;
                       	testRun.ScenarioStats.UpdateOutcomeStats(outcome);
                    });
                testRun.Scenarios.Select(x => x.Feature).ToList()
                    .Where(feature => feature.Outcome == outcome)
                    .ToList().ForEach(feature => {
                        feature.Area.FeatureStats.UpdateOutcomeStats(outcome);
                        testRun.FeatureStats.UpdateOutcomeStats(outcome);
                    });
                testRun.Scenarios.Select(x => x.Feature.Area).ToList()
                    .Where(area => area.Outcome == outcome)
                    .ToList().ForEach(area => {
                        testRun.AreaStats.UpdateOutcomeStats(outcome);
                    });
                
            });
        }

        /// <summary>
        /// Updates the features sort property.  Features are sorted based on the 
        /// list of feature names you provide.  Scenarios are sorted based on thier 
        /// sort order that you can provide when creating the scenario xB.AddScenario(this, 1 [sortOrder])
        /// </summary>
        /// <param name="testRun">The test run to sort the features and scenarios.</param> 
        /// <param name="sortedFeatureFullNames">The sorted list of full feature names to use for sorting features. 
        /// Each feature name should be the full name with the namespace included.</param>
        public static void SortTestRunResults(this xBDD.Model.TestRun testRun, List<string> sortedFeatureFullNames)
        {
            var featureIndex = 0;
            sortedFeatureFullNames.ForEach(featureFullName => {
                
                var feature = testRun.Areas.SelectMany(x => x.Features).Where(f => f.FullClassName == featureFullName).FirstOrDefault();

                if(feature != null)
                {
                    featureIndex++;
                
                    feature.Sort = featureIndex;
                }

            });

            testRun.Areas.SelectMany(x => x.Features).Where(x => x.Sort == 0).ToList().ForEach(feature => {
                feature.Sort = 1000000;
            });

            testRun.Sorted = true;
        }
    }
}
