using xBDD.Test;
using xBDD.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xBDD.Reporting.Features.Steps;
using System.Threading.Tasks;

namespace xBDD.Reporting.Features.BrowseHtmlReport
{
    [TestClass]
	//  [Description("In order to understand how functionality is organized")]
	//  [Description("As a report reviewer")]
	//  [Description("I would like to view the areas in the html report")]
	public class ReviewAreaStats
	{
		private readonly TestContextWriter outputWriter;

		public ReviewAreaStats()
		{
			outputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		public async Task FailedSkippedAndPassingFeatureStats()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(AnHtmlReport.OfAFullTestRunWithAllOutcomes())
				.When(WebUser.ViewsReport(browser))
				.And("the user expands the stats by clicking on the area badge", async (s) => {
					await browser.ClickWhenVisible(Pages.HtmlReportPage.Area.Badge(3));
				})
                .ThenAsync("there should be a section under the area name that displays feature statistics about the area", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.AreaFeatureStats.Section(3));
                })
                .AndAsync("the total number of features should show as a badge to the right of the area name with a value of 3", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.AreaFeatureStats.Total(3));
					browser.ElementHasText(Pages.HtmlReportPage.AreaFeatureStats.Total(3), "3");
               	})
                .And("the badge should show 'Features' when the user hovers over it", (s) => {
					browser.ElementHasTitle(Pages.HtmlReportPage.AreaFeatureStats.Total(3), "Features");
               	})
                .And("the section should show the number of passed features with a value of 1", (s) => {
					browser.ElementHasText(Pages.HtmlReportPage.AreaFeatureStats.Passed(3), "1");
               	})
                .And("the section should show the number of skipped features with a value of 1", (s) => {
					browser.ElementHasText(Pages.HtmlReportPage.AreaFeatureStats.Skipped(3), "1");
               	})
                .And("the section should show the number of failed features with a value of 1", (s) => {
					browser.ElementHasText(Pages.HtmlReportPage.AreaFeatureStats.Failed(3), "1");
               	})
                .AndAsync("the section should a green, yellow, and red bar chart of the percentages of passed, skipped, and failed features", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.AreaFeatureStats.BarChart(3));
               	})
                .And("the passed, green bar should have a width of 33%", (s) => {
					browser.ElementStyleMatches(Pages.HtmlReportPage.AreaFeatureStats.SuccessBar(3), ".*width: 33\\..*");
               	})
                .And("the skipped, yellow bar should have a width of 33%", (s) => {
					browser.ElementStyleMatches(Pages.HtmlReportPage.AreaFeatureStats.SkippedBar(3), ".*width: 33\\..*");
               	})
                .And("the failed, red bar should have a width of 33%", (s) => {
					browser.ElementStyleMatches(Pages.HtmlReportPage.AreaFeatureStats.FailedBar(3), ".*width: 33\\..*");
               	})
                .Run();
		}
		[TestMethod]
		public async Task FailedSkippedAndPassingScenarioStats()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(AnHtmlReport.OfAFullTestRunWithAllOutcomes())
 				.When(WebUser.ViewsReport(browser))
				.And("the user expands the stats by clicking on the area badge", async (s) => {
					await browser.ClickWhenVisible(Pages.HtmlReportPage.Area.Badge(3));
				})
                .ThenAsync("there should be a section under the area name that displays scenario statistics about the area", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.AreaScenarioStats.Section(3));
                })
                .And("the section should show the number of passed scenarios with a value of 5", (s) => {
					browser.ElementHasText(Pages.HtmlReportPage.AreaScenarioStats.Passed(3), "5");
               	})
                .And("the section should show the number of skipped scenarios with a value of 3", (s) => {
					browser.ElementHasText(Pages.HtmlReportPage.AreaScenarioStats.Skipped(3), "3");
               	})
                .And("the section should show the number of failed scenarios with a value of 1", (s) => {
					browser.ElementHasText(Pages.HtmlReportPage.AreaScenarioStats.Failed(3), "1");
               	})
                .AndAsync("the section should a green, yellow, and red bar chart of the percentages of passed, skipped, and failed scenarios", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.AreaScenarioStats.BarChart(3));
               	})
                .And("the passed, green bar should have a width of 55%", (s) => {
					browser.ElementStyleMatches(Pages.HtmlReportPage.AreaScenarioStats.SuccessBar(3), ".*width: 55\\..*");
               	})
                .And("the skipped, yellow bar should have a width of 33%", (s) => {
					browser.ElementStyleMatches(Pages.HtmlReportPage.AreaScenarioStats.SkippedBar(3), ".*width: 33\\..*");
               	})
                .And("the failed, red bar should have a width of 11%", (s) => {
					browser.ElementStyleMatches(Pages.HtmlReportPage.AreaScenarioStats.FailedBar(3), ".*width: 11\\..*");
               	})
                .Run();
		}
	}
}