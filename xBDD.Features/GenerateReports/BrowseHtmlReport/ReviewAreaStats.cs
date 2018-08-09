
namespace xBDD.Features.GenerateReports.BrowseHtmlReport
{
	using xBDD;
	using xBDD.Features;
	using xBDD.Browser;
	using xBDD.Features.Steps;
    using xBDD.Features.Pages.HtmlReportPage;
	using System.Threading.Tasks;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
	//  [Description("In order to understand how functionality is organized")]
	//  [Description("As a report reviewer")]
	//  [Description("I would like to view the areas in the html report")]
	public class ReviewAreaStats
	{
        private User you = new User();
        private HtmlReport the = new Pages.HtmlReportPage.HtmlReport();
        private ReportLocations theHtmlReport = new Pages.HtmlReportPage.ReportLocations();

		private readonly TestContextWriter outputWriter;

		public ReviewAreaStats()
		{
			outputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		public async Task FailedSkippedAndPassingFeatureStats()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.AddScenario(this, 1)
                .Given(AnHtmlReport.WithAFullTestRunWithAllOutcomes())
				.When(you.NavigateTo(theHtmlReport.WithAFullTestRunWithAllOutcomes))
				.And(you.WaitTill(the.Area.Badge(3)).IsVisible())
				.And(you.Click(the.Area.Badge(3)))
				.Then(you.WillSee(the.AreaFeatureStats.Section(3)).IsVisible())
				.And(you.WillSee(the.AreaFeatureStats.Total(3)).HasText("3"))
				.And(you.WillSee(the.AreaFeatureStats.Total(3)).HasTitleAKAHoverText("Features"))
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
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this, 2)
                .Given(AnHtmlReport.WithAFullTestRunWithAllOutcomes())
 				.When(you.NavigateTo(theHtmlReport.WithAFullTestRunWithAllOutcomes))
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