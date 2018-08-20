
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
	public class ReviewFeatureScenarioDistribution: FeatureTestClass
	{
        private HtmlReportUser you = new HtmlReportUser();
        private HtmlReportPageModel the = new HtmlReportPageModel();
        		
		[TestMethod]
		public async Task FailedSkippedAndPassingScenarioStats()
		{
            await xB.AddScenario(this, 1)
				.When(you.NavigateTo(the.HtmlReport.FromAFailedTestRun))
				.And(you.ClickWhen(the.Area.Name(3)).IsVisible())
				.Then(you.WillSee(the.FeatureScenarioDistro.BadgeDistro(9)).IsVisible())
				.And(you.WillSee(the.FeatureScenarioDistro.BadgeDistro(9)).HasTitleAKAHoverText("Scenarios"))
				.And(you.WillSee(the.FeatureScenarioDistro.Chart(9)).IsVisible())
				.And(you.WillSee(the.FeatureScenarioDistro.PassedBar(9)).Style("has a heigth of 33%", ".*height\\: 33\\..*\\%\\;.*"))
				.And(you.WillSee(the.FeatureScenarioDistro.SkippedBar(9)).Style("has a heigth of 33%", ".*height\\: 33\\..*\\%\\;.*"))
				.And(you.WillSee(the.FeatureScenarioDistro.FailedBar(9)).Style("has a heigth of 33%", ".*height\\: 33\\..*\\%\\;.*"))
                .Run();
		}
		[TestMethod]
		public async Task AllPassingScenarioStats()
		{
            await xB.AddScenario(this, 2)
				.When(you.NavigateTo(the.HtmlReport.FromAFailedTestRun))
				.And(you.WaitTill(the.Area.Badge(1)).IsVisible())
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.Then(you.WillSee(the.FeatureScenarioDistro.Chart(1)).IsVisible())
				.And(you.WillSee(the.FeatureScenarioDistro.PassedBar(1)).Style("has a heigth of 100%", ".*height\\: 100\\%\\;.*"))
				.And(you.WillSee(the.FeatureScenarioDistro.SkippedBar(1)).IsNotThere())
				.And(you.WillSee(the.FeatureScenarioDistro.FailedBar(1)).IsNotThere())
                .Run();
		}
		[TestMethod]
		public async Task AllSkippedScenarioStats()
		{
            await xB.AddScenario(this, 3)
				.When(you.NavigateTo(the.HtmlReport.FromAFailedTestRun))
				.And(you.WaitTill(the.Area.Badge(6)).IsVisible())
				.And(you.ClickWhen(the.Area.Name(6)).IsVisible())
				.Then(you.WillSee(the.FeatureScenarioDistro.Chart(15)).IsVisible())
				.And(you.WillSee(the.FeatureScenarioDistro.SkippedBar(15)).Style("has a heigth of 100%", ".*height\\: 100\\%\\;.*"))
				.And(you.WillSee(the.FeatureScenarioDistro.PassedBar(15)).IsNotThere())
				.And(you.WillSee(the.FeatureScenarioDistro.FailedBar(15)).IsNotThere())
                .Run();
		}
		[TestMethod]
		public async Task AllFailedScenarioStats()
		{
            await xB.AddScenario(this, 4)
				.When(you.NavigateTo(the.HtmlReport.FromAFailedTestRun))
				.And(you.ClickWhen(the.Area.Name(7)).IsVisible())
				.Then(you.WillSee(the.FeatureScenarioDistro.Chart(16)).IsVisible())
				.And(you.WillSee(the.FeatureScenarioDistro.FailedBar(16)).Style("has a heigth of 100%", ".*height\\: 100\\%\\;.*"))
				.And(you.WillSee(the.FeatureScenarioDistro.PassedBar(16)).IsNotThere())
				.And(you.WillSee(the.FeatureScenarioDistro.SkippedBar(16)).IsNotThere())
                .Run();
		}
	}
}