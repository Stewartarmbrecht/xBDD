//using Xunit;
//using Xunit.Abstractions;
using xBDD.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xBDD.Reporting.Test.Steps;
using System.Threading.Tasks;
using System;

namespace xBDD.Reporting.Test.Features.ViewHtmlReport.ViewResults
{
    [TestClass]
	//  [Description("In order to understand how functionality is organized")]
	//  [Description("As a report reviewer")]
	//  [Description("I would like to view the areas in the html report")]
	public class ViewArea
	{
		private readonly TestContextWriter outputWriter;

		public ViewArea()
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
                .ThenAsync("the report will show the area badge in green to indicate all features passed", (Func<Model.Step, Task>)(async (s) => {
                    System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + " Then Start");
                    await browser.WaitTillVisible(Pages.HtmlReportPage.Area.BadgeGreen((int)1));
					browser.ElementHasText(Pages.HtmlReportPage.Area.Name(1), "My Area 1");
                    System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + " Then End");
                }))
				.AndAsync("the features under the area will be collapsed because it passed", async (s) => {
                    System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + " And Start");
                    await browser.WaitTillNotVisible(Pages.HtmlReportPage.Area.Features(1));
                    System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + " And End");
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
                .ThenAsync("the report will show the area badge in yellow to indicate scenarios were skipped", (Func<Model.Step, Task>)(async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.Area.BadgeYellow(1));
                }))
				.AndAsync("the features under the area will be collapsed because it was not failing", async (s) => {
					await browser.WaitTillNotVisible(Pages.HtmlReportPage.Area.Features(1));
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
                .ThenAsync("the report will show the area badge in red to indicate a scenario failed", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.Area.BadgeRed(1));
                })
				.AndAsync("the features under the area will be expanded because it has a failing scenario", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.Area.Features(1));
				})
                .Run();
		}
	}
}