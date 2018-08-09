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
	//  [Description("I would like to view the features in the html report")]
	public class ReviewFeatureStats
	{
        private User you = new User();
        private HtmlReport the = new Pages.HtmlReportPage.HtmlReport();
        private ReportLocations theHtmlReport = new Pages.HtmlReportPage.ReportLocations();

		private readonly TestContextWriter outputWriter;

		public ReviewFeatureStats()
		{
			outputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		public async Task FailedSkippedAndPassingScenarioStats()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(AnHtmlReport.WithAFullTestRunWithAllOutcomes())
 				.When(you.NavigateTo(theHtmlReport.WithAFullTestRunWithAllOutcomes))
				.And(you.ClickWhen(the.Feature.Badge(7)).IsVisible())
				.Then(you.WillSee(the.FeatureScenarioStats.Section(7)).IsVisible())
				.And(you.WillSee(the.FeatureScenarioStats.Total(7)).IsVisible())
				.And(you.WillSee(the.FeatureScenarioStats.Total(7)).HasText("3"))
				.And(you.WillSee(the.FeatureScenarioStats.Total(7)).HasTitleAKAHoverText("Scenarios"))
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