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
	public class ReviewStep
	{
		private readonly TestContextWriter outputWriter;

		public ReviewStep()
		{
			outputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		public async Task Passing()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(AnHtmlReport.OfASinglePassingScenario())
                .When(WebUser.ViewsReport(browser))
				.AndAsync("the user clicks the first area", async (s) => {
					await browser.ClickWhenVisible(Pages.HtmlReportPage.Area.Name(1));
				})
				.AndAsync("the user clicks the first feature", async (s) => {
					await browser.ClickWhenVisible(Pages.HtmlReportPage.Feature.Name(1));
				})
				.AndAsync("the user clicks the first scenario", async (s) => {
					await browser.ClickWhenVisible(Pages.HtmlReportPage.Scenario.Name(1));
				})
                .ThenAsync("the report will show the step badge in green to indicate it passed", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.Step.BadgeGreen(1));
					browser.ElementHasText(Pages.HtmlReportPage.Step.Name(1), "Given my step 1");
                })
                .Run();
		}
		[TestMethod]
		public async Task Skipped()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(AnHtmlReport.OfASingleSkippedScenario())
                .When(WebUser.ViewsReport(browser))
				.AndAsync("the user clicks the first area", async (s) => {
					await browser.ClickWhenVisible(Pages.HtmlReportPage.Area.Name(1));
				})
				.AndAsync("the user clicks the first feature", async (s) => {
					await browser.ClickWhenVisible(Pages.HtmlReportPage.Feature.Name(1));
				})
				.AndAsync("the user clicks the first scenario", async (s) => {
					await browser.ClickWhenVisible(Pages.HtmlReportPage.Scenario.Name(1));
				})
                .ThenAsync("the report will show the step badge in yellow to indicate the step was skipped", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.Step.BadgeYellow(1));
                })
                .Run();
		}
		[TestMethod]
		public async Task Failing()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(AnHtmlReport.OfASingleFailedScenario())
                .When(WebUser.ViewsReport(browser))
                .ThenAsync("the report will show the step badge in red to indicate a step failed", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.Step.BadgeRed(2));
                })
                .Run();
		}
		[TestMethod]
		public async Task WithException()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(AnHtmlReport.OfAFailingStepWithAnException())
				.When(WebUser.ViewsReport(browser))
                .ThenAsync("the user should see a section for the exception", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.Exception.Section(2));
				})
       			.AndAsync("the section should display the exception type", async (s) => { 
					await browser.WaitTillVisible(Pages.HtmlReportPage.Exception.Type(2));
				})
       			.AndAsync("the section should display the exception message", async (s) => { 
					await browser.WaitTillVisible(Pages.HtmlReportPage.Exception.Message(2));
				})
       			.AndAsync("the section should display the exception stack trace", async (s) => { 
					await browser.WaitTillVisible(Pages.HtmlReportPage.Exception.StackTrace(2));
				})
				.Run();
		}
		[TestMethod]
		public async Task WithInnerException()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(AnHtmlReport.OfAFailingStepWithANestedException())
				.When(WebUser.ViewsReport(browser))
                .ThenAsync("the user should see a section for the nsted exception", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.Exception.InnerException(2));
				})
       			.AndAsync("the section should display the exception type", async (s) => { 
					await browser.WaitTillVisible(Pages.HtmlReportPage.Exception.InnerExceptionType(2));
				})
       			.AndAsync("the section should display the exception message", async (s) => { 
					await browser.WaitTillVisible(Pages.HtmlReportPage.Exception.InnerExceptionMessage(2));
				})
       			.AndAsync("the section should display the exception stack trace", async (s) => { 
					await browser.WaitTillVisible(Pages.HtmlReportPage.Exception.InnerExceptionStackTrace(2));
				})
				.Run();
		}
	}
}