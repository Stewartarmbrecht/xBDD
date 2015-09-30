using Xunit;
using Xunit.Abstractions;
using xBDD.xUnit;
using xBDD.Reporting.Test.Pages;
using xBDD.Reporting.Test.Steps;

namespace xBDD.Reporting.Test.Features.WriteResults
{
    [Collection("xBDDReportingTest")]
    public class BrowseHtmlReport
    {
        private readonly OutputWriter outputWriter;

        public BrowseHtmlReport(ITestOutputHelper output)
        {
            outputWriter = new OutputWriter(output);
        }

        [ScenarioFact]
        [Trait("category", "current")]
        public void ViewEmptyTestRun()
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
                .Run();
        }
        [ScenarioFact]
        [Trait("category", "current")]
        public void ViewRunScenario()
        {
            Wrapper<HtmlReportPage> htmlReport = new Wrapper<HtmlReportPage>();
            xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfASinglePassingScenario())
                .When(WebUser.ViewsReport(htmlReport))
                .Then("the area path will be displayed")
                .And("the feature name will be displayed indented under the area path")
                .And("the scenario name will be displayed indented under the feature name")
                .And("the steps will be displayed indented, under the scenario")
                .Skip("Not Started");
        }
        [ScenarioFact]
        [Trait("category", "current")]
        public void ViewRunStepWithMultilineParameterOfText()
        {
            Wrapper<HtmlReportPage> htmlReport = new Wrapper<HtmlReportPage>();
            xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfASinglePassingScenario())
                .When(WebUser.ViewsReport(htmlReport))
                .Then("the steps multiline parameter will show indented under the step name")
                .And("the multline parameter will have line breaks and indentation preserved")
                .Skip("Not Started");
        }
        [ScenarioFact]
        [Trait("category", "current")]
        public void ViewPassingScenario()
        {
            Wrapper<HtmlReportPage> htmlReport = new Wrapper<HtmlReportPage>();
            xBDD.CurrentRun.AddScenario(this)
                .Given(HtmlReport.OfASinglePassingScenario())
                .When(WebUser.ViewsReport(htmlReport))
                .Then("the area path will be green")
                .And("the feature name will be green")
                .And("the scenario name will be green")
                .And("the step names will be green")
                .Skip("Not Started");
        }
    }
}
