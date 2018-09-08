using xBDD.Browser;

namespace xBDD.Features.Pages.HtmlReportPage
{
    public class Scenario
    {
        public PageElement Name(int scenarioNumber, int featureNumber)
        {
            return new PageElement($"the scenario {scenarioNumber} name",$"#feature-{featureNumber}-scenarios.collapse.show #scenario-{scenarioNumber} h4 span.name");
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
        public PageElement Duration(int scenarioNumber)
        {
            return new PageElement("the scenario " + scenarioNumber + " duration", "#scenario-" + scenarioNumber + " h4 span.scenario.duration");   
        }
        public PageElement Steps(int scenarioNumber)
        {
            return new PageElement("the scenario " + scenarioNumber + " steps", "#scenario-" + scenarioNumber + "-steps");   
        }
    }
}