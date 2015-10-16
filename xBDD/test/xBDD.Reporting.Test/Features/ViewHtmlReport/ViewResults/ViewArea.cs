using Xunit;
using Xunit.Abstractions;
using xBDD.Browser;
using xBDD.xUnit;
using xBDD.Reporting.Test.Steps;

namespace xBDD.Reporting.Test.Features.ViewHtmlReport.ViewResults
{
    [Collection("xBDDReportingTest")]
	//  [Description("In order to understand how functionality is organized")]
	//  [Description("As a report reviewer")]
	//  [Description("I would like to view the areas in the html report")]
	public class ViewArea
	{
		private readonly OutputWriter outputWriter;

		public ViewArea(ITestOutputHelper output)
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
                .ThenAsync("the report will show the area name in green to indicate all features passed", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.Area.NameGreen(1));
					browser.ElementHasText(Pages.HtmlReportPage.Area.Name(1), "My Area 1");
                })
				.AndAsync("the features under the area will be collapsed because it passed", async (s) => {
					await browser.WaitTillNotVisible(Pages.HtmlReportPage.Area.Features(1));
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
                .ThenAsync("the report will show the area name in yellow to indicate scenarios were skipped", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.Area.NameYellow(1));
                })
				.AndAsync("the features under the area will be collapsed because it was not failing", async (s) => {
					await browser.WaitTillNotVisible(Pages.HtmlReportPage.Area.Features(1));
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
                .ThenAsync("the report will show the area name in red to indicate a scenario failed", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.Area.NameRed(1));
                })
				.AndAsync("the features under the area will be expanded because it has a failing scenario", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.Area.Features(1));
				})
                .RunAsync();
		}
	}
}