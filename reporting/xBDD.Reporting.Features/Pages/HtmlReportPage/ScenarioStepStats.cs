using xBDD.Browser;

namespace xBDD.Reporting.Test.Pages.HtmlReportPage
{
    public partial class ScenarioStepStats
    {
        public static PageElement Total(int scenarioNumber)
        {
            return new PageElement("scenario steps total","#scenario-"+scenarioNumber+" span.badge.total");
        }
    }
}