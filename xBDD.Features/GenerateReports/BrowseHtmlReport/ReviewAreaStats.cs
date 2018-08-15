namespace xBDD.Features.GenerateReports.BrowseHtmlReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Threading.Tasks;
	using xBDD.Features.Actors;
	using xBDD.Features.Pages;

    [TestClass]
	//  [Description("In order to understand how functionality is organized")]
	//  [Description("As a report reviewer")]
	//  [Description("I would like to view the areas in the html report")]
	public class ReviewAreaStats
	{
        private HtmlReportUser you = new HtmlReportUser();
        private HtmlReportPageModel the = new HtmlReportPageModel();
        

		private readonly TestContextWriter outputWriter;

		public ReviewAreaStats()
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
				.And(you.Click(the.Area.Badge(3)))
				.Then(you.WillSee(the.AreaFeatureStats.Section(3)).IsVisible())
				.And(you.WillSee(the.AreaFeatureStats.Total(3)).HasText("3"))
				.And(you.WillSee(the.AreaFeatureStats.Passed(3)).HasText("1"))
				.And(you.WillSee(the.AreaFeatureStats.Skipped(3)).HasText("1"))
				.And(you.WillSee(the.AreaFeatureStats.Failed(3)).HasText("1"))
				.And(you.WillSee(the.AreaFeatureStats.BarChart(3)).IsVisible())
				.And(you.WillSee(the.AreaFeatureStats.SuccessBar(3)).Style("has a width of 33%",".*width: 33\\..*"))
				.And(you.WillSee(the.AreaFeatureStats.SkippedBar(3)).Style("has a width of 33%",".*width: 33\\..*"))
				.And(you.WillSee(the.AreaFeatureStats.FailedBar(3)).Style("has a width of 33%",".*width: 33\\..*"))
                .Run();
		}
		[TestMethod]
		public async Task FailedSkippedAndPassingScenarioStats()
		{
            await xB.CurrentRun.AddScenario(this, 2)
                .Given(you.GenerateAReportWithAFullTestRunWithAllOutcomes())
 				.When(you.NavigateTo(the.HtmlReport.WithAFullTestRunWithAllOutcomes))
				.And(you.WaitTill(the.Area.Badge(3)).IsVisible())
				.And(you.Click(the.Area.Badge(3)))
				.Then(you.WillSee(the.AreaScenarioStats.Section(3)).IsVisible())
				.And(you.WillSee(the.AreaScenarioStats.Passed(3)).HasText("5"))
				.And(you.WillSee(the.AreaScenarioStats.Skipped(3)).HasText("3"))
				.And(you.WillSee(the.AreaScenarioStats.Failed(3)).HasText("1"))
				.And(you.WillSee(the.AreaScenarioStats.BarChart(3)).IsVisible())
				.And(you.WillSee(the.AreaScenarioStats.SuccessBar(3)).Style("has a width of 55%", ".*width: 55\\..*"))
				.And(you.WillSee(the.AreaScenarioStats.SkippedBar(3)).Style("has a width of 33%", ".*width: 33\\..*"))
				.And(you.WillSee(the.AreaScenarioStats.FailedBar(3)).Style("has a width of 11%", ".*width: 11\\..*"))
                .Run();
		}
	}
}