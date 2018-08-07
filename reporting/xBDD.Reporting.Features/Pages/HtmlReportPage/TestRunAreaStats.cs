using xBDD.Browser;

namespace xBDD.Reporting.Test.Pages.HtmlReportPage
{
    public partial class TestRunAreaStats
    {
        public static PageElement Section = new PageElement("test run area stats","#testrun-area-stats");
        public static PageElement BarChart = new PageElement("test run area stats bar chart","#testrun-area-stats td.outcome-bar-chart");
        public static PageElement SuccessBar = new PageElement("test run area stats success bar","#testrun-area-stats td.passed-bar");
        public static PageElement SkippedBar = new PageElement("test run area stats skipped bar","#testrun-area-stats td.skipped-bar");
        public static PageElement FailedBar = new PageElement("test run area stats failed bar","#testrun-area-stats td.failed-bar");
        public static PageElement Total = new PageElement("test run area stats total count",".testrun-name span.badge.total");
        public static PageElement Passed = new PageElement("test run area stats passed count","#testrun-area-stats td.passed");
        public static PageElement Skipped = new PageElement("test run area stats skipped count","#testrun-area-stats td.skipped");
        public static PageElement Failed = new PageElement("test run area stats failed count","#testrun-area-stats td.failed");
        public static PageElement EmptyBar = new PageElement("test run area stats empty bar","#testrun-area-stats td.empty-bar");

    }
}