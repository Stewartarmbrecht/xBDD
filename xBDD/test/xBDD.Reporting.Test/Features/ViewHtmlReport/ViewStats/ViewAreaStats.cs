using xBDD.Reporting.Test.Pages;
using xBDD.Reporting.Test.Steps;
using xBDD.xUnit;
using xBDD.Browser;
using Xunit;
using Xunit.Abstractions;
using System;
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
		[Trait("category", "now")]
		public async void FailedSkippedAndPassingFeatureStats()
		{
            Wrapper<HtmlReportPageStats> htmlReportStats = new Wrapper<HtmlReportPageStats>();
            await xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfAFullTestRunWithAllOutcomes())
                .When(WebUser.ViewsReportStats(htmlReportStats))
                .ThenAsync("there should be a green, yellow, and red bar for the passing, skipped, and failing features under the area name", async (s) => {
					await Page.WaitTillVisible("area features outcome bar", htmlReportStats.Object.AreaFeatureOutcomeBar(3));
					s.Output = htmlReportStats.Object.Html;
					s.OutputFormat = TextFormat.htmlpreview;
                })
                .And("the passing, green bar should have a width of 33%", (s) => {
					Assert.True(htmlReportStats.Object.AreaFeatureOutcomeSuccessBar(3).GetAttribute("style").Contains("width: 33.3333333333333%"));
               	})
                .And("the skipped, yellow bar should have a width of 33%", (s) => {
					Assert.True(htmlReportStats.Object.AreaFeatureOutcomeSkippedBar(3).GetAttribute("style").Contains("width: 33.3333333333333%"));
               	})
                .And("the failed, red bar should have a width of 33%", (s) => {
					Assert.True(htmlReportStats.Object.AreaFeatureOutcomeFailedBar(3).GetAttribute("style").Contains("width: 33.3333333333333%"));
               	})
                .And("the total number of areas should show to the left of the outcome bar with a value of 3", (s) => {
					Assert.Equal("3", htmlReportStats.Object.AreaFeatureOutcomeTotal(3).Text);
               	})
                .And("the number of passed features should show to the left of the outcome bar with a value of 1", (s) => {
					Assert.Equal("1", htmlReportStats.Object.AreaFeatureOutcomePassed(3).Text);
               	})
                .And("the number of skipped features should show to the left of the outcome bar with a value of 1", (s) => {
					Assert.Equal("1", htmlReportStats.Object.AreaFeatureOutcomeSkipped(3).Text);
               	})
                .And("the number of failed features should show to the left of the outcome bar with a value of 1", (s) => {
					Assert.Equal("1", htmlReportStats.Object.AreaFeatureOutcomeFailed(3).Text);
               	})
                .RunAsync();
		}
		[ScenarioFact]
		[Trait("category", "now")]
		public async void FailedSkippedAndPassingScenarioStats()
		{
            Wrapper<HtmlReportPageStats> htmlReportStats = new Wrapper<HtmlReportPageStats>();
            await xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfAFullTestRunWithAllOutcomes())
                .When(WebUser.ViewsReportStats(htmlReportStats))
                .ThenAsync("there should be a green, yellow, and red bar for the passing, skipped, and failing scenarios under the area name", async (s) => {
					await Page.WaitTillVisible("area scenarios outcome bar", htmlReportStats.Object.AreaScenarioOutcomeBar(3));
					s.Output = htmlReportStats.Object.Html;
					s.OutputFormat = TextFormat.htmlpreview;
                })
                .And("the passing, green bar should have a width of 56%", (s) => {
					Assert.True(htmlReportStats.Object.AreaScenarioOutcomeSuccessBar(3).GetAttribute("style").Contains("width: 55.5555555555556%"));
               	})
                .And("the skipped, yellow bar should have a width of 33%", (s) => {
					Assert.True(htmlReportStats.Object.AreaScenarioOutcomeSkippedBar(3).GetAttribute("style").Contains("width: 33.3333333333333%"));
               	})
                .And("the failed, red bar should have a width of 11%", (s) => {
					Assert.True(htmlReportStats.Object.AreaScenarioOutcomeFailedBar(3).GetAttribute("style").Contains("width: 11.1111111111111%"));
               	})
                .And("the total number of scenarios should show to the left of the outcome bar with a value of 9", (s) => {
					Assert.Equal("9", htmlReportStats.Object.AreaScenarioOutcomeTotal(3).Text);
               	})
                .And("the number of passed scenarios should show to the left of the outcome bar with a value of 5", (s) => {
					Assert.Equal("5", htmlReportStats.Object.AreaScenarioOutcomePassed(3).Text);
               	})
                .And("the number of skipped scenarios should show to the left of the outcome bar with a value of 3", (s) => {
					Assert.Equal("3", htmlReportStats.Object.AreaScenarioOutcomeSkipped(3).Text);
               	})
                .And("the number of failed scenarios should show to the left of the outcome bar with a value of 1", (s) => {
					Assert.Equal("1", htmlReportStats.Object.AreaScenarioOutcomeFailed(3).Text);
               	})
                .RunAsync();
		}
		[ScenarioFact]
		[Trait("category", "now")]
		public async void FailedSkippedAndPassingStepsStats()
		{
            Wrapper<HtmlReportPageStats> htmlReportStats = new Wrapper<HtmlReportPageStats>();
            await xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfAFullTestRunWithAllOutcomes())
                .When(WebUser.ViewsReportStats(htmlReportStats))
                .ThenAsync("there should be a green, yellow, and red bar for the passing, skipped, and failing steps under the area name", async (s) => {
					await Page.WaitTillVisible("area steps outcome bar", htmlReportStats.Object.AreaStepOutcomeBar(3));
					s.Output = htmlReportStats.Object.Html;
					s.OutputFormat = TextFormat.htmlpreview;
                })
                .And("the passing, green bar should have a width of 59%", (s) => {
					Assert.True(htmlReportStats.Object.AreaStepOutcomeSuccessBar(3).GetAttribute("style").Contains("width: 59.2592592592593%"));
               	})
                .And("the skipped, yellow bar should have a width of 37%", (s) => {
					Assert.True(htmlReportStats.Object.AreaStepOutcomeSkippedBar(3).GetAttribute("style").Contains("width: 37.037037037037%"));
               	})
                .And("the failed, red bar should have a width of 4%", (s) => {
					Assert.True(htmlReportStats.Object.AreaStepOutcomeFailedBar(3).GetAttribute("style").Contains("width: 3.7037037037037%"));
               	})
                .And("the total number of steps should show to the left of the outcome bar with a value of 27", (s) => {
					Assert.Equal("27", htmlReportStats.Object.AreaStepOutcomeTotal(3).Text);
               	})
                .And("the number of passed steps should show to the left of the outcome bar with a value of 16", (s) => {
					Assert.Equal("16", htmlReportStats.Object.AreaStepOutcomePassed(3).Text);
               	})
                .And("the number of skipped steps should show to the left of the outcome bar with a value of 10", (s) => {
					Assert.Equal("10", htmlReportStats.Object.AreaStepOutcomeSkipped(3).Text);
               	})
                .And("the number of failed steps should show to the left of the outcome bar with a value of 1", (s) => {
					Assert.Equal("1", htmlReportStats.Object.AreaStepOutcomeFailed(3).Text);
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