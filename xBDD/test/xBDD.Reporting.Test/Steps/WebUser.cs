using OpenQA.Selenium;
using Xunit;
using xBDD.Model;
using xBDD.Reporting.Test.Pages;
using xBDD.Browser;
using System.Threading.Tasks;

namespace xBDD.Reporting.Test.Steps
{
    public static class WebUser
    {
        internal static Step ViewsReport(WebBrowser browser)
        {
            var step = xBDD.CreateStep(
                "the user views the html report",
                async (s) => {
                    browser.Load(HtmlReportPage.PageLocation);
                    await browser.WaitTillVisible(HtmlReportPage.TestRunName);
                    s.Output = browser.GetPageSource();
                    s.OutputFormat = TextFormat.htmlpreview;
                });
            return step;
        }
        internal static Step ViewsReportGeneral(Wrapper<HtmlReportPageGeneral> report)
        {
            var step = xBDD.CreateStep(
                "the user views the html report",
                (s) => {
                    report.Object = HtmlReportPageGeneral.Load();
                    s.Output = report.Object.Html;
                    s.OutputFormat = TextFormat.htmlpreview;
                });
            return step;
        }
        internal static Step ViewsReportStats(Wrapper<HtmlReportPageStats> report)
        {
            var step = xBDD.CreateStep(
                "the user views the html report",
                (s) => {
                    report.Object = HtmlReportPageStats.Load();
                    s.Output = report.Object.Html;
                    s.OutputFormat = TextFormat.htmlpreview;
                });
            return step;
        }
    }
}