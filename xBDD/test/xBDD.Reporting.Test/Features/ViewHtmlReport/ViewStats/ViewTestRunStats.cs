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
	public class ViewTestRunStats
	{
		private readonly OutputWriter outputWriter;

		public ViewTestRunStats(ITestOutputHelper output)
		{
			outputWriter = new OutputWriter(output);
		}
		
		[ScenarioFact]
		[Trait("category", "now")]
		public async void FailedSkippedAndPassingAreaStats()
		{
            Wrapper<HtmlReportPageStats> htmlReportStats = new Wrapper<HtmlReportPageStats>();
            await xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfAFullTestRunWithAllOutcomes())
                .When(WebUser.ViewsReportStats(htmlReportStats))
                .ThenAsync("there should be a green, yellow, and red bar for the passing, skipped, and failing areas under the test run name", async (s) => {
					await Page.WaitTillVisible("test run area outcome bar", htmlReportStats.Object.TestRunAreaOutcomeBar);
					s.Output = htmlReportStats.Object.Html;
					s.OutputFormat = TextFormat.htmlpreview;
                })
                .And("the passing, green bar should have a width of 33%", (s) => {
					Assert.True(htmlReportStats.Object.TestRunAreaOutcomeSuccessBar.GetAttribute("style").Contains("width: 33.3333333333333%"));
               	})
                .And("the skipped, yellow bar should have a width of 33%", (s) => {
					Assert.True(htmlReportStats.Object.TestRunAreaOutcomeSkippedBar.GetAttribute("style").Contains("width: 33.3333333333333%"));
               	})
                .And("the failed, red bar should have a width of 33%", (s) => {
					Assert.True(htmlReportStats.Object.TestRunAreaOutcomeFailedBar.GetAttribute("style").Contains("width: 33.3333333333333%"));
               	})
                .And("the total number of areas should show to the left of the outcome bar with a value of 3", (s) => {
					Assert.Equal("3", htmlReportStats.Object.TestRunAreaOutcomeTotal.Text);
               	})
                .And("the number of passed areas should show to the left of the outcome bar with a value of 1", (s) => {
					Assert.Equal("1", htmlReportStats.Object.TestRunAreaOutcomePassed.Text);
               	})
                .And("the number of skipped areas should show to the left of the outcome bar with a value of 1", (s) => {
					Assert.Equal("1", htmlReportStats.Object.TestRunAreaOutcomeSkipped.Text);
               	})
                .And("the number of failed areas should show to the left of the outcome bar with a value of 1", (s) => {
					Assert.Equal("1", htmlReportStats.Object.TestRunAreaOutcomeFailed.Text);
               	})
                .RunAsync();
		}
		[ScenarioFact]
		[Trait("category", "now")]
		public async void FailedSkippedAndPassingFeatureStats()
		{
            Wrapper<HtmlReportPageStats> htmlReportStats = new Wrapper<HtmlReportPageStats>();
            await xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfAFullTestRunWithAllOutcomes())
                .When(WebUser.ViewsReportStats(htmlReportStats))
                .ThenAsync("there should be a green, yellow, and red bar for the passing, skipped, and failing features under the test run name", async (s) => {
					await Page.WaitTillVisible("test run features outcome bar", htmlReportStats.Object.TestRunFeatureOutcomeBar);
					s.Output = htmlReportStats.Object.Html;
					s.OutputFormat = TextFormat.htmlpreview;
                })
                .And("the passing, green bar should have a width of 56%", (s) => {
					Assert.True(htmlReportStats.Object.TestRunFeatureOutcomeSuccessBar.GetAttribute("style").Contains("width: 55.5555555555556%"));
               	})
                .And("the skipped, yellow bar should have a width of 33%", (s) => {
					Assert.True(htmlReportStats.Object.TestRunFeatureOutcomeSkippedBar.GetAttribute("style").Contains("width: 33.3333333333333%"));
               	})
                .And("the failed, red bar should have a width of 11%", (s) => {
					Assert.True(htmlReportStats.Object.TestRunFeatureOutcomeFailedBar.GetAttribute("style").Contains("width: 11.1111111111111%"));
               	})
                .And("the total number of areas should show to the left of the outcome bar with a value of 9", (s) => {
					Assert.Equal("9", htmlReportStats.Object.TestRunFeatureOutcomeTotal.Text);
               	})
                .And("the number of passed features should show to the left of the outcome bar with a value of 5", (s) => {
					Assert.Equal("5", htmlReportStats.Object.TestRunFeatureOutcomePassed.Text);
               	})
                .And("the number of skipped features should show to the left of the outcome bar with a value of 3", (s) => {
					Assert.Equal("3", htmlReportStats.Object.TestRunFeatureOutcomeSkipped.Text);
               	})
                .And("the number of failed features should show to the left of the outcome bar with a value of 1", (s) => {
					Assert.Equal("1", htmlReportStats.Object.TestRunFeatureOutcomeFailed.Text);
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
                .ThenAsync("there should be a green, yellow, and red bar for the passing, skipped, and failing scenarios under the test run name", async (s) => {
					await Page.WaitTillVisible("test run scenarios outcome bar", htmlReportStats.Object.TestRunScenarioOutcomeBar);
					s.Output = htmlReportStats.Object.Html;
					s.OutputFormat = TextFormat.htmlpreview;
                })
                .And("the passing, green bar should have a width of 70%", (s) => {
					Assert.True(htmlReportStats.Object.TestRunScenarioOutcomeSuccessBar.GetAttribute("style").Contains("width: 70.3703703703704%"));
               	})
                .And("the skipped, yellow bar should have a width of 26%", (s) => {
					Assert.True(htmlReportStats.Object.TestRunScenarioOutcomeSkippedBar.GetAttribute("style").Contains("width: 25.9259259259259%"));
               	})
                .And("the failed, red bar should have a width of 4%", (s) => {
					Assert.True(htmlReportStats.Object.TestRunScenarioOutcomeFailedBar.GetAttribute("style").Contains("width: 3.7037037037037%"));
               	})
                .And("the total number of scenarios should show to the left of the outcome bar with a value of 27", (s) => {
					Assert.Equal("27", htmlReportStats.Object.TestRunScenarioOutcomeTotal.Text);
               	})
                .And("the number of passed scenarios should show to the left of the outcome bar with a value of 19", (s) => {
					Assert.Equal("19", htmlReportStats.Object.TestRunScenarioOutcomePassed.Text);
               	})
                .And("the number of skipped scenarios should show to the left of the outcome bar with a value of 7", (s) => {
					Assert.Equal("7", htmlReportStats.Object.TestRunScenarioOutcomeSkipped.Text);
               	})
                .And("the number of failed scenarios should show to the left of the outcome bar with a value of 1", (s) => {
					Assert.Equal("1", htmlReportStats.Object.TestRunScenarioOutcomeFailed.Text);
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
                .ThenAsync("there should be a green, yellow, and red bar for the passing, skipped, and failing steps under the test run name", async (s) => {
					await Page.WaitTillVisible("test run steps outcome bar", htmlReportStats.Object.TestRunStepOutcomeBar);
					s.Output = htmlReportStats.Object.Html;
					s.OutputFormat = TextFormat.htmlpreview;
                })
                .And("the passing, green bar should have a width of 72%", (s) => {
					Assert.True(htmlReportStats.Object.TestRunStepOutcomeSuccessBar.GetAttribute("style").Contains("width: 71.6049382716049%"));
               	})
                .And("the skipped, yellow bar should have a width of 27%", (s) => {
					Assert.True(htmlReportStats.Object.TestRunStepOutcomeSkippedBar.GetAttribute("style").Contains("width: 27.1604938271605%"));
               	})
                .And("the failed, red bar should have a width of 1%", (s) => {
					Assert.True(htmlReportStats.Object.TestRunStepOutcomeFailedBar.GetAttribute("style").Contains("width: 1.23456790123457%"));
               	})
                .And("the total number of steps should show to the left of the outcome bar with a value of 81", (s) => {
					Assert.Equal("81", htmlReportStats.Object.TestRunStepOutcomeTotal.Text);
               	})
                .And("the number of passed steps should show to the left of the outcome bar with a value of 58", (s) => {
					Assert.Equal("58", htmlReportStats.Object.TestRunStepOutcomePassed.Text);
               	})
                .And("the number of skipped steps should show to the left of the outcome bar with a value of 22", (s) => {
					Assert.Equal("22", htmlReportStats.Object.TestRunStepOutcomeSkipped.Text);
               	})
                .And("the number of failed steps should show to the left of the outcome bar with a value of 1", (s) => {
					Assert.Equal("1", htmlReportStats.Object.TestRunStepOutcomeFailed.Text);
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