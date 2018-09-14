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
    public class HtmlTestRunGroupReportWriter
    {
        TestRunGroupReportConfiguration config;
		HtmlWriter hW;

		List<ReportReasonConfiguration> sortedReasonConfigurations;
        internal HtmlTestRunGroupReportWriter(TestRunGroupReportConfiguration config, List<ReportReasonConfiguration> sortedReasonConfigurations) {
            this.config = config;
			this.sortedReasonConfigurations = sortedReasonConfigurations;
			this.hW = new HtmlWriter(sortedReasonConfigurations, config);
        }

        /// <summary>
        /// Writes the results of a test run to an HTML represenation.
        /// </summary>
        /// <param name="testRunGroup">The test run to write to HTML.</param>
        /// <returns>The HTML string representation of the test run results.</returns>
        public string WriteToHtmlSummaryReport(
			TestRunGroup testRunGroup) 
		{
            //testRunGroup.CalculatProperties(sortedReasonConfigurations.Select(x => x.Reason).ToList());
            StringBuilder sb = new StringBuilder();
            
			hW.WriteHeader(sb,false, null);
			hW.WriteLineItem(sb, testRunGroup.GetHtmlReportLineItem(true), false, true, true, true);
            hW.WriteFooter(sb);
            return sb.ToString();
        }
    }
}
