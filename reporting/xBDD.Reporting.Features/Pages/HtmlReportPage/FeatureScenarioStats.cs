using xBDD.Browser;

namespace xBDD.Reporting.Test.Pages.HtmlReportPage
{
    public partial class FeatureScenarioStats
    {
        public static PageElement Section(int featureNumber)
        {
            return new PageElement("feature scenario stats","#feature-"+featureNumber+"-scenario-stats");
        }
        public static PageElement BarChart(int featureNumber)
        {
            return new PageElement("feature scenario stats bar chart","#feature-"+featureNumber+"-scenario-stats td.outcome-bar-chart");
        }
        public static PageElement SuccessBar(int featureNumber)
        {
            return new PageElement("feature scenario stats success bar","#feature-"+featureNumber+"-scenario-stats td.passed-bar");
        }
        public static PageElement SkippedBar(int featureNumber)
        {
            return new PageElement("feature scenario stats skipped bar","#feature-"+featureNumber+"-scenario-stats td.skipped-bar");
        }
        public static PageElement FailedBar(int featureNumber)
        {
            return new PageElement("feature scenario stats failed bar","#feature-"+featureNumber+"-scenario-stats td.failed-bar");
        }
        public static PageElement Total(int featureNumber)
        {
            return new PageElement("feature scenario stats total","#feature-"+featureNumber+" span.badge.total");
        }
        public static PageElement Passed(int featureNumber)
        {
            return new PageElement("feature scenario stats passed count","#feature-"+featureNumber+"-scenario-stats td.passed");
        }
        public static PageElement Skipped(int featureNumber)
        {
            return new PageElement("feature scenario stats skipped count","#feature-"+featureNumber+"-scenario-stats td.skipped");
        }
        public static PageElement Failed(int featureNumber)
        {
            return new PageElement("feature scenario stats failed count","#feature-"+featureNumber+"-scenario-stats td.failed");
        }
    }
}