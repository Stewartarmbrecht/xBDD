using xBDD.Browser;

namespace xBDD.Reporting.Features.Pages.HtmlReportPage
{
    public partial class ScenarioStepStats
    {
        public PageElement Total(int scenarioNumber)
        {
            return new PageElement("scenario steps total","#scenario-"+scenarioNumber+" span.badge.total");
        }
    }
}