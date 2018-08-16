
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
	public class ReviewAreaFeatureDistribution
	{
        private HtmlReportUser you = new HtmlReportUser();
	    private HtmlReportPageModel the = new HtmlReportPageModel();
        

		private readonly TestContextWriter outputWriter;

		public ReviewAreaFeatureDistribution()
		{
			outputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		public async Task FailedSkippedAndPassingFeatureStats()
		{
            await xB.AddScenario(this, 1)
                .Given(you.GenerateAReportWithAFullTestRunWithAllOutcomes())
				.When(you.NavigateTo(the.HtmlReport.WithAFullTestRunWithAllOutcomes))
				.And(you.WaitTill(the.Area.Badge(3)).IsVisible())
				.Then(you.WillSee(the.AreaFeatureDistro.BadgeDistro(3)).IsVisible())
				.And(you.WillSee(the.AreaFeatureDistro.BadgeDistro(3)).HasTitleAKAHoverText("Features"))
				.And(you.WillSee(the.AreaFeatureDistro.Chart(3)).IsVisible())
				.And(you.WillSee(the.AreaFeatureDistro.PassedBar(3)).Style("has a heigth of 33%", ".*height\\: 33\\..*\\%\\;.*"))
				.And(you.WillSee(the.AreaFeatureDistro.SkippedBar(3)).Style("has a heigth of 33%", ".*height\\: 33\\..*\\%\\;.*"))
				.And(you.WillSee(the.AreaFeatureDistro.FailedBar(3)).Style("has a heigth of 33%", ".*height\\: 33\\..*\\%\\;.*"))
                .Run();
		}
		[TestMethod]
		public async Task AllPassingFeatureStats()
		{
            await xB.AddScenario(this, 1)
                .Given(you.GenerateAReportWithAPassingFullTestRun())
				.When(you.NavigateTo(the.HtmlReport.WithAPassingFullTestRun))
				.And(you.WaitTill(the.Area.Badge(1)).IsVisible())
				.Then(you.WillSee(the.AreaFeatureDistro.Chart(1)).IsVisible())
				.And(you.WillSee(the.AreaFeatureDistro.PassedBar(1)).Style("has a heigth of 33%", ".*height\\: 100\\%\\;.*"))
				.And(you.WillSee(the.AreaFeatureDistro.SkippedBar(1)).IsNotThere())
				.And(you.WillSee(the.AreaFeatureDistro.FailedBar(1)).IsNotThere())
                .Run();
		}
		[TestMethod]
		public async Task AllSkippedFeatureStats()
		{
            await xB.AddScenario(this, 1)
                .Given(you.GenerateAReportWithASingleSkippedScenario())
				.When(you.NavigateTo(the.HtmlReport.WithASingleSkippedScenario))
				.And(you.WaitTill(the.Area.Badge(1)).IsVisible())
				.Then(you.WillSee(the.AreaFeatureDistro.Chart(1)).IsVisible())
				.And(you.WillSee(the.AreaFeatureDistro.SkippedBar(1)).Style("has a heigth of 33%", ".*height\\: 100\\%\\;.*"))
				.And(you.WillSee(the.AreaFeatureDistro.PassedBar(1)).IsNotThere())
				.And(you.WillSee(the.AreaFeatureDistro.FailedBar(1)).IsNotThere())
                .Run();
		}
		[TestMethod]
		public async Task AllFailedFeatureStats()
		{
            await xB.AddScenario(this, 1)
                .Given(you.GenerateAReportWithASingleFailedScenario())
				.When(you.NavigateTo(the.HtmlReport.WithASingleFailedScenario))
				.And(you.WaitTill(the.Area.Badge(1)).IsVisible())
				.Then(you.WillSee(the.AreaFeatureDistro.Chart(1)).IsVisible())
				.And(you.WillSee(the.AreaFeatureDistro.FailedBar(1)).Style("has a heigth of 33%", ".*height\\: 100\\%\\;.*"))
				.And(you.WillSee(the.AreaFeatureDistro.PassedBar(1)).IsNotThere())
				.And(you.WillSee(the.AreaFeatureDistro.SkippedBar(1)).IsNotThere())
                .Run();
		}
	}
}