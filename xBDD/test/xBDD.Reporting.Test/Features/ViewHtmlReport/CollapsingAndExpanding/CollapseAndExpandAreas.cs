using xBDD.Reporting.Test.Pages;
using xBDD.Reporting.Test.Steps;
using xBDD.xUnit;
using Xunit;
using Xunit.Abstractions;
using xBDD.Browser;

namespace xBDD.Reporting.Test.Features.ViewHtmlReport.CollapsingAndExpanding
{
	[Collection("xBDDReportingTest")]
	public class CollapseAndExpandAreas
	{
		private readonly OutputWriter outputWriter;

		public CollapseAndExpandAreas(ITestOutputHelper output)
		{
			outputWriter = new OutputWriter(output);
		}
		[ScenarioFact]
		[Trait("category", "now")]
		public async void Collapse()
		{
            Wrapper<HtmlReportPage> htmlReport = new Wrapper<HtmlReportPage>();
            await xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfASingleSkippedScenario())
				.And(WebUser.ViewsReport(htmlReport))
                .When("the user clicks the first area", (s) => { 
					htmlReport.Object.ClickArea(1);
				})
                .ThenAsync("the report should collapse the features listed under the area", async (s) => {
					s.Output = htmlReport.Object.Html;
					s.OutputFormat = TextFormat.htmlpreview;
					await Page.WaitTillNotVisible(htmlReport.Object.AreaFeatures(1), 5000);
                })
                .RunAsync();
		}
		[ScenarioFact]
		[Trait("category", "now")]
		public async void CollapseAll()
		{
            Wrapper<HtmlReportPage> htmlReport = new Wrapper<HtmlReportPage>();
            await xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfAPassingFullTestRun())
				.And(WebUser.ViewsReport(htmlReport))
                .WhenAsync("the user clicks the collapse all areas menu option", async (s) => { 
					htmlReport.Object.MenuButton.Click();
					await Page.WaitTillVisible(htmlReport.Object.CollapseAllAreasButton, 500);
					htmlReport.Object.CollapseAllAreasButton.Click();
				})
                .ThenAsync("the report should collapse the features listed under the area", async (s) => {
					s.Output = htmlReport.Object.Html;
					s.OutputFormat = TextFormat.htmlpreview;
					await Page.WaitTillNotVisible(htmlReport.Object.AreaFeatures(1), 500);
					await Page.WaitTillNotVisible(htmlReport.Object.AreaFeatures(2), 500);
                })
                .RunAsync();
		}
		[ScenarioFact]
		public void Expand()
		{
			 xBDD.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
		[ScenarioFact]
		public void ExpandAll()
		{
			 xBDD.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
		[ScenarioFact]
		public void DefaultCollapsedWhenMoreThan5()
		{
			 xBDD.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
	}
}
