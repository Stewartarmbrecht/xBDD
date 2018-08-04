using xBDD.Browser;

namespace xBDD.Reporting.Test.Pages.HtmlReportPage
{
    public class Scenario
    {
        public static PageElement Name(int scenarioNumber)
        {
            return new PageElement("scenario name","#scenario-" + scenarioNumber + " h4 span.name");
        }
        public static PageElement BadgeGreen(int scenarioNumber)
        {
            return new PageElement("scenario " + scenarioNumber + " with green name", "#scenario-" + scenarioNumber + " h4 span.badge-success");   
        }
        public static PageElement BadgeYellow(int scenarioNumber)
        {
            return new PageElement("scenario " + scenarioNumber + " with yellow name", "#scenario-" + scenarioNumber + " h4 span.badge-warning");   
        }
        public static PageElement BadgeRed(int scenarioNumber)
        {
            return new PageElement("scenario " + scenarioNumber + " with red name", "#scenario-" + scenarioNumber + " h4 span.badge-danger");   
        }
        public static PageElement Steps(int scenarioNumber)
        {
            return new PageElement("scenario " + scenarioNumber + " steps", "#scenario-" + scenarioNumber + "-steps");   
        }
    }
}