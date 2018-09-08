using xBDD.Browser;

namespace xBDD.Features.Pages.HtmlReportPage
{
    public partial class TestRunFeatureStats
    {
        
        public PageElement Section = new PageElement("test run feature stats","#testrun-feature-stats");
        public PageElement BarChart = new PageElement("test run feature stats bar chart","#testrun-feature-stats td.outcome-bar-chart");
        public PageElement SuccessBar = new PageElement("test run feature stats success bar","#testrun-feature-stats td.passed-bar");
        public PageElement SkippedBar = new PageElement("test run feature stats skipped bar","#testrun-feature-stats td.skipped-bar");
        public PageElement FailedBar = new PageElement("test run feature stats failed bar","#testrun-feature-stats td.failed-bar");
        public PageElement Passed = new PageElement("test run feature stats passed count","#testrun-feature-stats td.passed");
        public PageElement Skipped = new PageElement("test run feature stats skipped count","#testrun-feature-stats td.skipped");
        public PageElement Failed = new PageElement("test run feature stats failed count","#testrun-feature-stats td.failed");

    }
}