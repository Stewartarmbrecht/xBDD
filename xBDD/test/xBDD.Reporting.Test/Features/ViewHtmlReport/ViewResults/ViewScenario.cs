using Xunit;
using Xunit.Abstractions;
using xBDD.Browser;
using xBDD.xUnit;
using xBDD.Reporting.Test.Steps;

namespace xBDD.Reporting.Test.Features.ViewHtmlReport.ViewResults
{
    [Collection("xBDDReportingTest")]
	public class ViewScenario
	{
		private readonly OutputWriter outputWriter;

		public ViewScenario(ITestOutputHelper output)
		{
			outputWriter = new OutputWriter(output);
		}
		
		[ScenarioFact]
		[Trait("category", "now")]
		public async void Passing()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfASinglePassingScenario())
                .When(WebUser.ViewsReport(browser))
				.AndAsync("the user clicks the first area", async (s) => {
					await browser.ClickWhenVisible(Pages.HtmlReportPage.Area.Name(1));
				})
				.AndAsync("the user clicks the first feature", async (s) => {
					await browser.ClickWhenVisible(Pages.HtmlReportPage.Feature.Name(1));
				})
                .ThenAsync("the report will show the scenario name in green to indicate all steps passed", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.Scenario.Green(1));
					await browser.WaitTillVisible(Pages.HtmlReportPage.Scenario.Name(1));
					browser.ElementHasText(Pages.HtmlReportPage.Scenario.Name(1), "My Scenario 1");
                })
				.AndAsync("the steps under the scenario will be collapsed because it passed", async (s) => {
					await browser.WaitTillNotVisible(Pages.HtmlReportPage.Scenario.Steps(1));
				})
                .RunAsync();
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
				.AndAsync("the user clicks the first feature", async (s) => {
					await browser.ClickWhenVisible(Pages.HtmlReportPage.Feature.Name(1));
				})
                .ThenAsync("the report will show the scenario name in yellow to indicate the scenario was skipped", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.Scenario.Yellow(1));
                })
				.AndAsync("the steps under the scenario will be collapsed because it was not failing", async (s) => {
					await browser.WaitTillNotVisible(Pages.HtmlReportPage.Scenario.Steps(1));
				})
                .RunAsync();
		}
		[ScenarioFact]
		public async void Failing()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfASingleFailedScenario())
                .When(WebUser.ViewsReport(browser))
                .ThenAsync("the report will show the scenario name in red to indicate a scenario failed", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.Scenario.Red(1));
                })
				.AndAsync("the steps under the scenario will be expanded because it has a failing step", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.Scenario.Steps(1));
				})
                .RunAsync();
		}
	}
}