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
	public class ViewAreaStats
	{
		private readonly OutputWriter outputWriter;

		public ViewAreaStats(ITestOutputHelper output)
		{
			outputWriter = new OutputWriter(output);
		}
		
		[ScenarioFact]
		public async void FailedSkippedAndPassingFeatureStats()
		{
            Wrapper<HtmlReportPageStats> htmlReportStats = new Wrapper<HtmlReportPageStats>();
            await xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfAFullTestRunWithAllOutcomes())
                .When(WebUser.ViewsReportStats(htmlReportStats))
                .ThenAsync("there should be a section under the area name that displays feature statistics about the area", async (s) => {
					await Page.WaitTillVisible("area feature stats", htmlReportStats.Object.AreaFeatureOutcomeStats(3));
                })
                .And("the total number of features should show as a badge to the right of the area name with a value of 3", (s) => {
					Assert.Equal("3", htmlReportStats.Object.AreaFeatureOutcomeTotal(3).Text);
               	})
                .And("the badge should show 'Features' when the user hovers over it", (s) => {
					Assert.Equal("Features", htmlReportStats.Object.AreaFeatureOutcomeTotal(3).GetAttribute("title"));
               	})
                .And("the section should show the number of passed features with a value of 1", (s) => {
					Assert.Equal("1", htmlReportStats.Object.AreaFeatureOutcomePassed(3).Text);
               	})
                .And("the section should show the number of skipped features with a value of 1", (s) => {
					Assert.Equal("1", htmlReportStats.Object.AreaFeatureOutcomeSkipped(3).Text);
               	})
                .And("the section should show the number of failed features with a value of 1", (s) => {
					Assert.Equal("1", htmlReportStats.Object.AreaFeatureOutcomeFailed(3).Text);
               	})
                .AndAsync("the section should a green, yellow, and red bar chart of the percentages of passed, skipped, and failed features", async (s) => {
					await Page.WaitTillVisible("area feature outcome bar chart", htmlReportStats.Object.AreaFeatureOutcomeBarChart(3));
               	})
                .And("the passed, green bar should have a width of 33%", (s) => {
					Assert.True(htmlReportStats.Object.AreaFeatureOutcomeSuccessBar(3).GetAttribute("style").Contains("width: 33."));
               	})
                .And("the skipped, yellow bar should have a width of 33%", (s) => {
					Assert.True(htmlReportStats.Object.AreaFeatureOutcomeSkippedBar(3).GetAttribute("style").Contains("width: 33."));
               	})
                .And("the failed, red bar should have a width of 33%", (s) => {
					Assert.True(htmlReportStats.Object.AreaFeatureOutcomeFailedBar(3).GetAttribute("style").Contains("width: 33."));
               	})
                .RunAsync();
		}
		[ScenarioFact]
		public async void FailedSkippedAndPassingScenarioStats()
		{
            Wrapper<HtmlReportPageStats> htmlReportStats = new Wrapper<HtmlReportPageStats>();
            await xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfAFullTestRunWithAllOutcomes())
                .When(WebUser.ViewsReportStats(htmlReportStats))
                .ThenAsync("there should be a section under the area name that displays scenario statistics about the area", async (s) => {
					await Page.WaitTillVisible("area scenario stats", htmlReportStats.Object.AreaScenarioOutcomeStats(3));
                })
                .And("the section should show the number of passed scenarios with a value of 5", (s) => {
					Assert.Equal("5", htmlReportStats.Object.AreaScenarioOutcomePassed(3).Text);
               	})
                .And("the section should show the number of skipped scenarios with a value of 3", (s) => {
					Assert.Equal("3", htmlReportStats.Object.AreaScenarioOutcomeSkipped(3).Text);
               	})
                .And("the section should show the number of failed scenarios with a value of 1", (s) => {
					Assert.Equal("1", htmlReportStats.Object.AreaScenarioOutcomeFailed(3).Text);
               	})
                .AndAsync("the section should a green, yellow, and red bar chart of the percentages of passed, skipped, and failed scenarios", async (s) => {
					await Page.WaitTillVisible("area scenario outcome bar chart", htmlReportStats.Object.AreaScenarioOutcomeBarChart(3));
               	})
                .And("the passed, green bar should have a width of 55%", (s) => {
					Assert.True(htmlReportStats.Object.AreaScenarioOutcomeSuccessBar(3).GetAttribute("style").Contains("width: 55."));
               	})
                .And("the skipped, yellow bar should have a width of 33%", (s) => {
					Assert.True(htmlReportStats.Object.AreaScenarioOutcomeSkippedBar(3).GetAttribute("style").Contains("width: 33."));
               	})
                .And("the failed, red bar should have a width of 11%", (s) => {
					Assert.True(htmlReportStats.Object.AreaScenarioOutcomeFailedBar(3).GetAttribute("style").Contains("width: 11."));
               	})
                .RunAsync();
		}
	}
}