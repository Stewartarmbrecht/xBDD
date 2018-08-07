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
	//  [Description("I would like to view the features in the html report")]
	public class ReviewScenarioStats
	{
		private readonly TestContextWriter outputWriter;

		public ReviewScenarioStats()
		{
			outputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		[TestCategory("now")]
		public async Task FailedSkippedAndPassingStepsStats()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(AnHtmlReport.OfAFullTestRunWithAllOutcomes())
 				.When(WebUser.ViewsReport(browser))
                .ThenAsync("the total number of steps should show as a badge to the right of the scenario name with a value of 3", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.ScenarioStepStats.Total(19));
					browser.ElementHasText(Pages.HtmlReportPage.ScenarioStepStats.Total(19), "3");
               	})
                .And("the badge should show 'Steps' when the user hovers over it", (s) => {
					browser.ElementHasTitle(Pages.HtmlReportPage.ScenarioStepStats.Total(19), "Steps");
               	})
                .Run();
		}
	}
}