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
				.And(you.ClickWhen(the.Feature.Badge(9)).IsVisible())
				.Then(you.WillSee(the.FeatureScenarioStats.Section(9)).IsVisible())
				.And(you.WillSee(the.FeatureScenarioStats.Total(9)).IsVisible())
				.And(you.WillSee(the.FeatureScenarioStats.Total(9)).HasText("3"))
				.And(you.WillSee(the.FeatureScenarioStats.Passed(9)).HasText("1"))
				.And(you.WillSee(the.FeatureScenarioStats.Skipped(9)).HasText("1"))
				.And(you.WillSee(the.FeatureScenarioStats.Failed(9)).HasText("1"))
				.And(you.WillSee(the.FeatureScenarioStats.BarChart(9)).IsVisible())
				.And(you.WillSee(the.FeatureScenarioStats.SuccessBar(9)).Style("has a width of 33%", ".*width: 33\\..*"))
				.And(you.WillSee(the.FeatureScenarioStats.SkippedBar(9)).Style("has a width of 33%", ".*width: 33\\..*"))
				.And(you.WillSee(the.FeatureScenarioStats.FailedBar(9)).Style("has a width of 33%", ".*width: 33\\..*"))
                .Run();
		}
	}
}