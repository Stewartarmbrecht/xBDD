using Xunit;
using Xunit.Abstractions;
using xBDD.Browser;
using xBDD.xUnit;
using xBDD.Reporting.Test.Steps;

namespace xBDD.Reporting.Test.Features.ViewHtmlReport.ViewResults
{
    [Collection("xBDDReportingTest")]
	public class ViewTestRun
	{
		private readonly OutputWriter outputWriter;

		public ViewTestRun(ITestOutputHelper output)
		{
			outputWriter = new OutputWriter(output);
		}
		
		[ScenarioFact]
		public async void EmptyTestRun()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfAnEmptyTestRun())
                .When(WebUser.ViewsReport(browser))
                .ThenAsync("the report will show the test run name at the top", async (s) => {
                    await browser.WaitTillVisible(Pages.HtmlReportPage.TestRun.Name);
                    browser.ElementHasText(Pages.HtmlReportPage.TestRun.Name, "My Test Run");
                })
                .And("the report will show the test run name as the title for the page", (s) => {
                    browser.HasTitle("My Test Run");
                })
                .AndAsync("the report will show the test run name in gray to indicate no scenarios were run", async (s) => {
                    await browser.WaitTillVisible(Pages.HtmlReportPage.TestRun.NameGrey);
                })
                .RunAsync();
		}
		
		[ScenarioFact]
		public async void PassingTestRun()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfASinglePassingScenario())
                .When(WebUser.ViewsReport(browser))
                .ThenAsync("the report will show the test run name in green to indicate the test run passed", async (s) => {
                    await browser.WaitTillVisible(Pages.HtmlReportPage.TestRun.NameGreen);
                })
                .RunAsync();
		}
		
		[ScenarioFact]
		public async void PassingWithSomeSkipped()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfASingleSkippedScenario())
                .When(WebUser.ViewsReport(browser))
                .ThenAsync("the report will show the test run name in yellow to indicate the test run had skipped scenarios", async (s) => {
                    await browser.WaitTillVisible(Pages.HtmlReportPage.TestRun.NameYellow);
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
                .ThenAsync("the report will show the test run name in red to indicate the test run has failing scenarios", async (s) => {
                    await browser.WaitTillVisible(Pages.HtmlReportPage.TestRun.NameRed);
                })
                .RunAsync();
		}
	}
}