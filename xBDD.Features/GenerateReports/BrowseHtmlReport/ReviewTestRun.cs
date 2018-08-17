namespace xBDD.Features.GenerateReports.BrowseHtmlReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Threading.Tasks;
	using xBDD.Features.Actors;
	using xBDD.Features.Pages;

    [TestClass]
	public class ReviewTestRun: FeatureTestClass
	{
        private HtmlReportUser you = new HtmlReportUser();
        private HtmlReportPageModel the = new HtmlReportPageModel();

		[TestMethod]
		public async Task EmptyTestRun()
		{
            await xB.AddScenario(this, 1)
                .Given(you.GenerateAReportWithAnEmptyTestRun())
                .When(you.NavigateTo(the.HtmlReport.WithAnEmptyTestRun))
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
                .Given(you.GenerateAReportWithASinglePassingScenario())
                .When(you.NavigateTo(the.HtmlReport.WithASinglePassingScenario))
                .Then(you.WillSee(the.TestRun.BadgeGreen).IsVisible())
				.And(you.WillSee(the.TestRun.Duration).IsVisible())
                .Run();
		}
		
		[TestMethod]
		public async Task PassingWithSomeSkipped()
		{
            await xB.AddScenario(this, 3)
                .Given(you.GenerateAReportWithASingleSkippedScenario())
                .When(you.NavigateTo(the.HtmlReport.WithASingleSkippedScenario))
                .Then(you.WillSee(the.TestRun.BadgeYellow).IsVisible())
                .Run();
		}
		
		[TestMethod]
		public async Task Failing()
		{
            await xB.AddScenario(this, 4)
                .Given(you.GenerateAReportWithASingleFailedScenario())
                .When(you.NavigateTo(the.HtmlReport.WithASingleFailedScenario))
                .Then(you.WillSee(the.TestRun.BadgeRed).IsVisible())
                .Run();
		}
	}
}