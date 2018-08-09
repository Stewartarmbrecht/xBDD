namespace xBDD.Features.GenerateReports.BrowseHtmlReport
{
	using xBDD.Features;
	using xBDD.Browser;
	using xBDD.Features.Pages.HtmlReportPage;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using xBDD.Features.Steps;
	using System.Threading.Tasks;

    [TestClass]
	//  [Description("In order to understand how functionality is organized")]
	//  [Description("As a report reviewer")]
	//  [Description("I would like to view the areas in the html report")]
	public class ReviewTestRunStats
	{
        private User you = new User();
        private HtmlReport the = new Pages.HtmlReportPage.HtmlReport();
        private ReportLocations theHtmlReport = new Pages.HtmlReportPage.ReportLocations();

		private readonly TestContextWriter outputWriter;

		public ReviewTestRunStats()
		{
			outputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		public async Task FailedSkippedAndPassingAreaStats()
		{
            await xB.CurrentRun.AddScenario(this)
                .Given(AnHtmlReport.WithAFullTestRunWithAllOutcomes())
				.When(you.NavigateTo(theHtmlReport.WithAFullTestRunWithAllOutcomes))
				.Then(you.WillSee(the.TestRunAreaStats.Section).IsVisible())
				.And(you.WillSee(the.TestRunAreaStats.Total).HasText("3"))
				.And(you.WillSee(the.TestRunAreaStats.Total).HasTitleAKAHoverText("Areas"))
				.And(you.WillSee(the.TestRunAreaStats.Passed).HasText("1"))
				.And(you.WillSee(the.TestRunAreaStats.Skipped).HasText("1"))
				.And(you.WillSee(the.TestRunAreaStats.Failed).HasText("1"))
				.And(you.WillSee(the.TestRunAreaStats.BarChart).IsVisible())
				.And(you.WillSee(the.TestRunAreaStats.SuccessBar).Style("has a width of 33%", ".*width: 33\\..*"))
				.And(you.WillSee(the.TestRunAreaStats.SkippedBar).Style("has a width of 33%", ".*width: 33\\..*"))
				.And(you.WillSee(the.TestRunAreaStats.FailedBar).Style("has a width of 33%", ".*width: 33\\..*"))
                .Run();
		}
		[TestMethod]
		public async Task FailedSkippedAndPassingFeatureStats()
		{
            await xB.CurrentRun.AddScenario(this)
                .Given(AnHtmlReport.WithAFullTestRunWithAllOutcomes())
				.When(you.NavigateTo(theHtmlReport.WithAFullTestRunWithAllOutcomes))
				.Then(you.WillSee(the.TestRunFeatureStats.Section).IsVisible())
				.And(you.WillSee(the.TestRunFeatureStats.Passed).HasText("5"))
				.And(you.WillSee(the.TestRunFeatureStats.Skipped).HasText("3"))
				.And(you.WillSee(the.TestRunFeatureStats.Failed).HasText("1"))
				.And(you.WillSee(the.TestRunFeatureStats.BarChart).IsVisible())
				.And(you.WillSee(the.TestRunFeatureStats.SuccessBar).Style("has a width of 55%", ".*width: 55\\..*"))
				.And(you.WillSee(the.TestRunFeatureStats.SkippedBar).Style("has a width of 33%", ".*width: 33\\..*"))
				.And(you.WillSee(the.TestRunFeatureStats.FailedBar).Style("has a width of 11%", ".*width: 11\\..*"))
                .Run();
		}
		[TestMethod]
		public async Task FailedSkippedAndPassingScenarioStats()
		{
            await xB.CurrentRun.AddScenario(this)
                .Given(AnHtmlReport.WithAFullTestRunWithAllOutcomes())
				.When(you.NavigateTo(theHtmlReport.WithAFullTestRunWithAllOutcomes))
				.Then(you.WillSee(the.TestRunScenarioStats.Section).IsVisible())
				.And(you.WillSee(the.TestRunScenarioStats.Passed).HasText("19"))
				.And(you.WillSee(the.TestRunScenarioStats.Skipped).HasText("7"))
				.And(you.WillSee(the.TestRunScenarioStats.Failed).HasText("1"))
				.And(you.WillSee(the.TestRunScenarioStats.BarChart).IsVisible())
				.And(you.WillSee(the.TestRunScenarioStats.SuccessBar).Style("has a width of 70%", ".*width: 70\\..*"))
				.And(you.WillSee(the.TestRunScenarioStats.SkippedBar).Style("has a width of 26%", ".*width: 25\\.9.*"))
				.And(you.WillSee(the.TestRunScenarioStats.FailedBar).Style("has a width of 4%", ".*width: 3\\.7.*"))
                .Run();
		}
		[TestMethod]
		public async Task AreaStatsNoAreas()
		{
            await xB.CurrentRun.AddScenario(this)
                .Given(AnHtmlReport.WithAnEmptyTestRun())
				.When(you.NavigateTo(theHtmlReport.WithAnEmptyTestRun))
				.Then(you.WillSee(the.TestRunAreaStats.Section).IsVisible())
				.And(you.WillSee(the.TestRunAreaStats.Total).HasText("0"))
				.And(you.WillSee(the.TestRunAreaStats.Total).HasTitleAKAHoverText("Areas"))
				.And(you.WillSee(the.TestRunAreaStats.Passed).HasText("0"))
				.And(you.WillSee(the.TestRunAreaStats.Skipped).HasText("0"))
				.And(you.WillSee(the.TestRunAreaStats.Failed).HasText("0"))
				.And(you.WillSee(the.TestRunAreaStats.EmptyBar).IsVisible())
                .Run();
		}
	}
}