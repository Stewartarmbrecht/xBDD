using xBDD.Browser;
using xBDD.Reporting.Test.Pages;
using xBDD.Reporting.Test.Steps;
using xBDD.xUnit;
using Xunit;
using Xunit.Abstractions;

namespace xBDD.Reporting.Test.Features.ViewHtmlReport.ViewResults
{
	[Collection("xBDDReportingTest")]
	public class ViewStepOutput
	{
		private readonly OutputWriter outputWriter;

		public ViewStepOutput(ITestOutputHelper output)
		{
			outputWriter = new OutputWriter(output);
		}
		
		[ScenarioFact]
		public async void CollapsedByDefault()
		{
            Wrapper<HtmlReportPageGeneral> htmlReport = new Wrapper<HtmlReportPageGeneral>();
			string output = "Here\r\n is\r\n my\r\n output!";
			var format = TextFormat.text;
            await xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfAStepWithOutput(output, format))
                .When(WebUser.ViewsReportGeneral(htmlReport))
				.AndAsync("the user clicks the first area", async (s) => {
					await Page.ClickWhenVisible("first area", htmlReport.Object.Area(1));
					await BootstrapPage.WaitTillExpanded("first area features", htmlReport.Object.AreaFeatures(1));
				})
				.AndAsync("the user clicks the first feature", async (s) => {
					await Page.ClickWhenVisible("first feature", htmlReport.Object.Feature(1));
					await BootstrapPage.WaitTillExpanded("first feature scenarios", htmlReport.Object.FeatureScenarios(1));
				})
				.AndAsync("the user clicks the first scenario", async (s) => {
					await Page.ClickWhenVisible("first scenario", htmlReport.Object.ScenarioTitleLine(1));
					await BootstrapPage.WaitTillExpanded("first scenario steps", htmlReport.Object.ScenarioSteps(1));
				})
                .ThenAsync("the report will show an [Output] link to the left of the step name", async (s) => {
					s.Output = htmlReport.Object.Html;
					s.OutputFormat = TextFormat.htmlpreview;
					await Page.WaitTillVisible("step 1 output link", htmlReport.Object.StepOutputLink(1));
                })
                .RunAsync();
		}
		
		[ScenarioFact]
		public async void GeneralText()
		{
            Wrapper<HtmlReportPageGeneral> htmlReport = new Wrapper<HtmlReportPageGeneral>();
			string output = "Here\r\n is\r\n my\r\n output!";
			var format = TextFormat.text;
            await xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfAStepWithOutput(output, format))
                .When(WebUser.ViewsReportGeneral(htmlReport))
				.AndAsync("the user clicks the first area", async (s) => {
					await Page.ClickWhenVisible("first area", htmlReport.Object.Area(1));
					await BootstrapPage.WaitTillExpanded("first area features", htmlReport.Object.AreaFeatures(1));
				})
				.AndAsync("the user clicks the first feature", async (s) => {
					await Page.ClickWhenVisible("first feature", htmlReport.Object.Feature(1));
					await BootstrapPage.WaitTillExpanded("first feature scenarios", htmlReport.Object.FeatureScenarios(1));
				})
				.AndAsync("the user clicks the first scenario", async (s) => {
					await Page.ClickWhenVisible("first scenario", htmlReport.Object.ScenarioTitleLine(1));
					await BootstrapPage.WaitTillExpanded("first scenario steps", htmlReport.Object.ScenarioSteps(1));
				})
				.AndAsync("the user clicks the first steps [Output] link", async (s) => {
					await Page.ClickWhenVisible("first step [Output] link", htmlReport.Object.StepOutputLink(1));
					await BootstrapPage.WaitTillExpanded("first steps output", htmlReport.Object.StepOutput(1));
				})
                .Then("the report will show the output indented under the step", (s) => {
					s.Output = htmlReport.Object.Html;
					s.OutputFormat = TextFormat.htmlpreview;
                    Assert.Equal(output, htmlReport.Object.GetStepOutputText(1));
					TextFormat? foundFormat = htmlReport.Object.GetStepOutputFormat(1); 
                    Assert.True(foundFormat.HasValue); 
                    Assert.Equal(foundFormat.Value, format); 
                })
                .RunAsync();
		}
		
		[ScenarioFact]
		public void Code()
		{
            Wrapper<HtmlReportPageGeneral> htmlReport = new Wrapper<HtmlReportPageGeneral>();
            xBDD.CurrentRun.AddScenario(this)
                .Skip("Not Started");
		}
		
		[ScenarioFact]
		public void HtmlWithPreview()
		{
            Wrapper<HtmlReportPageGeneral> htmlReport = new Wrapper<HtmlReportPageGeneral>();
            xBDD.CurrentRun.AddScenario(this)
                .Skip("Not Started");
		}
		
	}
}