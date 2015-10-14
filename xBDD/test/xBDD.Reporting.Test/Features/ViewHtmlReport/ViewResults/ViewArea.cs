using Xunit;
using Xunit.Abstractions;
using xBDD.Browser;
using xBDD.xUnit;
using xBDD.Reporting.Test.Pages;
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
		[Trait("category", "now")]
		public async void Single()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfASinglePassingScenario())
                .When(WebUser.ViewsReport(browser))
                .ThenAsync("the report will show the area name in green to indicate all features passed", async (s) => {
					await browser.WaitTillVisible(HtmlReportPageArea.GreenAreaName(1));
                })
				.AndAsync("the features under the area will be collapsed because it passed", async (s) => {
					await browser.WaitTillNotVisible(HtmlReportPageArea.AreaFeatures(1));
				})
                .RunAsync();
		}
		[ScenarioFact]
		public void Mulitple()
		{
			 xBDD.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
		[ScenarioFact]
		public void Passing()
		{
			 xBDD.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
		[ScenarioFact]
		public void Skipped()
		{
			 xBDD.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
		[ScenarioFact]
		public void Failing()
		{
			 xBDD.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
	}
}