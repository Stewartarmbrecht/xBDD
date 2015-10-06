using xBDD.Browser;
using xBDD.Reporting.Test.Pages;
using xBDD.Reporting.Test.Steps;
using xBDD.xUnit;
using Xunit;
using Xunit.Abstractions;

namespace xBDD.Reporting.Test.Features.ViewHtmlReport.ViewResults
{
	[Collection("xBDDReportingTest")]
	public class ViewScenario
	{
		private readonly OutputWriter outputWriter;

		public ViewScenario(ITestOutputHelper output)
		{
			outputWriter = new OutputWriter(output);
		}
		
		[ScenarioFact]
		public void Name()
		{
			 xBDD.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
		[ScenarioFact]
		public void Description()
		{
			 xBDD.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
		[ScenarioFact]
		public async void Passing()
		{
            Wrapper<HtmlReportPage> htmlReport = new Wrapper<HtmlReportPage>();
            await xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfAPassingFullTestRun())
                .When(WebUser.ViewsReport(htmlReport))
				.AndAsync("the user expands the first area", async (s) => {
					await Page.ClickWhenVisible("first area", htmlReport.Object.Area(1));
					await BootstrapPage.WaitTillExpanded("area 1 features", htmlReport.Object.AreaFeatures(1));
				})
				.AndAsync("the user expands the first feature", async (s) => {
					await Page.ClickWhenVisible("first feature", htmlReport.Object.Feature(1));
					await BootstrapPage.WaitTillExpanded("feature 1 scenarios", htmlReport.Object.FeatureScenarios(1));
					s.Output = htmlReport.Object.Html;
					s.OutputFormat = TextFormat.htmlpreview;
				})
                .ThenAsync("the report will show the scenario indented under the feature", async (s) => {
					await Page.WaitTillVisible("scenario 1", htmlReport.Object.Scenario(1));
                })
				.And("the scenario name will be green to indicate its passed", (s) => {
					Assert.Equal(Color.Green, htmlReport.Object.GetScenarioNameColor(1));
				})
                .AndAsync("the steps under the scenario will be collapsed", async (s) => {
					await BootstrapPage.WaitTillCollapsed("scenario 1 steps", htmlReport.Object.ScenarioSteps(1));
                })
                .RunAsync();
		}
		[ScenarioFact]
		public void Skipped()
		{
			 xBDD.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
				[ScenarioFact]
		public void Failing()
		{
			 xBDD.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}

	}
}