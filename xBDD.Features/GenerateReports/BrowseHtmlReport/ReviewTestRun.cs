namespace xBDD.Features.GenerateReports.BrowseHtmlReport
{
	using xBDD.Features;
	using xBDD.Browser;
	using xBDD.Features.Pages.HtmlReportPage;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using xBDD.Features.Steps;
	using System.Threading.Tasks;

    [TestClass]
	public class ReviewTestRun
	{
        private User you = new User();
        private HtmlReport the = new Pages.HtmlReportPage.HtmlReport();
        private ReportLocations theHtmlReport = new Pages.HtmlReportPage.ReportLocations();

		private readonly TestContextWriter outputWriter;

		public ReviewTestRun()
		{
			outputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		public async Task EmptyTestRun()
		{
            await xB.AddScenario(this, 1)
                .Given(AnHtmlReport.WithAnEmptyTestRun())
                .When(you.NavigateTo(theHtmlReport.WithAnEmptyTestRun))
                .Then(you.WillSee(the.TestRun.Name).IsVisible())
                .And(you.WillSee(the.TestRun.Name).HasText("My Test Run"))
                .And(you.AreViewingAPageWithTheTitle("My Test Run"))
                .And(you.WillSee(the.TestRun.BadgeGrey).IsVisible().Because("no scenarios were run"))
                .Run();
		}
		
		[TestMethod]
		public async Task PassingTestRun()
		{
            await xB.AddScenario(this, 2)
                .Given(AnHtmlReport.WithASinglePassingScenario())
                .When(you.NavigateTo(theHtmlReport.WithASinglePassingScenario))
                .Then(you.WillSee(the.TestRun.BadgeGreen).IsVisible())
				.And(you.WillSee(the.TestRun.Duration).IsVisible())
                .Run();
		}
		
		[TestMethod]
		public async Task PassingWithSomeSkipped()
		{
            await xB.AddScenario(this, 3)
                .Given(AnHtmlReport.WithASingleSkippedScenario())
                .When(you.NavigateTo(theHtmlReport.WithASingleSkippedScenario))
                .Then(you.WillSee(the.TestRun.BadgeYellow).IsVisible())
                .Run();
		}
		
		[TestMethod]
		public async Task Failing()
		{
            await xB.AddScenario(this, 4)
                .Given(AnHtmlReport.WithASingleFailedScenario())
                .When(you.NavigateTo(theHtmlReport.WithASingleFailedScenario))
                .Then(you.WillSee(the.TestRun.BadgeRed).IsVisible())
                .Run();
		}
	}
}