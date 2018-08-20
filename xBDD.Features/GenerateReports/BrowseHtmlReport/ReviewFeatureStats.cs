namespace xBDD.Features.GenerateReports.BrowseHtmlReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Threading.Tasks;
	using xBDD.Features.Actors;
	using xBDD.Features.Pages;

    [TestClass]
	//  [Description("In order to understand how functionality is organized")]
	//  [Description("As a report reviewer")]
	//  [Description("I would like to view the features in the html report")]
	public class ReviewFeatureStats: FeatureTestClass
	{
        private HtmlReportUser you = new HtmlReportUser();
        private HtmlReportPageModel the = new HtmlReportPageModel();
		
		[TestMethod]
		public async Task FailedSkippedAndPassingScenarioStats()
		{
            await xB.CurrentRun.AddScenario(this, 1)
				.When(you.NavigateTo(the.HtmlReport.FromAFailedTestRun))
				.And(you.ClickWhen(the.Area.Name(3)).IsVisible())
				.And(you.ClickWhen(the.Feature.Badge(8)).IsVisible())
				.Then(you.WillSee(the.FeatureScenarioStats.Section(8)).IsVisible())
				.And(you.WillSee(the.FeatureScenarioStats.Total(8)).IsVisible())
				.And(you.WillSee(the.FeatureScenarioStats.Total(8)).HasText("3"))
				.And(you.WillSee(the.FeatureScenarioStats.Passed(8)).HasText("1"))
				.And(you.WillSee(the.FeatureScenarioStats.Skipped(8)).HasText("1"))
				.And(you.WillSee(the.FeatureScenarioStats.Failed(8)).HasText("1"))
				.And(you.WillSee(the.FeatureScenarioStats.BarChart(8)).IsVisible())
				.And(you.WillSee(the.FeatureScenarioStats.SuccessBar(8)).Style("has a width of 33%", ".*width: 33\\..*"))
				.And(you.WillSee(the.FeatureScenarioStats.SkippedBar(8)).Style("has a width of 33%", ".*width: 33\\..*"))
				.And(you.WillSee(the.FeatureScenarioStats.FailedBar(8)).Style("has a width of 33%", ".*width: 33\\..*"))
                .Run();
		}
	}
}