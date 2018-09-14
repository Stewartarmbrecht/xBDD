namespace xBDD
{
	using System;
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
    public static class TestRunGroupExtensions
    {
        /// <summary>
        /// Writes an HTML summary report.
        /// </summary>
        /// <param name="testRunGroup">The test run whose results you want to write to text.</param>
        /// <param name="testRunNameClip">The starting part of the test run names you want to remove.</param>
        /// <returns>String that is a multiline text format of the test results.</returns>
        public static string WriteToHtmlSummaryReport(this xBDD.Model.TestRunGroup testRunGroup, 
			TestRunGroupReportConfiguration config,
			List<ReportReasonConfiguration> sortedReasonConfigurations)
        {
            ReportingFactory factory = new ReportingFactory();
            HtmlTestRunGroupReportWriter saver = factory.GetHtmlTestSummaryReportWriter(config, sortedReasonConfigurations);
            return saver.WriteToHtmlSummaryReport(testRunGroup);
        }

        /// <summary>
        /// Cascades the scenario skipped reasons up the hierarchy.
        /// Also calculates the count of children for each skipped reason.
        /// </summary>
        /// <param name="sortedReasons">The list of reasons sorted from least to highest precedent.
        /// <param name="testRunGroup">The test run group to update parent reasons and stats for.</param> 
        /// A parent that has both reasons will assume the reason with the highest precedent.</param>
        public static void CalculatProperties(this xBDD.Model.TestRunGroup testRunGroup, List<string> sortedReasons)
        {
			testRunGroup.CalculateStartAndEndTimes();
			testRunGroup.UpdateParentReasonsAndStats(sortedReasons);
			testRunGroup.UpdateStats();
		}

        /// <summary>
        /// Calculates the start and end time for the test run group.
        /// </summary>
        /// <param name="testRunGroup">The test run group to set the start and end times for.</param>
        private static void CalculateStartAndEndTimes(this xBDD.Model.TestRunGroup testRunGroup)
        {
            testRunGroup.TestRuns.ForEach(testRun => {
				testRun.CalculateStartAndEndTimes();
            });
            if(testRunGroup.TestRuns.Count > 0) {
                var earliest = testRunGroup.TestRuns
					.Where(x => !DateTime.Equals(x.StartTime,System.DateTime.MinValue))
					.OrderBy(testRun => testRun.StartTime)
					.FirstOrDefault();
				if(earliest != null)
					testRunGroup.StartTime = earliest.StartTime;
                var latest = testRunGroup.TestRuns
					.Where(x => !DateTime.Equals(x.StartTime,System.DateTime.MinValue))
					.OrderByDescending(testRun => testRun.EndTime)
					.FirstOrDefault();
				if(latest != null)
					testRunGroup.EndTime = latest.StartTime;
            }
        }

        /// <summary>
        /// Cascades the scenario skipped reasons up the hierarchy.
        /// Also calculates the count of children for each skipped reason.
        /// </summary>
        /// <param name="sortedReasons">The list of reasons sorted from least to highest precedent.
        /// <param name="testRunGroup">The test run group to update parent reasons and stats for.</param> 
        /// A parent that has both reasons will assume the reason with the highest precedent.</param>
        private static void UpdateParentReasonsAndStats(this xBDD.Model.TestRunGroup testRunGroup, List<string> sortedReasons)
        {
			testRunGroup.TestRunReasonStats.Clear();
			testRunGroup.AreaReasonStats.Clear();
			testRunGroup.FeatureReasonStats.Clear();
			testRunGroup.ScenarioReasonStats.Clear();

			testRunGroup.TestRuns.ForEach(testRun => {
				testRun.UpdateParentReasonsAndStats(sortedReasons);
			});

            if(!sortedReasons.Contains("Failed"))
                sortedReasons.Add("Failed");

            var additionalReasons = testRunGroup.TestRuns
                .Select(testRun => testRun.Reason)
                .Distinct()
                .Where(reason => !sortedReasons.Contains(reason) && reason != null)
                .OrderBy(reason => reason)
				.Distinct()
                .ToList();

            sortedReasons.InsertRange(0,additionalReasons);

            sortedReasons.ForEach(reason => {
                testRunGroup.TestRuns
                    .Where(testRun => testRun.Reason == reason)
                    .ToList().ForEach(testRun => {
                        if(testRunGroup.TestRunReasonStats.Keys.Contains(reason)) {
                            testRunGroup.TestRunReasonStats[reason] = testRunGroup.TestRunReasonStats[reason] + 1;
                        } else {
                            testRunGroup.TestRunReasonStats.Add(reason, 1);
                        }
						testRunGroup.AreaReasonStats.AddChildReasonStats(testRun.AreaReasonStats);
						testRunGroup.FeatureReasonStats.AddChildReasonStats(testRun.FeatureReasonStats);
						testRunGroup.ScenarioReasonStats.AddChildReasonStats(testRun.ScenarioReasonStats);
						testRunGroup.Reason = reason;
                    });
            });
        }

		private static void AddChildReasonStats(this Dictionary<string, int> reasonStats,  Dictionary<string, int> childReasonStats) {
			foreach(string childReason in childReasonStats.Keys) {
				if(reasonStats.Keys.Contains(childReason)) {
					reasonStats[childReason] = reasonStats[childReason] + childReasonStats[childReason];
				} else {
					reasonStats.Add(childReason, childReasonStats[childReason]);
				}
			}
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

        public static void AddStats(this OutcomeStats stats, OutcomeStats addStats) {
            stats.Total = stats.Total + addStats.Total;
            stats.Failed = stats.Failed + addStats.Failed;
            stats.Passed = stats.Passed + addStats.Passed;
            stats.Skipped = stats.Skipped + addStats.Skipped;
        }

        /// <summary>
        /// Updates the test run group outcome and stats based on the child test run outcomes and stats.
        /// </summary>
        private static void UpdateStats(this xBDD.Model.TestRunGroup testRunGroup)
        {
            List<Outcome> outcomes = new List<Outcome>() {
                Outcome.NotRun,
                Outcome.Passed,
                Outcome.Skipped,
                Outcome.Failed
            };

			testRunGroup.TestRuns.ForEach(testRun => {
				testRun.UpdateStats();
			});

            testRunGroup.Outcome = Outcome.NotRun;
			testRunGroup.StepStats.ClearStats();
			testRunGroup.ScenarioStats.ClearStats();
			testRunGroup.FeatureStats.ClearStats();
			testRunGroup.AreaStats.ClearStats();
			testRunGroup.TestRunStats.ClearStats();

            outcomes.ForEach(outcome => {
                testRunGroup.TestRuns
                    .Where(testRun => testRun.Outcome == outcome)
                    .ToList().ForEach(testRun => {
                        testRunGroup.Outcome = outcome;
                       	testRunGroup.TestRunStats.UpdateOutcomeStats(outcome);
						testRunGroup.AreaStats.AddStats(testRun.AreaStats);
						testRunGroup.FeatureStats.AddStats(testRun.FeatureStats);
						testRunGroup.ScenarioStats.AddStats(testRun.ScenarioStats);
						testRunGroup.StepStats.AddStats(testRun.StepStats);
                    });                
            });
        }
    }
}
