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
	public class WriteFailuresOnly
	{
        private HtmlReportUser you = new HtmlReportUser();
        private HtmlReportPageModel the = new HtmlReportPageModel();
        

		private readonly TestContextWriter outputWriter;

		public WriteFailuresOnly()
		{
			outputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		public async Task Passing()
		{
            await xB.AddScenario(this, 1)
                .Given(you.GenerateAReportWithASinglePassingScenario(null, null, null, null, true))
                .When(you.NavigateTo(the.HtmlReport.WithASinglePassingScenario))
				.Then(you.WillSee(the.TestRun.Areas).IsNotThere())
                .Run();
		}
		[TestMethod]
		public async Task Skipped()
		{
            await xB.AddScenario(this, 2)
                .Given(you.GenerateAReportWithASingleSkippedScenario(true))
                .When(you.NavigateTo(the.HtmlReport.WithASingleSkippedScenario))
				.Then(you.WillSee(the.TestRun.Areas).IsNotThere())
                .Run();
		}
		[TestMethod]
		public async Task Failing()
		{
            await xB.AddScenario(this, 3)
                .Given(you.GenerateAReportWithAFullTestRunWithAllOutcomes(true))
                .When(you.NavigateTo(the.HtmlReport.WithAFullTestRunWithAllOutcomes))
				.Then(you.WillSee(the.Step.BadgeRed(2)).IsVisible().Because("the step failed and the report will be expanded to the failed step"))
                .Run();
		}
	}
}