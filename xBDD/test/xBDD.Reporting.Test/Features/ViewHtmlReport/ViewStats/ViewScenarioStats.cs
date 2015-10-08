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
            Wrapper<HtmlReportPageStats> htmlReportStats = new Wrapper<HtmlReportPageStats>();
            await xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfAFullTestRunWithAllOutcomes())
                .When(WebUser.ViewsReportStats(htmlReportStats))
                .ThenAsync("there should be a green, yellow, and red bar for the passing, skipped, and failing steps under the scenario name", async (s) => {
					await Page.WaitTillVisible("scenario steps outcome bar", htmlReportStats.Object.ScenarioStepOutcomeBar(19));
					s.Output = htmlReportStats.Object.Html;
					s.OutputFormat = TextFormat.htmlpreview;
                })
                .And("the passing, green bar should have a width of 33%", (s) => {
					Assert.True(htmlReportStats.Object.ScenarioStepOutcomeSuccessBar(19).GetAttribute("style").Contains("width: 33.3333333333333%"));
               	})
                .And("the skipped, yellow bar should have a width of 33%", (s) => {
					Assert.True(htmlReportStats.Object.ScenarioStepOutcomeSkippedBar(19).GetAttribute("style").Contains("width: 33.3333333333333%"));
               	})
                .And("the failed, red bar should have a width of 33%", (s) => {
					Assert.True(htmlReportStats.Object.ScenarioStepOutcomeFailedBar(19).GetAttribute("style").Contains("width: 33.3333333333333%"));
               	})
                .And("the total number of steps should show to the left of the outcome bar with a value of 3", (s) => {
					Assert.Equal("3", htmlReportStats.Object.ScenarioStepOutcomeTotal(19).Text);
               	})
                .And("the number of passed steps should show to the left of the outcome bar with a value of 1", (s) => {
					Assert.Equal("1", htmlReportStats.Object.ScenarioStepOutcomePassed(19).Text);
               	})
                .And("the number of skipped steps should show to the left of the outcome bar with a value of 1", (s) => {
					Assert.Equal("1", htmlReportStats.Object.ScenarioStepOutcomeSkipped(19).Text);
               	})
                .And("the number of failed steps should show to the left of the outcome bar with a value of 1", (s) => {
					Assert.Equal("1", htmlReportStats.Object.ScenarioStepOutcomeFailed(19).Text);
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