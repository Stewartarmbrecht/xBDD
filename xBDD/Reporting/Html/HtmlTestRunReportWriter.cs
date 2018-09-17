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
    public class HtmlTestRunReportWriter
    {
		TestRunReportConfiguration config;
		HtmlWriter hW;
		List<ReportReasonConfiguration> reasonConfig;
        internal HtmlTestRunReportWriter(TestRunReportConfiguration config, List<ReportReasonConfiguration> sortedReasonConfigurations) {
			this.config = config;
			this.reasonConfig = sortedReasonConfigurations;
			this.hW = new HtmlWriter(sortedReasonConfigurations, config);
        }

        /// <summary>
        /// Writes the results of a test run to an HTML represenation.
        /// </summary>
        /// <param name="testRun">The test run to write to HTML.</param>
        /// <returns>The HTML string representation of the test run results.</returns>
        public string WriteToHtmlTestRunReport(TestRun testRun) 
		{
            //testRun.CalculatProperties(this.reasonConfig.Select(x => x.Reason).ToList());

            StringBuilder sb = new StringBuilder();
            
			hW.WriteHeader(sb, this.config.FailuresOnly, this.GetNavBarOptions());
			hW.WriteLineItem(sb, testRun.GetHtmlReportLineItem(true), config.FailuresOnly, true, true, true);
            hW.WriteFooter(sb);
            return sb.ToString();
        }
        private string GetNavBarOptions() {
            return $@"
	                            <a class=""nav-item nav-link active"" href=""javascript: $('ol.features').collapse('show');"" id=""expand-all-capabilities-button"">Expand All Capabilities <span class=""sr-only"">(current)</span></a>".RemoveIndentation(4, true);

        }
    }
}
