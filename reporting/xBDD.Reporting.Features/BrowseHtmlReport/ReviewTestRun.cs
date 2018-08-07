using xBDD.Test;
using xBDD.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xBDD.Reporting.Features.Steps;
using System.Threading.Tasks;

namespace xBDD.Reporting.Features.BrowseHtmlReport
{
    [TestClass]
	public class ReviewTestRun
	{
		private readonly TestContextWriter outputWriter;

		public ReviewTestRun()
		{
			outputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		public async Task EmptyTestRun()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(AnHtmlReport.OfAnEmptyTestRun())
                .When(WebUser.ViewsReport(browser))
                .ThenAsync("the report will show the test run name at the top", async (s) => {
                    await browser.WaitTillVisible(Pages.HtmlReportPage.TestRun.Name);
                    browser.ElementHasText(Pages.HtmlReportPage.TestRun.Name, "My Test Run");
                })
                .And("the report will show the test run name as the title for the page", (s) => {
                    browser.HasTitle("My Test Run");
                })
                .AndAsync("the report will show the test run name in gray to indicate no scenarios were run", async (s) => {
                    await browser.WaitTillVisible(Pages.HtmlReportPage.TestRun.BadgeGrey);
                })
                .Run();
		}
		
		[TestMethod]
		public async Task PassingTestRun()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(AnHtmlReport.OfASinglePassingScenario())
                .When(WebUser.ViewsReport(browser))
                .ThenAsync("the report will show the test run badge in green to indicate the test run passed", async (s) => {
                    await browser.WaitTillVisible(Pages.HtmlReportPage.TestRun.BadgeGreen);
                })
                .Run();
		}
		
		[TestMethod]
		public async Task PassingWithSomeSkipped()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(AnHtmlReport.OfASingleSkippedScenario())
                .When(WebUser.ViewsReport(browser))
                .ThenAsync("the report will show the test run badge in yellow to indicate the test run had skipped scenarios", async (s) => {
                    await browser.WaitTillVisible(Pages.HtmlReportPage.TestRun.BadgeYellow);
                })
                .Run();
		}
		
		[TestMethod]
		public async Task Failing()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(AnHtmlReport.OfASingleFailedScenario())
                .When(WebUser.ViewsReport(browser))
                .ThenAsync("the report will show the test run badge in red to indicate the test run has failing scenarios", async (s) => {
                    await browser.WaitTillVisible(Pages.HtmlReportPage.TestRun.BadgeRed);
                })
                .Run();
		}
	}
}