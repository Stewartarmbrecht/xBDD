namespace xBDD.Reporting.Features.BrowseHtmlReport
{
	using xBDD.Test;
	using xBDD.Browser;
	using xBDD.Reporting.Features.Pages.HtmlReportPage;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using xBDD.Reporting.Features.Steps;
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
            await xB.AddScenario(this)
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
            await xB.AddScenario(this)
                .Given(AnHtmlReport.WithASinglePassingScenario())
                .When(you.NavigateTo(theHtmlReport.WithASinglePassingScenario))
                .Then(you.WillSee(the.TestRun.BadgeGreen).IsVisible())
                .Run();
		}
		
		[TestMethod]
		public async Task PassingWithSomeSkipped()
		{
            await xB.AddScenario(this)
                .Given(AnHtmlReport.WithASingleSkippedScenario())
                .When(you.NavigateTo(theHtmlReport.WithASingleSkippedScenario))
                .Then(you.WillSee(the.TestRun.BadgeYellow).IsVisible())
                .Run();
		}
		
		[TestMethod]
		public async Task Failing()
		{
            await xB.AddScenario(this)
                .Given(AnHtmlReport.WithASingleFailedScenario())
                .When(you.NavigateTo(theHtmlReport.WithASingleFailedScenario))
                .Then(you.WillSee(the.TestRun.BadgeRed).IsVisible())
                .Run();
		}
	}
}