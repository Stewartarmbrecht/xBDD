
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
	[AsA("Developer")]
	[YouCan("see the distribution of feature outcomes for an area")]
	[By("reviewing the distribution graph next to the area badge")]
	public class ReviewFeatureScenarioDistribution
	{
        private User you = new User();
        private HtmlReport the = new Pages.HtmlReportPage.HtmlReport();
        private ReportLocations theHtmlReport = new Pages.HtmlReportPage.ReportLocations();

		private readonly TestContextWriter outputWriter;

		public ReviewFeatureScenarioDistribution()
		{
			outputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		public async Task FailedSkippedAndPassingScenarioStats()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.AddScenario(this, 1)
                .Given(AnHtmlReport.WithAFullTestRunWithAllOutcomes())
				.When(you.NavigateTo(theHtmlReport.WithAFullTestRunWithAllOutcomes))
				.And(you.WaitTill(the.Area.Badge(3)).IsVisible())
				.Then(you.WillSee(the.FeatureScenarioDistro.BadgeDistro(7)).IsVisible())
				.And(you.WillSee(the.FeatureScenarioDistro.BadgeDistro(7)).HasTitleAKAHoverText("Scenarios"))
				.And(you.WillSee(the.FeatureScenarioDistro.Chart(7)).IsVisible())
				.And(you.WillSee(the.FeatureScenarioDistro.PassedBar(7)).HasStyle("has a heigth of 33%", ".*height\\: 33\\..*\\%\\;.*"))
				.And(you.WillSee(the.FeatureScenarioDistro.SkippedBar(7)).HasStyle("has a heigth of 33%", ".*height\\: 33\\..*\\%\\;.*"))
				.And(you.WillSee(the.FeatureScenarioDistro.FailedBar(7)).HasStyle("has a heigth of 33%", ".*height\\: 33\\..*\\%\\;.*"))
                .Run();
		}
		[TestMethod]
		public async Task AllPassingScenarioStats()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.AddScenario(this, 1)
                .Given(AnHtmlReport.WithAPassingFullTestRun())
				.When(you.NavigateTo(theHtmlReport.WithAPassingFullTestRun))
				.And(you.WaitTill(the.Area.Badge(1)).IsVisible())
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.Then(you.WillSee(the.FeatureScenarioDistro.Chart(1)).IsVisible())
				.And(you.WillSee(the.FeatureScenarioDistro.PassedBar(1)).HasStyle("has a heigth of 33%", ".*height\\: 100\\%\\;.*"))
				.And(you.WillSee(the.FeatureScenarioDistro.SkippedBar(1)).IsNotThere())
				.And(you.WillSee(the.FeatureScenarioDistro.FailedBar(1)).IsNotThere())
                .Run();
		}
		[TestMethod]
		public async Task AllSkippedScenarioStats()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.AddScenario(this, 1)
                .Given(AnHtmlReport.WithASingleSkippedScenario())
				.When(you.NavigateTo(theHtmlReport.WithASingleSkippedScenario))
				.And(you.WaitTill(the.Area.Badge(1)).IsVisible())
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.Then(you.WillSee(the.FeatureScenarioDistro.Chart(1)).IsVisible())
				.And(you.WillSee(the.FeatureScenarioDistro.SkippedBar(1)).HasStyle("has a heigth of 33%", ".*height\\: 100\\%\\;.*"))
				.And(you.WillSee(the.FeatureScenarioDistro.PassedBar(1)).IsNotThere())
				.And(you.WillSee(the.FeatureScenarioDistro.FailedBar(1)).IsNotThere())
                .Run();
		}
		[TestMethod]
		public async Task AllFailedScenarioStats()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.AddScenario(this, 1)
                .Given(AnHtmlReport.WithASingleFailedScenario())
				.When(you.NavigateTo(theHtmlReport.WithASingleFailedScenario))
				.And(you.WaitTill(the.Area.Badge(1)).IsVisible())
				.Then(you.WillSee(the.FeatureScenarioDistro.Chart(1)).IsVisible())
				.And(you.WillSee(the.FeatureScenarioDistro.FailedBar(1)).HasStyle("has a heigth of 33%", ".*height\\: 100\\%\\;.*"))
				.And(you.WillSee(the.FeatureScenarioDistro.PassedBar(1)).IsNotThere())
				.And(you.WillSee(the.FeatureScenarioDistro.SkippedBar(1)).IsNotThere())
                .Run();
		}
	}
}