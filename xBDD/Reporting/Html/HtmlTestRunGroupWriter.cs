using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using xBDD.Model;
using xBDD.Utility;

namespace xBDD.Reporting.Html
{
    /// <summary>
    /// Writes the results of a test run to an HTML represenation.
    /// </summary>
    public class HtmlTestSummaryReportWriter
    {
        int areaCounter = 0;
        int featureCounter = 0;
        int scenarioCounter = 0;
        int stepCounter = 0;
        string testRunNameSkip = "";
		HtmlWriter hW = new HtmlWriter();
        internal HtmlTestSummaryReportWriter(string testRunNameSkip) {
            this.testRunNameSkip = testRunNameSkip;
        }

        /// <summary>
        /// Writes the results of a test run to an HTML represenation.
        /// </summary>
        /// <param name="testRunGroup">The test run to write to HTML.</param>
        /// <returns>The HTML string representation of the test run results.</returns>
        public string WriteToHtmlSummaryReport(TestRunGroup testRunGroup) {
            StringBuilder sb = new StringBuilder();
            
			hW.WriteHeaderStart(testRunGroup.Name, sb);
            hW.WriteStyles(sb);
            hW.WriteHeaderEnd(sb);
			hW.WriteBodyStart(sb);
            hW.WriteNavBarStart(sb, false);
            hW.WriteNavBarEnd(sb);
			Dictionary<string, OutcomeStats> statistics = new Dictionary<string, OutcomeStats>();
			statistics.Add("Test Runs", testRunGroup.TestRunStats);
			statistics.Add("Areas", testRunGroup.AreaStats);
			statistics.Add("Features", testRunGroup.FeatureStats);
			statistics.Add("Scenarios", testRunGroup.ScenarioStats);
			hW.WriteBanner(
				sb, 
				testRunGroup.ScenarioStats.Total, 
				testRunGroup.Outcome, 
				testRunGroup.Reason, 
				testRunGroup.Name,
				"Test Runs", 
				testRunGroup.StartTime, 
				testRunGroup.EndTime, 
				statistics);
			WriteTestRuns(testRunGroup, sb);
			hW.WriteBodyEnd(sb);
            hW.WriteHtmlEnd(sb);
            return sb.ToString();
        }
        void WriteTestRuns(TestRunGroup testRunGroup, StringBuilder sb) {
			hW.WriteTagOpen("ol", sb, 1, "areas list-unstyled", false);
			int testRunCount = 0;
            foreach (var testRun in testRunGroup.TestRuns)
            {
				testRunCount++;
				Dictionary<string, OutcomeStats> statistics = new Dictionary<string, OutcomeStats>();
				statistics.Add("Areas",testRun.AreaStats);
				statistics.Add("Features",testRun.FeatureStats);
				statistics.Add("Scenarios",testRun.ScenarioStats);
				hW.WriteLineItemOpen(
					sb,
					"testrun",
					testRunCount,
					testRun.Name,
					testRun.FilePath,
					testRun.Outcome,
					testRun.Reason,
					testRun.StartTime,
					testRun.EndTime,
					testRun.ScenarioStats.Total,
					"Areas",
					testRun.AreaStats,
					statistics,
					false);
				hW.WriteLineItemClose(sb);
            }
			hW.WriteTagClose("ol", sb, 1);//areas
        }
    }
}
