using xBDD.Browser;

namespace xBDD.Reporting.Features.Pages.HtmlReportPage
{
    public partial class TestRunScenarioStats
    {
        
        public static PageElement Section = new PageElement("test run scenario stats","#testrun-scenario-stats");
        public static PageElement BarChart = new PageElement("test run scenario stats bar chart","#testrun-scenario-stats td.outcome-bar-chart");
        public static PageElement SuccessBar = new PageElement("test run scenario stats success bar","#testrun-scenario-stats td.passed-bar");
        public static PageElement SkippedBar = new PageElement("test run scenario stats skipped bar","#testrun-scenario-stats td.skipped-bar");
        public static PageElement FailedBar = new PageElement("test run scenario stats failed bar","#testrun-scenario-stats td.failed-bar");
        public static PageElement Passed = new PageElement("test run scenario stats passed count","#testrun-scenario-stats td.passed");
        public static PageElement Skipped = new PageElement("test run scenario stats skipped count","#testrun-scenario-stats td.skipped");
        public static PageElement Failed = new PageElement("test run scenario stats failed count","#testrun-scenario-stats td.failed");

    }
}