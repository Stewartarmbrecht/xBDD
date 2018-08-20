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
	public class ReviewTestRunStats: FeatureTestClass
	{
        private HtmlReportUser you = new HtmlReportUser();
        private HtmlReportPageModel the = new HtmlReportPageModel();

		[TestMethod]
		public async Task FailedSkippedAndPassingAreaStats()
		{
            await xB.CurrentRun.AddScenario(this, 1)
				.When(you.NavigateTo(the.HtmlReport.FromAFailedTestRun))
				.Then(you.WillSee(the.TestRunAreaStats.Section).IsVisible())
				.And(you.WillSee(the.TestRunAreaStats.Total).HasText("9"))
				.And(you.WillSee(the.TestRunAreaStats.Total).HasTitleAKAHoverText("Areas"))
				.And(you.WillSee(the.TestRunAreaStats.Passed).HasText("2"))
				.And(you.WillSee(the.TestRunAreaStats.Skipped).HasText("3"))
				.And(you.WillSee(the.TestRunAreaStats.Failed).HasText("4"))
				.And(you.WillSee(the.TestRunAreaStats.BarChart).IsVisible())
				.And(you.WillSee(the.TestRunAreaStats.SuccessBar).Style("has a width of 22.2%", ".*width: 22\\.2.*"))
				.And(you.WillSee(the.TestRunAreaStats.SkippedBar).Style("has a width of 33.3%", ".*width: 33\\.3.*"))
				.And(you.WillSee(the.TestRunAreaStats.FailedBar).Style("has a width of 44.4%", ".*width: 44\\.4.*"))
                .Run();
		}
		[TestMethod]
		public async Task FailedSkippedAndPassingFeatureStats()
		{
            await xB.CurrentRun.AddScenario(this, 2)
				.When(you.NavigateTo(the.HtmlReport.FromAFailedTestRun))
				.Then(you.WillSee(the.TestRunFeatureStats.Section).IsVisible())
				.And(you.WillSee(the.TestRunFeatureStats.Passed).HasText("10"))
				.And(you.WillSee(the.TestRunFeatureStats.Skipped).HasText("5"))
				.And(you.WillSee(the.TestRunFeatureStats.Failed).HasText("4"))
				.And(you.WillSee(the.TestRunFeatureStats.BarChart).IsVisible())
				.And(you.WillSee(the.TestRunFeatureStats.SuccessBar).Style("has a width of 52.6%", ".*width: 52\\.6.*"))
				.And(you.WillSee(the.TestRunFeatureStats.SkippedBar).Style("has a width of 26.3%", ".*width: 26\\.3.*"))
				.And(you.WillSee(the.TestRunFeatureStats.FailedBar).Style("has a width of 21.0%", ".*width: 21\\.0.*"))
                .Run();
		}
		[TestMethod]
		public async Task FailedSkippedAndPassingScenarioStats()
		{
            await xB.CurrentRun.AddScenario(this, 3)
				.When(you.NavigateTo(the.HtmlReport.FromAFailedTestRun))
				.Then(you.WillSee(the.TestRunScenarioStats.Section).IsVisible())
				.And(you.WillSee(the.TestRunScenarioStats.Passed).HasText("32"))
				.And(you.WillSee(the.TestRunScenarioStats.Skipped).HasText("8"))
				.And(you.WillSee(the.TestRunScenarioStats.Failed).HasText("5"))
				.And(you.WillSee(the.TestRunScenarioStats.BarChart).IsVisible())
				.And(you.WillSee(the.TestRunScenarioStats.SuccessBar).Style("has a width of 71.1%", ".*width: 71\\.1.*"))
				.And(you.WillSee(the.TestRunScenarioStats.SkippedBar).Style("has a width of 17.7%", ".*width: 17\\.7.*"))
				.And(you.WillSee(the.TestRunScenarioStats.FailedBar).Style("has a width of 11.1%", ".*width: 11\\.1.*"))
                .Run();
		}
		[TestMethod]
		public async Task AreaStatsNoAreas()
		{
            await xB.CurrentRun.AddScenario(this, 4)
				.When(you.NavigateTo(the.HtmlReport.FromATestRunWithNoScenarios))
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