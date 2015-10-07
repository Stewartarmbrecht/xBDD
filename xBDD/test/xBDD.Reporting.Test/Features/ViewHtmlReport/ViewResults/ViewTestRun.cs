using xBDD.Reporting.Test.Pages;
using xBDD.Reporting.Test.Steps;
using xBDD.xUnit;
using Xunit;
using Xunit.Abstractions;

namespace xBDD.Reporting.Test.Features.ViewHtmlReport.ViewResults
{
	[Collection("xBDDReportingTest")]
	public class ViewTestRun
	{
		private readonly OutputWriter outputWriter;

		public ViewTestRun(ITestOutputHelper output)
		{
			outputWriter = new OutputWriter(output);
		}
		
		[ScenarioFact]
		public void EmptyTestRun()
		{
            Wrapper<HtmlReportPageGeneral> htmlReport = new Wrapper<HtmlReportPageGeneral>();
            xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfAnEmptyTestRun())
                .When(WebUser.ViewsReportGeneral(htmlReport))
                .Then("the report will show the test run name at the top", (s) => {
                    Assert.NotNull(htmlReport.Object.TestRunName);
                    Assert.Equal("My Test Run", htmlReport.Object.TestRunName.Text);
                })
                .And("the report will show the test run name as the title for the page", (s) => {
                    Assert.Equal("My Test Run", htmlReport.Object.Title);
                })
                .And("the report will show the test run name in gray to indicate no scenarios were run", (s) => {
					outputWriter.WriteLine(htmlReport.Object.TestRunName.GetAttribute("class"));
                    Assert.Equal(Color.Gray, htmlReport.Object.GetTestRunNameColor());
                })
                .Run();
		}
		
		[ScenarioFact]
		public void PassingTestRun()
		{
            Wrapper<HtmlReportPageGeneral> htmlReport = new Wrapper<HtmlReportPageGeneral>();
            xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfASinglePassingScenario())
                .When(WebUser.ViewsReportGeneral(htmlReport))
                .Then("the report will show the test run name in green to indicate the test run passed", (s) => {
					outputWriter.WriteLine(htmlReport.Object.TestRunName.GetAttribute("class"));
                    Assert.Equal(Color.Green, htmlReport.Object.GetTestRunNameColor());
                })
                .Run();
		}
		
		[ScenarioFact]
		public void PassingWithSomeSkipped()
		{
            Wrapper<HtmlReportPageGeneral> htmlReport = new Wrapper<HtmlReportPageGeneral>();
            xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfASingleSkippedScenario())
                .When(WebUser.ViewsReportGeneral(htmlReport))
                .Then("the report will show the test run name in yellow to indicate the test run passed", (s) => {
					outputWriter.WriteLine(htmlReport.Object.TestRunName.GetAttribute("class"));
                    Assert.Equal(Color.Yellow, htmlReport.Object.GetTestRunNameColor());
                })
                .Run();
		}
		
		[ScenarioFact]
		public void Failing()
		{
            Wrapper<HtmlReportPageGeneral> htmlReport = new Wrapper<HtmlReportPageGeneral>();
            xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfASingleFailedScenario())
                .When(WebUser.ViewsReportGeneral(htmlReport))
                .Then("the report will show the test run name in red to indicate the test run passed", (s) => {
					outputWriter.WriteLine(htmlReport.Object.TestRunName.GetAttribute("class"));
                    Assert.Equal(Color.Red, htmlReport.Object.GetTestRunNameColor());
                })
                .Run();
		}
	}
}