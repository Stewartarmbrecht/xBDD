using xBDD.Browser;

namespace xBDD.Reporting.Features.Pages.HtmlReportPage
{
    public class Scenario
    {
        public PageElement Name(int scenarioNumber)
        {
            return new PageElement("the scenario name","#scenario-" + scenarioNumber + " h4 span.name");
        }
        public PageElement BadgeGreen(int scenarioNumber)
        {
            return new PageElement("the scenario " + scenarioNumber + " with green badge", "#scenario-" + scenarioNumber + " h4 span.badge-success");   
        }
        public PageElement BadgeYellow(int scenarioNumber)
        {
            return new PageElement("the scenario " + scenarioNumber + " with yellow badge", "#scenario-" + scenarioNumber + " h4 span.badge-warning");   
        }
        public PageElement BadgeRed(int scenarioNumber)
        {
            return new PageElement("the scenario " + scenarioNumber + " with red badge", "#scenario-" + scenarioNumber + " h4 span.badge-danger");   
        }
        public PageElement Steps(int scenarioNumber)
        {
            return new PageElement("the scenario " + scenarioNumber + " steps", "#scenario-" + scenarioNumber + "-steps");   
        }
    }
}