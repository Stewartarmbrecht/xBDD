using System.Collections.Generic;
using xBDD.Reporting.Html;
using xBDD.Reporting.Text;
using xBDD.Reporting.Code;
using xBDD.Reporting.Outline;

namespace xBDD.Reporting
{
    internal class ReportingFactory
    {
        internal TextWriter GetTextWriter()
        {
            return new TextWriter();
        }

        internal OpmlWriter GetOpmlWriter()
        {
            return new OpmlWriter();
        }

        internal CodeWriter GetCodeWriter()
        {
            return new CodeWriter();
        }

        internal HtmlTestRunReportWriter GetHtmlTestRunReportWriter(TestRunReportConfiguration config, List<ReportReasonConfiguration> sortedReasonConfigurations)
        {
            return new HtmlTestRunReportWriter(config, sortedReasonConfigurations);
        }
        internal HtmlTestRunGroupReportWriter GetHtmlTestSummaryReportWriter(TestRunGroupReportConfiguration config, List<ReportReasonConfiguration> sortedReasonConfigurations)
        {
            return new HtmlTestRunGroupReportWriter(config, sortedReasonConfigurations);
        }
    }
}
