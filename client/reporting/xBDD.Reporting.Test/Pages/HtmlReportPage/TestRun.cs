using xBDD.Browser;

namespace xBDD.Reporting.Test.Pages.HtmlReportPage
{
    public class TestRun
    {
        public static PageElement Name = new PageElement("test run name",".testrun-name span.name");
        public static PageElement NameGreen = new PageElement("test run name - green",".testrun-name.text-success");
        public static PageElement NameYellow = new PageElement("test run name - yellow",".testrun-name.text-warning");
        public static PageElement NameRed = new PageElement("test run name - red",".testrun-name.text-danger");
        public static PageElement NameGrey = new PageElement("test run name - grey",".testrun-name.text-muted");
    }
}