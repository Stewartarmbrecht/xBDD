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
	public class ViewFeatureStats
	{
		private readonly OutputWriter outputWriter;

		public ViewFeatureStats(ITestOutputHelper output)
		{
			outputWriter = new OutputWriter(output);
		}
		
		[ScenarioFact]
		public async void FailedSkippedAndPassingScenarioStats()
		{
            Wrapper<HtmlReportPageStats> htmlReportStats = new Wrapper<HtmlReportPageStats>();
            await xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfAFullTestRunWithAllOutcomes())
                .When(WebUser.ViewsReportStats(htmlReportStats))
                .ThenAsync("there should be a section under the feature name that displays scenario statistics about the feature", async (s) => {
					await Page.WaitTillVisible("feature scenario stats", htmlReportStats.Object.FeatureScenarioOutcomeStats(7));
                })
                .And("the section should show the total number of scenarios with a value of 3", (s) => {
					Assert.Equal("3", htmlReportStats.Object.FeatureScenarioOutcomeTotal(7).Text);
               	})
                .And("the section should show the number of passed scenarios with a value of 1", (s) => {
					Assert.Equal("1", htmlReportStats.Object.FeatureScenarioOutcomePassed(7).Text);
               	})
                .And("the section should show the number of skipped scenarios with a value of 1", (s) => {
					Assert.Equal("1", htmlReportStats.Object.FeatureScenarioOutcomeSkipped(7).Text);
               	})
                .And("the section should show the number of failed scenarios with a value of 1", (s) => {
					Assert.Equal("1", htmlReportStats.Object.FeatureScenarioOutcomeFailed(7).Text);
               	})
                .AndAsync("the section should a green, yellow, and red bar chart of the percentages of passed, skipped, and failed scenarios", async (s) => {
					await Page.WaitTillVisible("feature scenario outcome bar chart", htmlReportStats.Object.FeatureScenarioOutcomeBarChart(7));
               	})
                .And("the passed, green bar should have a width of 33%", (s) => {
					Assert.True(htmlReportStats.Object.FeatureScenarioOutcomeSuccessBar(7).GetAttribute("style").Contains("width: 33."));
               	})
                .And("the skipped, yellow bar should have a width of 33%", (s) => {
					Assert.True(htmlReportStats.Object.FeatureScenarioOutcomeSkippedBar(7).GetAttribute("style").Contains("width: 33."));
               	})
                .And("the failed, red bar should have a width of 33%", (s) => {
					Assert.True(htmlReportStats.Object.FeatureScenarioOutcomeFailedBar(7).GetAttribute("style").Contains("width: 33."));
               	})
                .AndAsync("the section should a dark blue, blue, and light blue overlapping bar chart of the percentages of the total scenarios relative to the parent area, and test run", async (s) => {
					await Page.WaitTillVisible("feature scenario total percentage bar chart", htmlReportStats.Object.FeatureScenarioTotalPercentageBarChart(7));
               	})
                .And("the dark blue, percentage of test run bar should have a width of 11% (3/27)", (s) => {
					Assert.True(htmlReportStats.Object.FeatureStepTotalPercentageTestRunBar(7).GetAttribute("style").Contains("width: 11."));
               	})
                .And("the blue, percentage of area bar should have a width of 33% (3/9) (22% because of overlap with test run bar)", (s) => {
					Assert.True(htmlReportStats.Object.FeatureStepTotalPercentageAreaBar(7).GetAttribute("style").Contains("width: 22."));
               	})
                .RunAsync();
		}
		[ScenarioFact]
		public async void FailedSkippedAndPassingStepsStats()
		{
            Wrapper<HtmlReportPageStats> htmlReportStats = new Wrapper<HtmlReportPageStats>();
            await xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfAFullTestRunWithAllOutcomes())
                .When(WebUser.ViewsReportStats(htmlReportStats))
                .ThenAsync("there should be a section under the feature name that displays step statistics about the feature", async (s) => {
					await Page.WaitTillVisible("feature step stats", htmlReportStats.Object.FeatureStepOutcomeStats(7));
                })
                .And("the section should show the total number of steps with a value of 9", (s) => {
					Assert.Equal("9", htmlReportStats.Object.FeatureStepOutcomeTotal(7).Text);
               	})
                .And("the section should show the number of passed steps with a value of 4", (s) => {
					Assert.Equal("4", htmlReportStats.Object.FeatureStepOutcomePassed(7).Text);
               	})
                .And("the section should show the number of skipped steps with a value of 4", (s) => {
					Assert.Equal("4", htmlReportStats.Object.FeatureStepOutcomeSkipped(7).Text);
               	})
                .And("the section should show the number of failed steps with a value of 1", (s) => {
					Assert.Equal("1", htmlReportStats.Object.FeatureStepOutcomeFailed(7).Text);
               	})
                .AndAsync("the section should a green, yellow, and red bar chart of the percentages of passed, skipped, and failed steps", async (s) => {
					await Page.WaitTillVisible("feature step outcome bar chart", htmlReportStats.Object.FeatureStepOutcomeBarChart(7));
               	})
                .And("the passed, green bar should have a width of 44%", (s) => {
					Assert.True(htmlReportStats.Object.FeatureStepOutcomeSuccessBar(7).GetAttribute("style").Contains("width: 44."));
               	})
                .And("the skipped, yellow bar should have a width of 44%", (s) => {
					Assert.True(htmlReportStats.Object.FeatureStepOutcomeSkippedBar(7).GetAttribute("style").Contains("width: 44."));
               	})
                .And("the failed, red bar should have a width of 11%", (s) => {
					Assert.True(htmlReportStats.Object.FeatureStepOutcomeFailedBar(7).GetAttribute("style").Contains("width: 11."));
               	})
                .AndAsync("the section should a dark blue, blue, and light blue overlapping bar chart of the percentages of the total steps relative to the parent area, and test run", async (s) => {
					await Page.WaitTillVisible("feature step total percentage bar chart", htmlReportStats.Object.FeatureStepTotalPercentageBarChart(7));
               	})
                .And("the dark blue, percentage of test run bar should have a width of 11% (9/81)", (s) => {
					Assert.True(htmlReportStats.Object.FeatureStepTotalPercentageTestRunBar(7).GetAttribute("style").Contains("width: 11."));
               	})
                .And("the blue, percentage of area bar should have a width of 22% (9/27) (11% because of overlap with test run bar)", (s) => {
					Assert.True(htmlReportStats.Object.FeatureStepTotalPercentageAreaBar(7).GetAttribute("style").Contains("width: 22."));
               	})
                .RunAsync();
		}
	}
}