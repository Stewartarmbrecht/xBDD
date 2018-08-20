namespace xBDD.Features.GenerateReports.BrowseHtmlReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Threading.Tasks;
	using xBDD.Features.Actors;
	using xBDD.Features.Pages;

    [TestClass]
	public class ReviewArea: FeatureTestClass
	{
        private HtmlReportUser you = new HtmlReportUser();
        private HtmlReportPageModel the = new HtmlReportPageModel();

		[TestMethod]
		public async Task Passing()
		{
            await xB.AddScenario(this, 1)
                .When(you.NavigateTo(the.HtmlReport.FromAPassingTestRun))
				.Then(you.WillSee(the.Area.Name(1)).HasText("My Area 1 All Passing"))
				.And(you.WillSee(the.Area.BadgeGreen(1)).IsVisible())
				.And(you.WillSee(the.Area.Duration(1)).IsVisible())
                .Run();
		}
		[TestMethod]
		public async Task Skipped()
		{
            await xB.AddScenario(this, 2)
                .When(you.NavigateTo(the.HtmlReport.FromASkippedTestRun))
				.Then(you.WillSee(the.Area.Name(1)).HasText("My Area 2 Some Skipped"))
				.And(you.WillSee(the.Area.BadgeYellow(1)).IsVisible())
                .Run();
		}
		[TestMethod]
		public async Task Failing()
		{
            await xB.AddScenario(this, 3)
                .When(you.NavigateTo(the.HtmlReport.FromAFailedTestRun))
				.Then(you.WillSee(the.Area.Name(3)).HasText("My Area 3 Some Failed"))
				.And(you.WillSee(the.Area.BadgeRed(3)).IsVisible())
                .Run();
		}
	}
}