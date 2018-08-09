using xBDD.Browser;

namespace xBDD.Features.Pages.HtmlReportPage
{
    public partial class TestRunScenarioStats
    {
        
        public PageElement Section = new PageElement("test run scenario stats","#testrun-scenario-stats");
        public PageElement BarChart = new PageElement("test run scenario stats bar chart","#testrun-scenario-stats td.outcome-bar-chart");
        public PageElement SuccessBar = new PageElement("test run scenario stats success bar","#testrun-scenario-stats td.passed-bar");
        public PageElement SkippedBar = new PageElement("test run scenario stats skipped bar","#testrun-scenario-stats td.skipped-bar");
        public PageElement FailedBar = new PageElement("test run scenario stats failed bar","#testrun-scenario-stats td.failed-bar");
        public PageElement Passed = new PageElement("test run scenario stats passed count","#testrun-scenario-stats td.passed");
        public PageElement Skipped = new PageElement("test run scenario stats skipped count","#testrun-scenario-stats td.skipped");
        public PageElement Failed = new PageElement("test run scenario stats failed count","#testrun-scenario-stats td.failed");

    }
}