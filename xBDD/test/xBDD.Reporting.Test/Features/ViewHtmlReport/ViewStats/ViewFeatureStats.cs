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
                .And("the total number of scenarios should show as a badge to the right of the feature name with a value of 3", (s) => {
					Assert.Equal("3", htmlReportStats.Object.FeatureScenarioOutcomeTotal(7).Text);
               	})
                .And("the badge should show 'Scenarios' when the user hovers over it", (s) => {
					Assert.Equal("Scenarios", htmlReportStats.Object.FeatureScenarioOutcomeTotal(7).GetAttribute("title"));
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
                .RunAsync();
		}
	}
}