using Xunit;
using Xunit.Abstractions;
using xBDD.Browser;
using xBDD.xUnit;
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
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfAFullTestRunWithAllOutcomes())
				.When(WebUser.ViewsReport(browser))
                .ThenAsync("there should be a section under the test run name that displays area statistics", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.TestRunAreaStats.Section);
                })
                .AndAsync("the total number of areas should show as a badge to the right of the test run name with a value of 3", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.TestRunAreaStats.Total);
					browser.ElementHasText(Pages.HtmlReportPage.TestRunAreaStats.Total, "3");
               	})
                .And("the badge should show 'Areas' when the user hovers over it", (s) => {
					browser.ElementHasTitle(Pages.HtmlReportPage.TestRunAreaStats.Total, "Areas");
               	})
                .And("the section should show the number of passed areas with a value of 1", (s) => {
					browser.ElementHasText(Pages.HtmlReportPage.TestRunAreaStats.Passed, "1");
               	})
                .And("the section should show the number of areas with skipped scenarios with a value of 1", (s) => {
					browser.ElementHasText(Pages.HtmlReportPage.TestRunAreaStats.Skipped, "1");
               	})
                .And("the section should show the number of areas with failed scenarios with a value of 1", (s) => {
					browser.ElementHasText(Pages.HtmlReportPage.TestRunAreaStats.Failed, "1");
               	})
                .AndAsync("the section should show a green, yellow, and red bar chart of the percentages of passed, skipped, and failed areas", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.TestRunAreaStats.BarChart);
               	})
                .And("the passed, green bar should have a width of 33%", (s) => {
					browser.ElementStyleMatches(Pages.HtmlReportPage.TestRunAreaStats.SuccessBar, ".*width: 33\\..*");
               	})
                .And("the skipped, yellow bar should have a width of 33%", (s) => {
					browser.ElementStyleMatches(Pages.HtmlReportPage.TestRunAreaStats.SkippedBar, ".*width: 33\\..*");
               	})
                .And("the failed, red bar should have a width of 33%", (s) => {
					browser.ElementStyleMatches(Pages.HtmlReportPage.TestRunAreaStats.FailedBar, ".*width: 33\\..*");
               	})
                .RunAsync();
		}
		[ScenarioFact]
		public async void FailedSkippedAndPassingFeatureStats()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfAFullTestRunWithAllOutcomes())
				.When(WebUser.ViewsReport(browser))
                .ThenAsync("there should be a section under the test run name that displays feature statistics about the test run", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.TestRunFeatureStats.Section);
                })
                .And("the section should show the number of passed features with a value of 5", (s) => {
					browser.ElementHasText(Pages.HtmlReportPage.TestRunFeatureStats.Passed, "5");
               	})
                .And("the section should show the number of skipped features with a value of 3", (s) => {
					browser.ElementHasText(Pages.HtmlReportPage.TestRunFeatureStats.Skipped, "3");
               	})
                .And("the section should show the number of failed features with a value of 1", (s) => {
					browser.ElementHasText(Pages.HtmlReportPage.TestRunFeatureStats.Failed, "1");
               	})
                .AndAsync("the section should show a green, yellow, and red bar chart of the percentages of passed, skipped, and failed features", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.TestRunFeatureStats.BarChart);
               	})
                .And("the passed, green bar should have a width of 33%", (s) => {
					browser.ElementStyleMatches(Pages.HtmlReportPage.TestRunFeatureStats.SuccessBar, ".*width: 55\\..*");
               	})
                .And("the skipped, yellow bar should have a width of 33%", (s) => {
					browser.ElementStyleMatches(Pages.HtmlReportPage.TestRunFeatureStats.SkippedBar, ".*width: 33\\..*");
               	})
                .And("the failed, red bar should have a width of 33%", (s) => {
					browser.ElementStyleMatches(Pages.HtmlReportPage.TestRunFeatureStats.FailedBar, ".*width: 11\\..*");
               	})
                .RunAsync();
		}
		[ScenarioFact]
		public async void FailedSkippedAndPassingScenarioStats()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfAFullTestRunWithAllOutcomes())
 				.When(WebUser.ViewsReport(browser))
                .ThenAsync("there should be a section under the test run name that displays scenario statistics about the test run", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.TestRunScenarioStats.Section);
                })
                .And("the section should show the number of passed scenarios with a value of 19", (s) => {
					browser.ElementHasText(Pages.HtmlReportPage.TestRunScenarioStats.Passed, "19");
               	})
                .And("the section should show the number of skipped scenarios with a value of 7", (s) => {
					browser.ElementHasText(Pages.HtmlReportPage.TestRunScenarioStats.Skipped, "7");
               	})
                .And("the section should show the number of failed scenarios with a value of 1", (s) => {
					browser.ElementHasText(Pages.HtmlReportPage.TestRunScenarioStats.Failed, "1");
               	})
                .AndAsync("the section should show a green, yellow, and red bar chart of the percentages of passed, skipped, and failed scenarios", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.TestRunScenarioStats.BarChart);
               	})
                .And("the passed, green bar should have a width of 70%", (s) => {
					browser.ElementStyleMatches(Pages.HtmlReportPage.TestRunScenarioStats.SuccessBar, ".*width: 70\\..*");
               	})
                .And("the skipped, yellow bar should have a width of 26%", (s) => {
					browser.ElementStyleMatches(Pages.HtmlReportPage.TestRunScenarioStats.SkippedBar, ".*width: 25\\.9.*");
               	})
                .And("the failed, red bar should have a width of 4%", (s) => {
					browser.ElementStyleMatches(Pages.HtmlReportPage.TestRunScenarioStats.FailedBar, ".*width: 3\\.7.*");
               	})
                .RunAsync();
		}
		[ScenarioFact]
		public async void AreaStatsNoAreas()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfAnEmptyTestRun())
                .When(WebUser.ViewsReport(browser))
                .ThenAsync("there should be a section under the test run name that displays area statistics", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.TestRunAreaStats.Section);
                })
                .AndAsync("the total number of areas should show as a badge to the right of the test run name with a value of 0", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.TestRunAreaStats.Total);
					browser.ElementHasText(Pages.HtmlReportPage.TestRunAreaStats.Total, "0");
               	})
                .And("the badge should show 'Areas' when the user hovers over it", (s) => {
					browser.ElementHasTitle(Pages.HtmlReportPage.TestRunAreaStats.Total, "Areas");
               	})
                .And("the section should show the number of passed areas with a value of 0", (s) => {
					browser.ElementHasText(Pages.HtmlReportPage.TestRunAreaStats.Passed, "0");
               	})
                .And("the section should show the number of areas with skipped scenarios with a value of 0", (s) => {
					browser.ElementHasText(Pages.HtmlReportPage.TestRunAreaStats.Skipped, "0");
               	})
                .And("the section should show the number of areas with failed scenarios with a value of 0", (s) => {
					browser.ElementHasText(Pages.HtmlReportPage.TestRunAreaStats.Failed, "0");
               	})
                .AndAsync("the section should show a gray bar to indicate there are no areas", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.TestRunAreaStats.EmptyBar);
               	})
                .RunAsync();
		}
	}
}