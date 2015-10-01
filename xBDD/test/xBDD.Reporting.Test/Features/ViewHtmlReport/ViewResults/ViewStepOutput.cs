using xBDD.Reporting.Test.Pages;
using xBDD.Reporting.Test.Steps;
using xBDD.xUnit;
using Xunit;
using Xunit.Abstractions;

namespace xBDD.Reporting.Test.Features.ViewHtmlReport.ViewResutls
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
		public void GeneralText()
		{
            Wrapper<HtmlReportPage> htmlReport = new Wrapper<HtmlReportPage>();
			string output = "Here\r\n is\r\n my\r\n output!";
			var format = TextFormat.text;
            xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfAStepWithOutput(output, format))
                .When(WebUser.ViewsReport(htmlReport))
                .Then("the report will show the output indented under the step", (s) => {
					s.Output = htmlReport.Object.Html;
					s.OutputFormat = TextFormat.htmlpreview;
                    Assert.Equal(output, htmlReport.Object.GetStepOutputText(1));
					TextFormat? foundFormat = htmlReport.Object.GetStepOutputFormat(1); 
                    Assert.True(foundFormat.HasValue); 
                    Assert.Equal(foundFormat.Value, format); 
                })
                .Run();
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