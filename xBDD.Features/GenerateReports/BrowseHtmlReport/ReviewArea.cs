namespace xBDD.Features.GenerateReports.BrowseHtmlReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Threading.Tasks;
	using xBDD.Features.Actors;
	using xBDD.Features.Pages;

    [TestClass]
	public class ReviewArea
	{
		private readonly TestContextWriter outputWriter;

        private HtmlReportUser you = new HtmlReportUser();
        private HtmlReportPageModel the = new HtmlReportPageModel();

		public ReviewArea()
		{
			outputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		public async Task Passing()
		{
            await xB.AddScenario(this, 1)
                .Given(you.GenerateAReportWithASinglePassingScenario())
                .When(you.NavigateTo(the.HtmlReport.WithASinglePassingScenario))
				.Then(you.WillSee(the.Area.Name(1)).HasText("My Area 1"))
				.And(you.WillSee(the.Area.BadgeGreen(1)).IsVisible())
				.And(you.WillSee(the.Area.Duration(1)).IsVisible())
                .Run();
		}
		[TestMethod]
		public async Task Skipped()
		{
            await xB.AddScenario(this, 2)
                .Given(you.GenerateAReportWithASingleSkippedScenario())
                .When(you.NavigateTo(the.HtmlReport.WithASingleSkippedScenario))
				.Then(you.WillSee(the.Area.Name(1)).HasText("My Area 1"))
				.And(you.WillSee(the.Area.BadgeYellow(1)).IsVisible())
                .Run();
		}
		[TestMethod]
		public async Task Failing()
		{
            await xB.AddScenario(this, 3)
                .Given(you.GenerateAReportWithASingleFailedScenario())
                .When(you.NavigateTo(the.HtmlReport.WithASingleFailedScenario))
				.Then(you.WillSee(the.Area.Name(1)).HasText("My Area 1"))
				.And(you.WillSee(the.Area.BadgeRed(1)).IsVisible())
                .Run();
		}
	}
}