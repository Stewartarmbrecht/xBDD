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
	[Trait("category", "now")]
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
                .ThenAsync("there should be a section under the scenario name that displays step statistics about the scenario", async (s) => {
					await Page.WaitTillVisible("scenario step stats", htmlReportStats.Object.ScenarioStepOutcomeStats(19));
                })
                .And("the section should show the total number of steps with a value of 3", (s) => {
					Assert.Equal("3", htmlReportStats.Object.ScenarioStepOutcomeTotal(19).Text);
               	})
                .And("the section should show the number of passed steps with a value of 1", (s) => {
					Assert.Equal("1", htmlReportStats.Object.ScenarioStepOutcomePassed(19).Text);
               	})
                .And("the section should show the number of skipped steps with a value of 1", (s) => {
					Assert.Equal("1", htmlReportStats.Object.ScenarioStepOutcomeSkipped(19).Text);
               	})
                .And("the section should show the number of failed steps with a value of 1", (s) => {
					Assert.Equal("1", htmlReportStats.Object.ScenarioStepOutcomeFailed(19).Text);
               	})
                .AndAsync("the section should a green, yellow, and red bar chart of the percentages of passed, skipped, and failed steps", async (s) => {
					await Page.WaitTillVisible("scenario step outcome bar chart", htmlReportStats.Object.ScenarioStepOutcomeBarChart(19));
               	})
                .And("the passed, green bar should have a width of 33%", (s) => {
					Assert.True(htmlReportStats.Object.ScenarioStepOutcomeSuccessBar(19).GetAttribute("style").Contains("width: 33."));
               	})
                .And("the skipped, yellow bar should have a width of 33%", (s) => {
					Assert.True(htmlReportStats.Object.ScenarioStepOutcomeSkippedBar(19).GetAttribute("style").Contains("width: 33."));
               	})
                .And("the failed, red bar should have a width of 33%", (s) => {
					Assert.True(htmlReportStats.Object.ScenarioStepOutcomeFailedBar(19).GetAttribute("style").Contains("width: 33."));
               	})
                .AndAsync("the section should a dark blue, blue, and light blue overlapping bar chart of the percentages of the total steps relative to the parent feature, area, and test run", async (s) => {
					await Page.WaitTillVisible("scenario step total percentage bar chart", htmlReportStats.Object.ScenarioStepTotalPercentageBarChart(19));
               	})
                .And("the dark blue, percentage of test run bar should have a width of 4% (3/81)", (s) => {
					Assert.True(htmlReportStats.Object.ScenarioStepTotalPercentageTestRunBar(19).GetAttribute("style").Contains("width: 3.7"));
               	})
                .And("the blue, percentage of area bar should have a width of 11% (3/27) (7.4% because of overlap with test run bar)", (s) => {
					Assert.True(htmlReportStats.Object.ScenarioStepTotalPercentageAreaBar(19).GetAttribute("style").Contains("width: 7.4"));
               	})
                .And("the light blue, percentage of area bar should have a width of 33% (3/9) (22% because of overlap with area bar)", (s) => {
					Assert.True(htmlReportStats.Object.ScenarioStepTotalPercentageScenarioBar(19).GetAttribute("style").Contains("width: 22."));
               	})
                .RunAsync();
		}
	}
}