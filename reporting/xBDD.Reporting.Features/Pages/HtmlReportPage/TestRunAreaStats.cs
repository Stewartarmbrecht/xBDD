using xBDD.Browser;

namespace xBDD.Reporting.Features.Pages.HtmlReportPage
{
    public partial class TestRunAreaStats
    {
        public PageElement Section = new PageElement("test run area stats","#testrun-area-stats");
        public PageElement BarChart = new PageElement("test run area stats bar chart","#testrun-area-stats td.outcome-bar-chart");
        public PageElement SuccessBar = new PageElement("test run area stats success bar","#testrun-area-stats td.passed-bar");
        public PageElement SkippedBar = new PageElement("test run area stats skipped bar","#testrun-area-stats td.skipped-bar");
        public PageElement FailedBar = new PageElement("test run area stats failed bar","#testrun-area-stats td.failed-bar");
        public PageElement Total = new PageElement("test run area stats total count",".testrun-name span.badge.total");
        public PageElement Passed = new PageElement("test run area stats passed count","#testrun-area-stats td.passed");
        public PageElement Skipped = new PageElement("test run area stats skipped count","#testrun-area-stats td.skipped");
        public PageElement Failed = new PageElement("test run area stats failed count","#testrun-area-stats td.failed");
        public PageElement EmptyBar = new PageElement("test run area stats empty bar","#testrun-area-stats td.empty-bar");

    }
}