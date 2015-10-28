using xBDD.Browser;
using xBDD.Model;

namespace xBDD.Reporting.Test.Steps
{
    public static class WebUser
    {
        internal static Step ViewsReport(WebBrowser browser)
        {
            var step = xB.CreateAsyncStep(
                "the user views the html report",
                async (s) => {
                    browser.Load(Pages.HtmlReportPage.Location.PageLocation);
                    await browser.WaitTillVisible(Pages.HtmlReportPage.TestRun.Name);
                    s.Output = browser.GetPageSource();
                    s.OutputFormat = TextFormat.htmlpreview;
                });
            return step;
        }
    }
}