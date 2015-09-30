using xBDD.Reporting.Test.Pages;
using xBDD.Reporting.Test.Steps;
using xBDD.xUnit;
using Xunit;
using Xunit.Abstractions;

namespace xBDD.Reporting.Test.Features.ViewHtmlReport.ViewResutls
{
	[Collection("xBDDReportingTest")]
	[Trait("category", "today")]
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
            Wrapper<HtmlReportPage> htmlReport = new Wrapper<HtmlReportPage>();
            xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfAnEmptyTestRun())
                .When(WebUser.ViewsReport(htmlReport))
                .Then("the report will show the test run name at the top", () => {
                    Assert.NotNull(htmlReport.Object.TestRunName);
                    Assert.Equal("My Test Run", htmlReport.Object.TestRunName.Text);
                })
                .And("the report will show the test run name as the title for the page", () => {
                    Assert.Equal("My Test Run", htmlReport.Object.Title);
                })
                .And("the report will show the test run name in gray to indicate no scenarios were run", () => {
					outputWriter.WriteLine(htmlReport.Object.TestRunName.GetAttribute("class"));
                    Assert.True(htmlReport.Object.TestRunNameIsGray());
                })
                .Run();
		}
		
		[ScenarioFact]
		public void PassingTestRun()
		{
            Wrapper<HtmlReportPage> htmlReport = new Wrapper<HtmlReportPage>();
            xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfASinglePassingScenario())
                .When(WebUser.ViewsReport(htmlReport))
                .Then("the report will show the test run name in green to indicate the test run passed", () => {
					outputWriter.WriteLine(htmlReport.Object.TestRunName.GetAttribute("class"));
                    Assert.True(htmlReport.Object.TestRunNameIsGreen());
                })
                .Run();
		}
		
		[ScenarioFact]
		public void PassingWithSomeSkipped()
		{
            Wrapper<HtmlReportPage> htmlReport = new Wrapper<HtmlReportPage>();
            xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfASingleSkippedScenario())
                .When(WebUser.ViewsReport(htmlReport))
                .Then("the report will show the test run name in yellow to indicate the test run passed", () => {
					outputWriter.WriteLine(htmlReport.Object.TestRunName.GetAttribute("class"));
                    Assert.True(htmlReport.Object.TestRunNameIsYellow());
                })
                .Run();
		}
		
		[ScenarioFact]
		public void Failing()
		{
            Wrapper<HtmlReportPage> htmlReport = new Wrapper<HtmlReportPage>();
            xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfASingleFailedScenario())
                .When(WebUser.ViewsReport(htmlReport))
                .Then("the report will show the test run name in red to indicate the test run passed", () => {
					outputWriter.WriteLine(htmlReport.Object.TestRunName.GetAttribute("class"));
                    Assert.True(htmlReport.Object.TestRunNameIsRed());
                })
                .Run();
		}
	}
}