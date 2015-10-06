using xBDD.Browser;
using xBDD.Reporting.Test.Pages;
using xBDD.Reporting.Test.Steps;
using xBDD.xUnit;
using Xunit;
using Xunit.Abstractions;

namespace xBDD.Reporting.Test.Features.ViewHtmlReport.ViewResults
{
	[Collection("xBDDReportingTest")]
	[Trait("category", "today")]
	public class ViewStepOutput
	{
		private readonly OutputWriter outputWriter;

		public ViewStepOutput(ITestOutputHelper output)
		{
			outputWriter = new OutputWriter(output);
		}
		
		[ScenarioFact]
		public async void GeneralText()
		{
            Wrapper<HtmlReportPage> htmlReport = new Wrapper<HtmlReportPage>();
			string output = "Here\r\n is\r\n my\r\n output!";
			var format = TextFormat.text;
            await xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfAStepWithOutput(output, format))
                .When(WebUser.ViewsReport(htmlReport))
				.AndAsync("the user clicks the first area", async (s) => {
					await Page.ClickWhenVisible("first area", htmlReport.Object.Area(1));
				})
				.AndAsync("the user clicks the first feature", async (s) => {
					await Page.ClickWhenVisible("first feature", htmlReport.Object.Feature(1));
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
            Wrapper<HtmlReportPage> htmlReport = new Wrapper<HtmlReportPage>();
            xBDD.CurrentRun.AddScenario(this)
                .Skip("Not Started");
		}
		
		[ScenarioFact]
		public void HtmlWithPreview()
		{
            Wrapper<HtmlReportPage> htmlReport = new Wrapper<HtmlReportPage>();
            xBDD.CurrentRun.AddScenario(this)
                .Skip("Not Started");
		}
		
	}
}