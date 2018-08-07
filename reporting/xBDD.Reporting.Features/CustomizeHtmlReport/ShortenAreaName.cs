using xBDD.Test;
using xBDD.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xBDD.Reporting.Features.Steps;
using System.Threading.Tasks;
using System;

namespace xBDD.Reporting.Features.CustomizeHtmlReport
{
    [TestClass]
	[AsA("Developer")]
	[By("shorten the area name by removing the beginning of the name that matches a provided string")]
	[YouCan("shorten the area name in the Html report.")]
	public class ShortenAreaName
	{
		private readonly TestContextWriter outputWriter;

		public ShortenAreaName()
		{
			outputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		public async Task MatchesStartOfAreaName()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(AnHtmlReport.OfASinglePassingScenario(null,null,null,"My "))
				.And("the HTML writer was set to skip 'My ' when writing the area name", (s) => {})
                .When(WebUser.ViewsReport(browser))
                .ThenAsync("the report will show the area name without 'My ' as 'Area 1'", async (s) => {
                    await browser.WaitTillVisible(Pages.HtmlReportPage.Area.Name(1));
					browser.ElementHasText(Pages.HtmlReportPage.Area.Name(1), "Area 1");
                })
                .Run();
		}
		[TestMethod]
		public async Task MatchesNoneOfAreaName()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(AnHtmlReport.OfASinglePassingScenario(null,null,null,"No Match"))
				.And("the HTML writer was set to skip 'No Match' when writing the area name", (s) => {})
                .When(WebUser.ViewsReport(browser))
                .ThenAsync("the report will show the area name unmodified as 'My Area 1'", async (s) => {
                    await browser.WaitTillVisible(Pages.HtmlReportPage.Area.Name(1));
					browser.ElementHasText(Pages.HtmlReportPage.Area.Name(1), "My Area 1");
                })
                .Run();
		}
		[TestMethod]
		public async Task MatchesAllOfAreaName()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(AnHtmlReport.OfASinglePassingScenario(null,null,null,"My Area 1"))
				.And("the HTML writer was set to skip 'My Area 1' when writing the area name", (s) => {})
                .When(WebUser.ViewsReport(browser))
                .ThenAsync("the report will show the area name unmodified as ''", async (s) => {
                    await browser.WaitTillVisible(Pages.HtmlReportPage.Area.BadgeGreen(1));
					browser.ElementHasText(Pages.HtmlReportPage.Area.Name(1), "");
                })
                .Run();
		}
	}
}