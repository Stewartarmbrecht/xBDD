using xBDD.Browser;

namespace xBDD.Reporting.Test.Pages.HtmlReportPage
{
    public partial class TestRunFeatureStats
    {
        
        public static PageElement Section = new PageElement("test run feature stats","#testrun-feature-stats");
        public static PageElement BarChart = new PageElement("test run feature stats bar chart","#testrun-feature-stats td.outcome-bar-chart");
        public static PageElement SuccessBar = new PageElement("test run feature stats success bar","#testrun-feature-stats td.passed-bar");
        public static PageElement SkippedBar = new PageElement("test run feature stats skipped bar","#testrun-feature-stats td.skipped-bar");
        public static PageElement FailedBar = new PageElement("test run feature stats failed bar","#testrun-feature-stats td.failed-bar");
        public static PageElement Passed = new PageElement("test run feature stats passed count","#testrun-feature-stats td.passed");
        public static PageElement Skipped = new PageElement("test run feature stats skipped count","#testrun-feature-stats td.skipped");
        public static PageElement Failed = new PageElement("test run feature stats failed count","#testrun-feature-stats td.failed");

    }
}