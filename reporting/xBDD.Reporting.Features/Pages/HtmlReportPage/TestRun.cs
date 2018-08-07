using xBDD.Browser;

namespace xBDD.Reporting.Features.Pages.HtmlReportPage
{
    public class TestRun
    {
        public static PageElement Name = new PageElement("test run name",".testrun-name span.name");
        public static PageElement BadgeGreen = new PageElement("test run name - green",".testrun-name span.badge-success");
        public static PageElement BadgeYellow = new PageElement("test run name - yellow",".testrun-name span.badge-warning");
        public static PageElement BadgeRed = new PageElement("test run name - red",".testrun-name span.badge-danger");
        public static PageElement BadgeGrey = new PageElement("test run name - grey",".testrun-name span.badge-secondary");
    }
}