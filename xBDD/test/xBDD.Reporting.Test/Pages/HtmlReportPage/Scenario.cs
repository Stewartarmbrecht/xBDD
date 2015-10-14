using xBDD.Browser;

namespace xBDD.Reporting.Test.Pages.HtmlReportPage
{
    public class Scenario
    {
        public static PageElement Name(int scenarioNumber)
        {
            return new PageElement("scenario name","#scenario-" + scenarioNumber + " div.panel-heading span.name");
        }
        public static PageElement Green(int scenarioNumber)
        {
            return new PageElement("scenario " + scenarioNumber + " with green name", "#scenario-" + scenarioNumber + " div.panel.panel-success");   
        }
        public static PageElement Yellow(int scenarioNumber)
        {
            return new PageElement("scenario " + scenarioNumber + " with yellow name", "#scenario-" + scenarioNumber + " div.panel.panel-warning");   
        }
        public static PageElement Red(int scenarioNumber)
        {
            return new PageElement("scenario " + scenarioNumber + " with red name", "#scenario-" + scenarioNumber + " div.panel.panel-danger");   
        }
        public static PageElement Steps(int scenarioNumber)
        {
            return new PageElement("scenario " + scenarioNumber + " steps", "#scenario-" + scenarioNumber + "-steps");   
        }
    }
}