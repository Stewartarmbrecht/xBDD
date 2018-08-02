using xBDD.Browser;
using xBDD.Reporting.Test.Steps;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace xBDD.Reporting.Test.Features.ViewHtmlReport.CollapsingAndExpanding
{
    [TestClass]
	public class CollapseAndExpandAreas
	{
		private readonly TestContextWriter outputWriter;

		public CollapseAndExpandAreas()
		{
			outputWriter = new TestContextWriter();
		}
		[TestMethod]
		public async Task Collapse()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfASingleFailedScenario())
                .And(WebUser.ViewsReport(browser))
                .WhenAsync("the user cliks the first area", async (s) => { 
					await browser.ClickWhenVisible(Pages.HtmlReportPage.Area.Name(1));
				})
                .ThenAsync("the report should collapse the features listed under the area", async (s) => {
					await browser.WaitTillNotVisible(Pages.HtmlReportPage.Area.Features(1));
                })
                .Run();
		}
        [TestMethod]
        public async Task CollapseAll()
		{
			 await xB.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
        [TestMethod]
        public async Task Expand()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfASingleSkippedScenario())
                .And(WebUser.ViewsReport(browser))
                .WhenAsync("the user cliks the first area", async (s) => { 
					await browser.ClickWhenVisible(Pages.HtmlReportPage.Area.Name(1));
				})
                .ThenAsync("the report should expand the features listed under the area", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.Area.Features(1));
                })
                .Run();
		}
        [TestMethod]
        public async Task ExpandAll()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfAPassingFullTestRun())
                .And(WebUser.ViewsReport(browser))
                .WhenAsync("the user clicks the expand all areas menu option", async (s) => {
					await browser.ClickWhenVisible(Pages.HtmlReportPage.Menu.MenuButton);
					await browser.ClickWhenVisible(Pages.HtmlReportPage.Menu.ExpandAllAreasButton);
				})
                .ThenAsync("the report should expand the features listed under the area", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.Area.Features(1));
					await browser.WaitTillVisible(Pages.HtmlReportPage.Area.Features(2));
					s.Output = browser.GetPageSource();
					s.OutputFormat = TextFormat.htmlpreview;
                })
                .Run();
		}
	}
}