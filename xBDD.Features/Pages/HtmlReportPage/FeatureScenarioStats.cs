using xBDD.Browser;

namespace xBDD.Features.Pages.HtmlReportPage
{
    public class FeatureScenarioStats
    {
        public PageElement Section(int featureNumber)
        {
            return new PageElement("feature scenario stats","#feature-"+featureNumber+"-scenario-stats");
        }
        public PageElement BarChart(int featureNumber)
        {
            return new PageElement("feature scenario stats bar chart","#feature-"+featureNumber+"-scenario-stats td.outcome-bar-chart");
        }
        public PageElement SuccessBar(int featureNumber)
        {
            return new PageElement("feature scenario stats success bar","#feature-"+featureNumber+"-scenario-stats td.passed-bar");
        }
        public PageElement SkippedBar(int featureNumber)
        {
            return new PageElement("feature scenario stats skipped bar","#feature-"+featureNumber+"-scenario-stats td.skipped-bar");
        }
        public PageElement FailedBar(int featureNumber)
        {
            return new PageElement("feature scenario stats failed bar","#feature-"+featureNumber+"-scenario-stats td.failed-bar");
        }
        public PageElement Total(int featureNumber)
        {
            return new PageElement("feature scenario stats total","#feature-"+featureNumber+" span.badge.total");
        }
        public PageElement Passed(int featureNumber)
        {
            return new PageElement("feature scenario stats passed count","#feature-"+featureNumber+"-scenario-stats td.passed");
        }
        public PageElement Skipped(int featureNumber)
        {
            return new PageElement("feature scenario stats skipped count","#feature-"+featureNumber+"-scenario-stats td.skipped");
        }
        public PageElement Failed(int featureNumber)
        {
            return new PageElement("feature scenario stats failed count","#feature-"+featureNumber+"-scenario-stats td.failed");
        }
    }
}