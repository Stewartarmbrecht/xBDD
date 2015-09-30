using xBDD.Reporting.Test.Pages;
using xBDD.Reporting.Test.Steps;
using xBDD.xUnit;
using Xunit;
using Xunit.Abstractions;

namespace xBDD.Reporting.Test.Features.ViewHtmlReport.ViewResutls
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
		[Trait("category", "today")]
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
		[Trait("category", "today")]
		public void PassingTestRun()
		{
            Wrapper<HtmlReportPage> htmlReport = new Wrapper<HtmlReportPage>();
            xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfASinglePassingScenario())
                .When(WebUser.ViewsReport(htmlReport))
                .Then("the report will show the test run name at the top", () => {
                    Assert.NotNull(htmlReport.Object.TestRunName);
                    Assert.Equal("My Test Run", htmlReport.Object.TestRunName.Text);
                })
                .And("the report will show the test run name as the title for the page", () => {
                    Assert.Equal("My Test Run", htmlReport.Object.Title);
                })
                .And("the report will show the test run name in green to indicate the test run passed", () => {
					outputWriter.WriteLine(htmlReport.Object.TestRunName.GetAttribute("class"));
                    Assert.True(htmlReport.Object.TestRunNameIsGreen());
                })
                .Run();
		}
		
		[ScenarioFact]
		[Trait("category", "today")]
		public void PassingWithSomeSkipped()
		{
			 xBDD.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
		
		[ScenarioFact]
		[Trait("category", "today")]
		public void Failing()
		{
			 xBDD.CurrentRun.AddScenario(this)
				.Skip("Not Started");
		}
	}
}