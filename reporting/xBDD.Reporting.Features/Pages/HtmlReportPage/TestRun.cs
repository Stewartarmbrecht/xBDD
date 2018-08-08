using xBDD.Browser;

namespace xBDD.Reporting.Features.Pages.HtmlReportPage
{
    public class TestRun
    {
        public PageElement Name = new PageElement("test run name",".testrun-name span.name");
        public PageElement BadgeGreen = new PageElement("test run name - green",".testrun-name span.badge-success");
        public PageElement BadgeYellow = new PageElement("test run name - yellow",".testrun-name span.badge-warning");
        public PageElement BadgeRed = new PageElement("test run name - red",".testrun-name span.badge-danger");
        public PageElement BadgeGrey = new PageElement("test run name - grey",".testrun-name span.badge-secondary");
        public PageElement Areas = new PageElement("test run areas list",".areas");
    }
}