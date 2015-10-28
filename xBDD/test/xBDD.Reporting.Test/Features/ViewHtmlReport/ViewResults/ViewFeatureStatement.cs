
using Xunit;
using Xunit.Abstractions;
using xBDD.Browser;
using xBDD.xUnit;
using xBDD.Reporting.Test.Steps;

namespace xBDD.Reporting.Test.Features.ViewHtmlReport.ViewResults
{
    [Collection("xBDDReportingTest")]
	public class ViewFeatureStatement
	{
		private readonly OutputWriter outputWriter;

		public ViewFeatureStatement(ITestOutputHelper output)
		{
			outputWriter = new OutputWriter(output);
		}
		
		[ScenarioFact]
		public async void FullStatement()
		{
			string featureStatement = "In order to derive some value\r\nAs a actor\r\nI would like to perform some action";
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfASinglePassingScenario("derive some value", "actor", "perform some action"))
                .When(WebUser.ViewsReport(browser))
				.AndAsync("the user expands to view a feature with a feature statement", async (s) => {
					await browser.ClickWhenVisible(Pages.HtmlReportPage.Area.Name(1));
				})
                .ThenAsync("the report should show the feature statement of:", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.Feature.Statement(1));
					browser.ElementHasText(Pages.HtmlReportPage.Feature.Statement(1), featureStatement);
                }, featureStatement)
                .Run();
		}
		[ScenarioFact]
		public async void PartialStatement()
		{
			string featureStatement = "In order to derive some value\r\nAs a [Missing!]\r\nI would like to [Missing!]";
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfASinglePassingScenario("derive some value"))
                .When(WebUser.ViewsReport(browser))
				.AndAsync("the user expands to view a feature with a feature statement", async (s) => {
					await browser.ClickWhenVisible(Pages.HtmlReportPage.Area.Name(1));
				})
                .ThenAsync("the report should show the feature statement of:", async (s) => {
					await browser.WaitTillVisible(Pages.HtmlReportPage.Feature.Statement(1));
					browser.ElementHasText(Pages.HtmlReportPage.Feature.Statement(1), featureStatement);
                }, featureStatement)
                .Run();
		}
		[ScenarioFact]
		public async void NoStatement()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfASinglePassingScenario())
                .When(WebUser.ViewsReport(browser))
				.AndAsync("the user expands to view a feature with a feature statement", async (s) => {
					await browser.ClickWhenVisible(Pages.HtmlReportPage.Area.Name(1));
				})
                .ThenAsync("the report should not show the feature statement", async (s) => {
					await browser.ClickWhenVisible(Pages.HtmlReportPage.Feature.Name(1));
					await browser.WaitTillVisible(Pages.HtmlReportPage.Scenario.Name(1));
					browser.ValidateNotExist(Pages.HtmlReportPage.Feature.Statement(1));
                })
                .Run();
		}
	}
}