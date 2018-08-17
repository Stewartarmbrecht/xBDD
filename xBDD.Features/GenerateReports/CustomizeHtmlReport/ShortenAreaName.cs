namespace xBDD.Features.GenerateReports.CustomizeHtmlReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Threading.Tasks;
	using xBDD.Features.Actors;
	using xBDD.Features.Pages;

    [TestClass]
	[AsA("Developer")]
	[YouCan("shorten the area name in the Html report.")]
	[By("shorten the area name by removing the beginning of the name that matches a provided string")]
	public class ShortenAreaName: FeatureTestClass
	{
        private HtmlReportUser you = new HtmlReportUser();
        private HtmlReportPageModel the = new HtmlReportPageModel();
        
		[TestMethod]
		public async Task MatchesStartOfAreaName()
		{
            await xB.AddScenario(this, 1)
                .Given(you.GenerateAReportWithASinglePassingScenario(null,null,null,"My "))
                .When(you.NavigateTo(the.HtmlReport.WithASinglePassingScenario))
				.Then(you.WillSee(the.Area.Name(1)).IsVisible())
				.And(you.WillSee(the.Area.Name(1)).HasText("Area 1"))
                .Run();
		}
		[TestMethod]
		public async Task MatchesNoneOfAreaName()
		{
            await xB.AddScenario(this, 2)
                .Given(you.GenerateAReportWithASinglePassingScenario(null,null,null,"No Match"))
                .When(you.NavigateTo(the.HtmlReport.WithASinglePassingScenario))
				.Then(you.WillSee(the.Area.Name(1)).IsVisible())
				.And(you.WillSee(the.Area.Name(1)).HasText("My Area 1"))
                .Run();
		}
		[TestMethod]
		public async Task MatchesAllOfAreaName()
		{
            await xB.AddScenario(this, 3)
                .Given(you.GenerateAReportWithASinglePassingScenario(null,null,null,"My Area 1"))
                .When(you.NavigateTo(the.HtmlReport.WithASinglePassingScenario))
				.Then(you.WillSee(the.Area.Name(1)).IsVisible())
				.And(you.WillSee(the.Area.Name(1)).HasText("[Missing! (or Full Name Skipped)]"))
                .Run();
		}
	}
}