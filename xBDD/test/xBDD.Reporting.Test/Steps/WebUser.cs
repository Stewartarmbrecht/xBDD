using System;
using xBDD.Browser;
using xBDD.Model;

namespace xBDD.Reporting.Test.Steps
{
    public static class WebUser
    {
        internal static Step ViewsReport(WebBrowser browser)
        {
            System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + "ViewsReport Start");
            var step = xB.CreateAsyncStep(
                "the user views the html report",
                async (s) => {
                    browser.Load(Pages.HtmlReportPage.Location.PageLocation);
                    await browser.WaitTillVisible(Pages.HtmlReportPage.TestRun.Name);
                    s.Output = browser.GetPageSource();
                    s.OutputFormat = TextFormat.htmlpreview;
                });
            System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + "ViewsReport Start");
            return step;
        }
    }
}