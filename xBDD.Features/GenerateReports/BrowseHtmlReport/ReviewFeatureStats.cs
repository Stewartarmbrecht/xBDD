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
	public class ReviewFeatureStats
	{
        private HtmlReportUser you = new HtmlReportUser();
        private HtmlReportPageModel the = new HtmlReportPageModel();
        

		private readonly TestContextWriter outputWriter;

		public ReviewFeatureStats()
		{
			outputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		public async Task FailedSkippedAndPassingScenarioStats()
		{
            await xB.CurrentRun.AddScenario(this, 1)
                .Given(you.GenerateAReportWithAFullTestRunWithAllOutcomes())
 				.When(you.NavigateTo(the.HtmlReport.WithAFullTestRunWithAllOutcomes))
				.And(you.ClickWhen(the.Area.Name(3)).IsVisible())
				.And(you.ClickWhen(the.Feature.Badge(7)).IsVisible())
				.Then(you.WillSee(the.FeatureScenarioStats.Section(7)).IsVisible())
				.And(you.WillSee(the.FeatureScenarioStats.Total(7)).IsVisible())
				.And(you.WillSee(the.FeatureScenarioStats.Total(7)).HasText("3"))
				.And(you.WillSee(the.FeatureScenarioStats.Passed(7)).HasText("1"))
				.And(you.WillSee(the.FeatureScenarioStats.Skipped(7)).HasText("1"))
				.And(you.WillSee(the.FeatureScenarioStats.Failed(7)).HasText("1"))
				.And(you.WillSee(the.FeatureScenarioStats.BarChart(7)).IsVisible())
				.And(you.WillSee(the.FeatureScenarioStats.SuccessBar(7)).Style("has a width of 33%", ".*width: 33\\..*"))
				.And(you.WillSee(the.FeatureScenarioStats.SkippedBar(7)).Style("has a width of 33%", ".*width: 33\\..*"))
				.And(you.WillSee(the.FeatureScenarioStats.FailedBar(7)).Style("has a width of 33%", ".*width: 33\\..*"))
                .Run();
		}
	}
}