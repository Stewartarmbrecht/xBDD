using xBDD.Browser;
using xBDD.Reporting.Test.Pages;
using xBDD.Reporting.Test.Steps;
using xBDD.xUnit;
using Xunit;
using Xunit.Abstractions;

namespace xBDD.Reporting.Test.Features.ViewHtmlReport.ViewResults
{
	[Collection("xBDDReportingTest")]
	public class ViewFeature
	{
		private readonly OutputWriter outputWriter;

		public ViewFeature(ITestOutputHelper output)
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
				})
                .ThenAsync("the report will show the feature indented under the area", async (s) => {
					await BootstrapPage.WaitTillExpanded("area 1 features", htmlReport.Object.AreaFeatures(1));
					s.Output = htmlReport.Object.Html;
					s.OutputFormat = TextFormat.htmlpreview;
					await Page.WaitTillVisible("feature 1", htmlReport.Object.Feature(1));
                })
				.And("the feature name will be green to indicate its passed", (s) => {
					Assert.Equal(Color.Green, htmlReport.Object.GetFeatureNameColor(1));
				})
                .AndAsync("the scenarios under the feature will be collapsed", async (s) => {
					await BootstrapPage.WaitTillCollapsed("feature 1 scenarios", htmlReport.Object.FeatureScenarios(1));
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