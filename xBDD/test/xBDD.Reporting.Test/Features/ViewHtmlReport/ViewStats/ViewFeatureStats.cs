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
                .ThenAsync("there should be a green, yellow, and red bar for the passing, skipped, and failing scenarios under the feature name", async (s) => {
					await Page.WaitTillVisible("feature scenarios outcome bar", htmlReportStats.Object.FeatureScenarioOutcomeStats(3));
					s.Output = htmlReportStats.Object.Html;
					s.OutputFormat = TextFormat.htmlpreview;
                })
                .And("the passing, green bar should have a width of 33%", (s) => {
					Assert.True(htmlReportStats.Object.FeatureScenarioOutcomeSuccessBar(3).GetAttribute("style").Contains("width: 33.3333333333333%"));
               	})
                .And("the skipped, yellow bar should have a width of 33%", (s) => {
					Assert.True(htmlReportStats.Object.FeatureScenarioOutcomeSkippedBar(3).GetAttribute("style").Contains("width: 33.3333333333333%"));
               	})
                .And("the failed, red bar should have a width of 33%", (s) => {
					Assert.True(htmlReportStats.Object.FeatureScenarioOutcomeFailedBar(3).GetAttribute("style").Contains("width: 33.3333333333333%"));
               	})
                .And("the total number of scenarios should show to the left of the outcome bar with a value of 3", (s) => {
					Assert.Equal("3", htmlReportStats.Object.FeatureScenarioOutcomeTotal(3).Text);
               	})
                .And("the number of passed scenarios should show to the left of the outcome bar with a value of 1", (s) => {
					Assert.Equal("1", htmlReportStats.Object.FeatureScenarioOutcomePassed(3).Text);
               	})
                .And("the number of skipped scenarios should show to the left of the outcome bar with a value of 1", (s) => {
					Assert.Equal("1", htmlReportStats.Object.FeatureScenarioOutcomeSkipped(3).Text);
               	})
                .And("the number of failed scenarios should show to the left of the outcome bar with a value of 1", (s) => {
					Assert.Equal("1", htmlReportStats.Object.FeatureScenarioOutcomeFailed(3).Text);
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
                .ThenAsync("there should be a green, yellow, and red bar for the passing, skipped, and failing steps under the feature name", async (s) => {
					await Page.WaitTillVisible("feature steps outcome bar", htmlReportStats.Object.FeatureStepOutcomeStats(3));
					s.Output = htmlReportStats.Object.Html;
					s.OutputFormat = TextFormat.htmlpreview;
                })
                .And("the passing, green bar should have a width of 44%", (s) => {
					Assert.True(htmlReportStats.Object.FeatureStepOutcomeSuccessBar(3).GetAttribute("style").Contains("width: 44.4444444444444%"));
               	})
                .And("the skipped, yellow bar should have a width of 44%", (s) => {
					Assert.True(htmlReportStats.Object.FeatureStepOutcomeSkippedBar(3).GetAttribute("style").Contains("width: 44.4444444444444%"));
               	})
                .And("the failed, red bar should have a width of 11%", (s) => {
					Assert.True(htmlReportStats.Object.FeatureStepOutcomeFailedBar(3).GetAttribute("style").Contains("width: 11.1111111111111%"));
               	})
                .And("the total number of steps should show to the left of the outcome bar with a value of 9", (s) => {
					Assert.Equal("9", htmlReportStats.Object.FeatureStepOutcomeTotal(3).Text);
               	})
                .And("the number of passed steps should show to the left of the outcome bar with a value of 4", (s) => {
					Assert.Equal("4", htmlReportStats.Object.FeatureStepOutcomePassed(3).Text);
               	})
                .And("the number of skipped steps should show to the left of the outcome bar with a value of 4", (s) => {
					Assert.Equal("4", htmlReportStats.Object.FeatureStepOutcomeSkipped(3).Text);
               	})
                .And("the number of failed steps should show to the left of the outcome bar with a value of 1", (s) => {
					Assert.Equal("1", htmlReportStats.Object.FeatureStepOutcomeFailed(3).Text);
               	})
                .RunAsync();
		}
		[ScenarioFact]
		public void AllPassing()
		{
			 xBDD.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
		[ScenarioFact]
		public void AllSkipped()
		{
			 xBDD.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
		[ScenarioFact]
		public void AllFailed()
		{
			 xBDD.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
	}
}