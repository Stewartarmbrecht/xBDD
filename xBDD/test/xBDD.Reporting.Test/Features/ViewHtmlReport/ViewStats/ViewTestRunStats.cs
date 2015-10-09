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
	public class ViewTestRunStats
	{
		private readonly OutputWriter outputWriter;

		public ViewTestRunStats(ITestOutputHelper output)
		{
			outputWriter = new OutputWriter(output);
		}
		
		[ScenarioFact]
		public async void FailedSkippedAndPassingAreaStats()
		{
            Wrapper<HtmlReportPageStats> htmlReportStats = new Wrapper<HtmlReportPageStats>();
            await xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfAFullTestRunWithAllOutcomes())
                .When(WebUser.ViewsReportStats(htmlReportStats))
                .ThenAsync("there should be a section under the name that displays area statistics about the test run", async (s) => {
					await Page.WaitTillVisible("test run area stats", htmlReportStats.Object.TestRunAreaOutcomeStats);
                })
                .And("the section should show the number of passed areas with a value of 1", (s) => {
					Assert.Equal("1", htmlReportStats.Object.TestRunAreaOutcomePassed.Text);
               	})
                .And("the section should show the number of skipped areas with a value of 1", (s) => {
					Assert.Equal("1", htmlReportStats.Object.TestRunAreaOutcomeSkipped.Text);
               	})
                .And("the section should show the number of failed areas with a value of 1", (s) => {
					Assert.Equal("1", htmlReportStats.Object.TestRunAreaOutcomeFailed.Text);
               	})
                .AndAsync("the section should a green, yellow, and red bar chart of the percentages of passed, skipped, and failed areas", async (s) => {
					await Page.WaitTillVisible("test run area outcome bar chart", htmlReportStats.Object.TestRunAreaOutcomeBarChart);
               	})
                .And("the passed, green bar should have a width of 33%", (s) => {
					Assert.True(htmlReportStats.Object.TestRunAreaOutcomeSuccessBar.GetAttribute("style").Contains("width: 33."));
               	})
                .And("the skipped, yellow bar should have a width of 33%", (s) => {
					Assert.True(htmlReportStats.Object.TestRunAreaOutcomeSkippedBar.GetAttribute("style").Contains("width: 33."));
               	})
                .And("the failed, red bar should have a width of 33%", (s) => {
					Assert.True(htmlReportStats.Object.TestRunAreaOutcomeFailedBar.GetAttribute("style").Contains("width: 33."));
               	})
                .RunAsync();
		}
		[ScenarioFact]
		public async void FailedSkippedAndPassingFeatureStats()
		{
            Wrapper<HtmlReportPageStats> htmlReportStats = new Wrapper<HtmlReportPageStats>();
            await xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfAFullTestRunWithAllOutcomes())
                .When(WebUser.ViewsReportStats(htmlReportStats))
                .ThenAsync("there should be a section under the name that displays feature statistics about the test run", async (s) => {
					await Page.WaitTillVisible("test run feature stats", htmlReportStats.Object.TestRunFeatureOutcomeStats);
                })
                .And("the section should show the number of passed features with a value of 5", (s) => {
					Assert.Equal("5", htmlReportStats.Object.TestRunFeatureOutcomePassed.Text);
               	})
                .And("the section should show the number of skipped features with a value of 3", (s) => {
					Assert.Equal("3", htmlReportStats.Object.TestRunFeatureOutcomeSkipped.Text);
               	})
                .And("the section should show the number of failed features with a value of 1", (s) => {
					Assert.Equal("1", htmlReportStats.Object.TestRunFeatureOutcomeFailed.Text);
               	})
                .AndAsync("the section should a green, yellow, and red bar chart of the percentages of passed, skipped, and failed features", async (s) => {
					await Page.WaitTillVisible("test run feature outcome bar chart", htmlReportStats.Object.TestRunFeatureOutcomeBarChart);
               	})
                .And("the passed, green bar should have a width of 55%", (s) => {
					Assert.True(htmlReportStats.Object.TestRunFeatureOutcomeSuccessBar.GetAttribute("style").Contains("width: 55."));
               	})
                .And("the skipped, yellow bar should have a width of 33%", (s) => {
					Assert.True(htmlReportStats.Object.TestRunFeatureOutcomeSkippedBar.GetAttribute("style").Contains("width: 33."));
               	})
                .And("the failed, red bar should have a width of 11%", (s) => {
					Assert.True(htmlReportStats.Object.TestRunFeatureOutcomeFailedBar.GetAttribute("style").Contains("width: 11."));
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
                .ThenAsync("there should be a section under the name that displays scenario statistics about the test run", async (s) => {
					await Page.WaitTillVisible("test run scenario stats", htmlReportStats.Object.TestRunScenarioOutcomeStats);
                })
                .And("the section should show the number of passed scenarios with a value of 19", (s) => {
					Assert.Equal("19", htmlReportStats.Object.TestRunScenarioOutcomePassed.Text);
               	})
                .And("the section should show the number of skipped scenarios with a value of 7", (s) => {
					Assert.Equal("7", htmlReportStats.Object.TestRunScenarioOutcomeSkipped.Text);
               	})
                .And("the section should show the number of failed scenarios with a value of 1", (s) => {
					Assert.Equal("1", htmlReportStats.Object.TestRunScenarioOutcomeFailed.Text);
               	})
                .AndAsync("the section should a green, yellow, and red bar chart of the percentages of passed, skipped, and failed scenarios", async (s) => {
					await Page.WaitTillVisible("test run scenario outcome bar chart", htmlReportStats.Object.TestRunScenarioOutcomeBarChart);
               	})
                .And("the passed, green bar should have a width of 70%", (s) => {
					Assert.True(htmlReportStats.Object.TestRunScenarioOutcomeSuccessBar.GetAttribute("style").Contains("width: 70."));
               	})
                .And("the skipped, yellow bar should have a width of 26%", (s) => {
					Assert.True(htmlReportStats.Object.TestRunScenarioOutcomeSkippedBar.GetAttribute("style").Contains("width: 25.9"));
               	})
                .And("the failed, red bar should have a width of 4%", (s) => {
					Assert.True(htmlReportStats.Object.TestRunScenarioOutcomeFailedBar.GetAttribute("style").Contains("width: 3.7"));
               	})
                .RunAsync();
		}
		[ScenarioFact]
		public async void AreaStatsNoAreas()
		{
            Wrapper<HtmlReportPageStats> htmlReportStats = new Wrapper<HtmlReportPageStats>();
            await xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfAnEmptyTestRun())
                .When(WebUser.ViewsReportStats(htmlReportStats))
                .ThenAsync("there should be a section under the name that displays area statistics about the test run", async (s) => {
					await Page.WaitTillVisible("test run area stats", htmlReportStats.Object.TestRunAreaOutcomeStats);
                })
                .And("the section should show the number of passed areas with a value of 0", (s) => {
					Assert.Equal("0", htmlReportStats.Object.TestRunAreaOutcomePassed.Text);
               	})
                .And("the section should show the number of skipped areas with a value of 0", (s) => {
					Assert.Equal("0", htmlReportStats.Object.TestRunAreaOutcomeSkipped.Text);
               	})
                .And("the section should show the number of failed areas with a value of 0", (s) => {
					Assert.Equal("0", htmlReportStats.Object.TestRunAreaOutcomeFailed.Text);
               	})
                .And("the section should a gray bar to indicate there are no areas that is 100%", (s) => {
					Assert.True(htmlReportStats.Object.TestRunAreaOutcomeEmptyBar.GetAttribute("style").Contains("width: 100%"));
               	})
                .RunAsync();
		}
	}
}