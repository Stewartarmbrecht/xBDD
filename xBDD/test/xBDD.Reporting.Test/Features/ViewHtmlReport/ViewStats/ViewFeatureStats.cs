//using Xunit;
//using Xunit.Abstractions;
using xBDD.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xBDD.Reporting.Test.Steps;
using System.Threading.Tasks;

namespace xBDD.Reporting.Test.Features.ViewHtmlReport.ViewResults
{
    [TestClass]
	//  [Description("In order to understand how functionality is organized")]
	//  [Description("As a report reviewer")]
	//  [Description("I would like to view the features in the html report")]
	public class ViewFeatureStats
	{
		private readonly TestContextWriter outputWriter;

		public ViewFeatureStats()
		{
			outputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		public async Task FailedSkippedAndPassingScenarioStats()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfAFullTestRunWithAllOutcomes())
 				.When(WebUser.ViewsReport(browser))
                .ThenAsync("there should be a section under the feature name that displays scenario statistics", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.FeatureScenarioStats.Section(7));
                })
                .AndAsync("the total number of scenarios should show as a badge to the right of the feature name with a value of 3", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.FeatureScenarioStats.Total(7));
					browser.ElementHasText(Pages.HtmlReportPage.FeatureScenarioStats.Total(7), "3");
               	})
                .And("the badge should show 'Scenarios' when the user hovers over it", (s) => {
					browser.ElementHasTitle(Pages.HtmlReportPage.FeatureScenarioStats.Total(7), "Scenarios");
               	})
                .And("the section should show the number of passed scenarios with a value of 1", (s) => {
					browser.ElementHasText(Pages.HtmlReportPage.FeatureScenarioStats.Passed(7), "1");
               	})
                .And("the section should show the number of skipped scenarios with a value of 1", (s) => {
					browser.ElementHasText(Pages.HtmlReportPage.FeatureScenarioStats.Skipped(7), "1");
               	})
                .And("the section should show the number of failed scenarios with a value of 1", (s) => {
					browser.ElementHasText(Pages.HtmlReportPage.FeatureScenarioStats.Failed(7), "1");
               	})
                .AndAsync("the section should a green, yellow, and red bar chart of the percentages of passed, skipped, and failed scenarios", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.FeatureScenarioStats.BarChart(7));
               	})
                .And("the passed, green bar should have a width of 33%", (s) => {
					browser.ElementStyleMatches(Pages.HtmlReportPage.FeatureScenarioStats.SuccessBar(7), ".*width: 33\\..*");
               	})
                .And("the skipped, yellow bar should have a width of 33%", (s) => {
					browser.ElementStyleMatches(Pages.HtmlReportPage.FeatureScenarioStats.SkippedBar(7), ".*width: 33\\..*");
               	})
                .And("the failed, red bar should have a width of 33%", (s) => {
					browser.ElementStyleMatches(Pages.HtmlReportPage.FeatureScenarioStats.FailedBar(7), ".*width: 33\\..*");
               	})
                .Run();
		}
	}
}