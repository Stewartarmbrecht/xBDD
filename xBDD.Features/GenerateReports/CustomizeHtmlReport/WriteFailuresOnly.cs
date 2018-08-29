namespace xBDD.Features.GenerateReports.CustomizeHtmlReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Threading.Tasks;
	using xBDD.Features.Actors;
	using xBDD.Features.Pages;

	[TestClass]
    [AsA("Developer")]
    [YouCan("set the html report to only report on failures")]
    [By("passing the report writer a true value for the failuresOnly parameter.")]
	public class WriteFailuresOnly: xBDDFeatureBase
	{
        private HtmlReportUser you = new HtmlReportUser();
        private HtmlReportPageModel the = new HtmlReportPageModel();
        
		[TestMethod]
		public async Task Passing()
		{
            await xB.AddScenario(this, 1)
                .When(you.NavigateTo(the.HtmlReport.FromAPassingTestRunWithFailuresOnly))
				.Then(you.WillSee(the.TestRun.Areas).IsNotThere())
                .Run();
		}
		[TestMethod]
		public async Task Skipped()
		{
            await xB.AddScenario(this, 2)
                .When(you.NavigateTo(the.HtmlReport.FromASkippedTestRunWithFailuresOnly))
				.Then(you.WillSee(the.TestRun.Areas).IsNotThere())
                .Run();
		}
		[TestMethod]
		public async Task Failing()
		{
            await xB.AddScenario(this, 3)
                .When(you.NavigateTo(the.HtmlReport.FromAFailedTestRunWithFailuresOnly))
				.Then(you.WillSee(the.Step.BadgeRed(2)).IsVisible().Because("the step failed and the report will be expanded to the failed step"))
                .Run();
		}
	}
}