//using Xunit;
//using Xunit.Abstractions;
using xBDD.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xBDD.Reporting.Test.Steps;
using System.Threading.Tasks;

namespace xBDD.Reporting.Test.Features.ViewHtmlReport.ViewResults
{
    [TestClass]
	public class ViewScenario
	{
		private readonly TestContextWriter outputWriter;

		public ViewScenario()
		{
			outputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		public async Task Passing()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(AnHtmlReport.OfASinglePassingScenario())
                .When(WebUser.ViewsReport(browser))
				.AndAsync("the user clicks the first area", async (s) => {
					await browser.ClickWhenVisible(Pages.HtmlReportPage.Area.Name(1));
				})
				.AndAsync("the user clicks the first feature", async (s) => {
					await browser.ClickWhenVisible(Pages.HtmlReportPage.Feature.Name(1));
				})
                .ThenAsync("the report will show the scenario badge in green to indicate all steps passed", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.Scenario.BadgeGreen(1));
					await browser.WaitTillVisible(Pages.HtmlReportPage.Scenario.Name(1));
					browser.ElementHasText(Pages.HtmlReportPage.Scenario.Name(1), "My Scenario 1");
                })
				.AndAsync("the steps under the scenario will be collapsed because it passed", async (s) => {
					await browser.WaitTillNotVisible(Pages.HtmlReportPage.Scenario.Steps(1));
				})
                .Run();
		}
		[TestMethod]
		public async Task Skipped()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(AnHtmlReport.OfASingleSkippedScenario())
                .When(WebUser.ViewsReport(browser))
				.AndAsync("the user clicks the first area", async (s) => {
					await browser.ClickWhenVisible(Pages.HtmlReportPage.Area.Name(1));
				})
				.AndAsync("the user clicks the first feature", async (s) => {
					await browser.ClickWhenVisible(Pages.HtmlReportPage.Feature.Name(1));
				})
                .ThenAsync("the report will show the scenario badge in yellow to indicate the scenario was skipped", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.Scenario.BadgeYellow(1));
                })
				.AndAsync("the steps under the scenario will be collapsed because it was not failing", async (s) => {
					await browser.WaitTillNotVisible(Pages.HtmlReportPage.Scenario.Steps(1));
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
                .ThenAsync("the report will show the scenario badge in red to indicate a scenario failed", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.Scenario.BadgeRed(1));
                })
				.AndAsync("the steps under the scenario will be expanded because it has a failing step", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.Scenario.Steps(1));
				})
                .Run();
		}
	}
}