namespace xBDD.Features.GenerateReports.CustomizeHtmlReport
{
	using xBDD.Features;
	using xBDD.Browser;
	using xBDD.Features.Pages.HtmlReportPage;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using xBDD.Features.Steps;
	using System.Threading.Tasks;

	[TestClass]
    [AsA("Developer")]
    [YouCan("set the html report to only report on failures")]
    [By("passing the report writer a true value for the failuresOnly parameter.")]
	public class WriteFailuresOnly
	{
        private User you = new User();
        private HtmlReport the = new Pages.HtmlReportPage.HtmlReport();
        private ReportLocations theHtmlReport = new Pages.HtmlReportPage.ReportLocations();

		private readonly TestContextWriter outputWriter;

		public WriteFailuresOnly()
		{
			outputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		public async Task Passing()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.AddScenario(this, 1)
                .Given(AnHtmlReport.WithASinglePassingScenario(null, null, null, null, true))
                .When(you.NavigateTo(theHtmlReport.WithASinglePassingScenario))
				.Then(you.WillSee(the.TestRun.Areas).IsNotThere())
                .Run();
		}
		[TestMethod]
		public async Task Skipped()
		{
            await xB.AddScenario(this, 2)
                .Given(AnHtmlReport.WithASingleSkippedScenario(true))
                .When(you.NavigateTo(theHtmlReport.WithASingleSkippedScenario))
				.Then(you.WillSee(the.TestRun.Areas).IsNotThere())
                .Run();
		}
		[TestMethod]
		public async Task Failing()
		{
            await xB.AddScenario(this, 3)
                .Given(AnHtmlReport.WithAFullTestRunWithAllOutcomes(true))
                .When(you.NavigateTo(theHtmlReport.WithASingleFailedScenario))
				.Then(you.WillSee(the.Step.BadgeRed(2)).IsVisible().Because("the step failed and the report will be expanded to the failed step"))
                .Run();
		}
	}
}