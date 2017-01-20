//using Xunit;
//using Xunit.Abstractions;
using xBDD.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xBDD.Reporting.Test.Steps;
using System.Threading.Tasks;

namespace xBDD.Reporting.Test.Features.ViewHtmlReport.ViewResults
{
    [TestClass]
	public class ViewStepOutput
	{
		private readonly TestContextWriter outputWriter;

		public ViewStepOutput()
		{
			outputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		public async Task CollapsedByDefault()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
			string output = "Here\r\n is\r\n my\r\n output!";
			var format = TextFormat.text;
            await xB.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfAStepWithOutput(output, format))
                .When(WebUser.ViewsReport(browser))
				.AndAsync("the user clicks the first area", async (s) => {
					await browser.ClickWhenVisible(Pages.HtmlReportPage.Area.Name(1));
					await browser.WaitTillVisible(Pages.HtmlReportPage.Area.Features(1));
				})
				.AndAsync("the user clicks the first feature", async (s) => {
					await browser.ClickWhenVisible(Pages.HtmlReportPage.Feature.Name(1));
					await browser.WaitTillVisible(Pages.HtmlReportPage.Feature.Scenarios(1));
				})
				.AndAsync("the user clicks the first scenario", async (s) => {
					await browser.ClickWhenVisible(Pages.HtmlReportPage.Scenario.Name(1));
					await browser.WaitTillVisible(Pages.HtmlReportPage.Scenario.Steps(1));
				})
                .ThenAsync("the report will show an [Output] link to the left of the step name", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.Output.Link(1));
                })
                .Run();
		}
		
		[TestMethod]
		public async Task GeneralText()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
			string output = "Here\r\n is\r\n my\r\n output!";
			var format = TextFormat.text;
            await xB.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfAStepWithOutput(output, format))
                .When(WebUser.ViewsReport(browser))
				.AndAsync("the user clicks the first area", async (s) => {
					await browser.ClickWhenVisible(Pages.HtmlReportPage.Area.Name(1));
					await browser.WaitTillVisible(Pages.HtmlReportPage.Area.Features(1));
				})
				.AndAsync("the user clicks the first feature", async (s) => {
					await browser.ClickWhenVisible(Pages.HtmlReportPage.Feature.Name(1));
					await browser.WaitTillVisible(Pages.HtmlReportPage.Feature.Scenarios(1));
				})
				.AndAsync("the user clicks the first scenario", async (s) => {
					await browser.ClickWhenVisible(Pages.HtmlReportPage.Scenario.Name(1));
					await browser.WaitTillVisible(Pages.HtmlReportPage.Scenario.Steps(1));
				})
				.AndAsync("the user clicks the first scenario", async (s) => {
					await browser.ClickWhenVisible(Pages.HtmlReportPage.Output.Link(1));
					await browser.WaitTillVisible(Pages.HtmlReportPage.Output.Section(1));
				})
                .Then("the report will show the output indented under the step", (s) => {
					s.Output = browser.GetPageSource();
					s.OutputFormat = TextFormat.htmlpreview;
					browser.ElementHasText(Pages.HtmlReportPage.Output.Text(1), output);
                })
                .Run();
		}
		
		[TestMethod]
		public async Task Code()
		{
            await xB.CurrentRun.AddScenario(this)
                .Skip("Not Started");
		}
		
		[TestMethod]
		public async Task HtmlWithPreview()
		{
            await xB.CurrentRun.AddScenario(this)
                .Skip("Not Started");
		}
		
	}
}