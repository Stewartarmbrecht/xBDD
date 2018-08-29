
namespace xBDD.Features.GenerateReports.BrowseHtmlReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Threading.Tasks;
	using xBDD.Features.Actors;
	using xBDD.Features.Pages;

    [TestClass]
	[AsA("Developer")]
	[YouCan("see the distribution of feature outcomes for an area")]
	[By("reviewing the distribution graph next to the area badge")]
	public class ReviewAreaFeatureDistribution: xBDDFeatureBase
	{
        private HtmlReportUser you = new HtmlReportUser();
	    private HtmlReportPageModel the = new HtmlReportPageModel();
		
		[TestMethod]
		public async Task FailedSkippedAndPassingFeatureStats()
		{
            await xB.AddScenario(this, 1)
                .When(you.NavigateTo(the.HtmlReport.FromAFailedTestRun))
				.And(you.WaitTill(the.Area.Badge(3)).IsVisible())
				.Then(you.WillSee(the.AreaFeatureDistro.BadgeDistro(3)).IsVisible())
				.And(you.WillSee(the.AreaFeatureDistro.BadgeDistro(3)).HasTitleAKAHoverText("Features"))
				.And(you.WillSee(the.AreaFeatureDistro.Chart(3)).IsVisible())
				.And(you.WillSee(the.AreaFeatureDistro.PassedBar(3)).Style("has a heigth of 33%", ".*height\\: 33\\.3.*\\%\\;.*"))
				.And(you.WillSee(the.AreaFeatureDistro.SkippedBar(3)).IsNotThere())
				.And(you.WillSee(the.AreaFeatureDistro.FailedBar(3)).Style("has a heigth of 33%", ".*height\\: 66\\.6.*\\%\\;.*"))
                .Run();
		}
		[TestMethod]
		public async Task AllPassingFeatureStats()
		{
            await xB.AddScenario(this, 1)
                .When(you.NavigateTo(the.HtmlReport.FromAPassingTestRun))
				.And(you.WaitTill(the.Area.Badge(1)).IsVisible())
				.Then(you.WillSee(the.AreaFeatureDistro.Chart(1)).IsVisible())
				.And(you.WillSee(the.AreaFeatureDistro.PassedBar(1)).Style("has a heigth of 100%", ".*height\\: 100\\%\\;.*"))
				.And(you.WillSee(the.AreaFeatureDistro.SkippedBar(1)).IsNotThere())
				.And(you.WillSee(the.AreaFeatureDistro.FailedBar(1)).IsNotThere())
                .Run();
		}
		[TestMethod]
		public async Task AllSkippedFeatureStats()
		{
            await xB.AddScenario(this, 1)
                .When(you.NavigateTo(the.HtmlReport.FromAFailedTestRun))
				.And(you.WaitTill(the.Area.Badge(6)).IsVisible())
				.Then(you.WillSee(the.AreaFeatureDistro.Chart(6)).IsVisible())
				.And(you.WillSee(the.AreaFeatureDistro.SkippedBar(6)).Style("has a heigth of 100%", ".*height\\: 100\\%\\;.*"))
				.And(you.WillSee(the.AreaFeatureDistro.PassedBar(6)).IsNotThere())
				.And(you.WillSee(the.AreaFeatureDistro.FailedBar(6)).IsNotThere())
                .Run();
		}
		[TestMethod]
		public async Task AllFailedFeatureStats()
		{
            await xB.AddScenario(this, 1)
                .When(you.NavigateTo(the.HtmlReport.FromATestRunWithOneFailingScenario))
				.And(you.WaitTill(the.Area.Badge(1)).IsVisible())
				.Then(you.WillSee(the.AreaFeatureDistro.Chart(1)).IsVisible())
				.And(you.WillSee(the.AreaFeatureDistro.FailedBar(1)).Style("has a heigth of 100%", ".*height\\: 100\\%\\;.*"))
				.And(you.WillSee(the.AreaFeatureDistro.PassedBar(1)).IsNotThere())
				.And(you.WillSee(the.AreaFeatureDistro.SkippedBar(1)).IsNotThere())
                .Run();
		}
	}
}