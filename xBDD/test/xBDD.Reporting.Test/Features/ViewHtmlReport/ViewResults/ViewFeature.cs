using Xunit;
using Xunit.Abstractions;
using xBDD.Browser;
using xBDD.xUnit;
using xBDD.Reporting.Test.Steps;

namespace xBDD.Reporting.Test.Features.ViewHtmlReport.ViewResults
{
    [Collection("xBDDReportingTest")]
	public class ViewFeature
	{
		private readonly OutputWriter outputWriter;

		public ViewFeature(ITestOutputHelper output)
		{
			outputWriter = new OutputWriter(output);
		}
		
		[ScenarioFact]
		public async void Passing()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfASinglePassingScenario())
                .When(WebUser.ViewsReport(browser))
				.AndAsync("the user clicks the first area", async (s) => {
					await browser.ClickWhenVisible(Pages.HtmlReportPage.Area.Name(1));
				})
                .ThenAsync("the report will show the feature name in green to indicate all scenarios passed", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.Feature.NameGreen(1));
					browser.ElementHasText(Pages.HtmlReportPage.Feature.Name(1), "My Feature 1");
                })
				.AndAsync("the scenarios under the feature will be collapsed because it passed", async (s) => {
					await browser.WaitTillNotVisible(Pages.HtmlReportPage.Feature.Scenarios(1));
				})
                .Run();
		}
		[ScenarioFact]
		public async void Skipped()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfASingleSkippedScenario())
                .When(WebUser.ViewsReport(browser))
				.AndAsync("the user clicks the first area", async (s) => {
					await browser.ClickWhenVisible(Pages.HtmlReportPage.Area.Name(1));
				})
                .ThenAsync("the report will show the feature name in yellow to indicate scenarios were skipped", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.Feature.NameYellow(1));
                })
				.AndAsync("the scenarios under the feature will be collapsed because it was not failing", async (s) => {
					await browser.WaitTillNotVisible(Pages.HtmlReportPage.Feature.Scenarios(1));
				})
                .Run();
		}
		[ScenarioFact]
		public async void Failing()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfASingleFailedScenario())
                .When(WebUser.ViewsReport(browser))
                .ThenAsync("the report will show the feature name in red to indicate a scenario failed", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.Feature.NameRed(1));
                })
				.AndAsync("the scenarios under the feature will be expanded because it has a failing scenario", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.Feature.Scenarios(1));
				})
                .Run();
		}
	}
}