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
	//  [Description("I would like to view the features in the html report")]
	public class ViewScenarioStats
	{
		private readonly OutputWriter outputWriter;

		public ViewScenarioStats(ITestOutputHelper output)
		{
			outputWriter = new OutputWriter(output);
		}
		
		[ScenarioFact]
		public async void FailedSkippedAndPassingStepsStats()
		{
            Wrapper<HtmlReportPageStats> htmlReportStats = new Wrapper<HtmlReportPageStats>();
            await xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfAFullTestRunWithAllOutcomes())
                .When(WebUser.ViewsReportStats(htmlReportStats))
                .ThenAsync("there should be badget displaying the total number of steps in the scenario to the right of the scenario name", async (s) => {
					await Page.WaitTillVisible("scenario step stats", htmlReportStats.Object.ScenarioStepOutcomeTotal(19));
					Assert.Equal("3", htmlReportStats.Object.ScenarioStepOutcomeTotal(19).Text);
                })
                .And("the badge should show 'Steps' when the user hovers over it", (s) => {
					Assert.Equal("Steps", htmlReportStats.Object.ScenarioStepOutcomeTotal(19).GetAttribute("title"));
               	})
                .RunAsync();
		}
	}
}