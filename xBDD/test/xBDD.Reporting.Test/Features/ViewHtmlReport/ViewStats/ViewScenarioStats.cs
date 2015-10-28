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
	//  [Description("I would like to view the features in the html report")]
	public class ViewScenarioStats
	{
		private readonly OutputWriter outputWriter;

		public ViewScenarioStats(ITestOutputHelper output)
		{
			outputWriter = new OutputWriter(output);
		}
		
		[ScenarioFact]
		[Trait("category", "now")]
		public async void FailedSkippedAndPassingStepsStats()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfAFullTestRunWithAllOutcomes())
 				.When(WebUser.ViewsReport(browser))
                .ThenAsync("the total number of steps should show as a badge to the right of the scenario name with a value of 3", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.ScenarioStepStats.Total(19));
					browser.ElementHasText(Pages.HtmlReportPage.ScenarioStepStats.Total(19), "3");
               	})
                .And("the badge should show 'Steps' when the user hovers over it", (s) => {
					browser.ElementHasTitle(Pages.HtmlReportPage.ScenarioStepStats.Total(19), "Steps");
               	})
                .Run();
		}
	}
}