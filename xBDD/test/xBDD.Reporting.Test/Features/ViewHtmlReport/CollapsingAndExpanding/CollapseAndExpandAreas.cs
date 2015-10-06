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
		public async void Collapse()
		{
            Wrapper<HtmlReportPage> htmlReport = new Wrapper<HtmlReportPage>();
            await xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfASingleSkippedScenario())
				.And(WebUser.ViewsReport(htmlReport))
                .AndAsync("the user expands the first area", async (s) => { 
					s.Output = htmlReport.Object.Html;
					s.OutputFormat = TextFormat.htmlpreview;
					await Page.ClickWhenVisible("area 1", htmlReport.Object.Area(1));
					await BootstrapPage.WaitTillExpanded("area 1 features", htmlReport.Object.AreaFeatures(1));
					s.Output = htmlReport.Object.Html;
					s.OutputFormat = TextFormat.htmlpreview;
				})
                .WhenAsync("the user cliks the first area again", async (s) => { 
					await Page.ClickWhenVisible("area 1", htmlReport.Object.Area(1), 500);
				})
                .ThenAsync("the report should collapse the features listed under the area", async (s) => {
					await BootstrapPage.WaitTillCollapsed("area 1 features", htmlReport.Object.AreaFeatures(1));
					s.Output = htmlReport.Object.Html;
					s.OutputFormat = TextFormat.htmlpreview;
                })
                .RunAsync();
		}
		[ScenarioFact]
		public async void CollapseAll()
		{
			 await xBDD.CurrentRun.AddScenario(this)
				.SkipAsync("Not Started");
		}
		[ScenarioFact]
		public async void Expand()
		{
            Wrapper<HtmlReportPage> htmlReport = new Wrapper<HtmlReportPage>();
            await xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfASingleSkippedScenario())
				.And(WebUser.ViewsReport(htmlReport))
                .When("the user clicks the first area", (s) => { 
					Page.ClickWhenVisible("first area", htmlReport.Object.Area(1));
				})
                .ThenAsync("the report should expand the features listed under the area", async (s) => {
					await BootstrapPage.WaitTillExpanded("features", htmlReport.Object.AreaFeatures(1));
					s.Output = htmlReport.Object.Html;
					s.OutputFormat = TextFormat.htmlpreview;
                })
                .RunAsync();
		}
		[ScenarioFact]
		public async void ExpandAll()
		{
            Wrapper<HtmlReportPage> htmlReport = new Wrapper<HtmlReportPage>();
            await xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfAPassingFullTestRun())
				.And(WebUser.ViewsReport(htmlReport))
                .WhenAsync("the user clicks the expand all areas menu option", async (s) => { 
					await Page.ClickWhenVisible("menu button", htmlReport.Object.MenuButton);
					await Page.ClickWhenVisible("expand all areas button", htmlReport.Object.ExpandAllAreasButton);
				})
                .ThenAsync("the report should expand the features listed under the area", async (s) => {
					await BootstrapPage.WaitTillExpanded("area 1 features", htmlReport.Object.AreaFeatures(1));
					await BootstrapPage.WaitTillExpanded("area 2 features", htmlReport.Object.AreaFeatures(2));
					s.Output = htmlReport.Object.Html;
					s.OutputFormat = TextFormat.htmlpreview;
                })
                .RunAsync();
		}
	}
}
