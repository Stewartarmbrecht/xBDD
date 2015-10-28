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
	public class ViewStep
	{
		private readonly OutputWriter outputWriter;

		public ViewStep(ITestOutputHelper output)
		{
			outputWriter = new OutputWriter(output);
		}
		
		[ScenarioFact]
		public async void Passing()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfASinglePassingScenario())
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
                .ThenAsync("the report will show the step name in green to indicate it passed", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.Step.Green(1));
					browser.ElementHasText(Pages.HtmlReportPage.Step.Name(1), "Given my step 1");
                })
                .Run();
		}
		[ScenarioFact]
		public async void Skipped()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfASingleSkippedScenario())
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
                .ThenAsync("the report will show the step name in yellow to indicate the step was skipped", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.Step.Yellow(1));
                })
                .Run();
		}
		[ScenarioFact]
		public async void Failing()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfASingleFailedScenario())
                .When(WebUser.ViewsReport(browser))
                .ThenAsync("the report will show the step name in red to indicate a step failed", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.Step.Red(2));
                })
                .Run();
		}
		[ScenarioFact]
		public async void WithException()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfAFailingStepWithAnException())
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
		[ScenarioFact]
		public async void WithInnerException()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfAFailingStepWithANestedException())
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