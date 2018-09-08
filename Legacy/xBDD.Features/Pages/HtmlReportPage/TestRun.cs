using xBDD.Browser;

namespace xBDD.Features.Pages.HtmlReportPage
{
    public class TestRun
    {
        public PageElement Name = new PageElement("the test run name",".testrun-name span.name");
        public PageElement BadgeGreen = new PageElement("the test run badge - green",".testrun-name span.badge-success");
        public PageElement BadgeYellow = new PageElement("the test run badge - yellow",".testrun-name span.badge-warning");
        public PageElement BadgeRed = new PageElement("the test run badge - red",".testrun-name span.badge-danger");
        public PageElement BadgeGrey = new PageElement("the test run badge - grey",".testrun-name span.badge-secondary");
        public PageElement Areas = new PageElement("the test run areas list",".areas");
        public PageElement Duration = new PageElement("the test run duration", ".testrun-name span.testrun.duration");
    }
}