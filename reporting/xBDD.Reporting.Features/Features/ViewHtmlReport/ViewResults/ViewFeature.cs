//using Xunit;
//using Xunit.Abstractions;
using xBDD.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xBDD.Reporting.Test.Steps;
using System.Threading.Tasks;

namespace xBDD.Reporting.Test.Features.ViewHtmlReport.ViewResults
{
    [TestClass]
	public class ViewFeature
	{
		private readonly TestContextWriter outputWriter;

		public ViewFeature()
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
                .ThenAsync("the report will show the feature badge in green to indicate all scenarios passed", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.Feature.BadgeGreen(1));
					browser.ElementHasText(Pages.HtmlReportPage.Feature.Name(1), "My Feature 1");
                })
				.AndAsync("the scenarios under the feature will be collapsed because it passed", async (s) => {
					await browser.WaitTillNotVisible(Pages.HtmlReportPage.Feature.Scenarios(1));
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
                .ThenAsync("the report will show the feature badge in yellow to indicate scenarios were skipped", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.Feature.BadgeYellow(1));
                })
				.AndAsync("the scenarios under the feature will be collapsed because it was not failing", async (s) => {
					await browser.WaitTillNotVisible(Pages.HtmlReportPage.Feature.Scenarios(1));
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
                .ThenAsync("the report will show the feature badge in red to indicate a scenario failed", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.Feature.BadgeRed(1));
                })
				.AndAsync("the scenarios under the feature will be expanded because it has a failing scenario", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.Feature.Scenarios(1));
				})
                .Run();
		}
	}
}