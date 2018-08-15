namespace xBDD.Features.GenerateReports.BrowseHtmlReport
{
	using xBDD.Features;
	using xBDD.Browser;
	using xBDD.Features.Pages.HtmlReportPage;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using xBDD.Features.Steps;
	using System.Threading.Tasks;

    [TestClass]
	public class ReviewScenario
	{
        private User you = new User();
        private HtmlReport the = new Pages.HtmlReportPage.HtmlReport();
        private ReportLocations theHtmlReport = new Pages.HtmlReportPage.ReportLocations();

		private readonly TestContextWriter outputWriter;

		public ReviewScenario()
		{
			outputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		public async Task Passing()
		{
            await xB.AddScenario(this, 1)
                .Given(AnHtmlReport.WithASinglePassingScenario())
                .When(you.NavigateTo(theHtmlReport.WithASinglePassingScenario))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(1,1)).IsVisible())
				.Then(you.WillSee(the.Scenario.BadgeGreen(1)).IsVisible())
				.And(you.WillSee(the.Scenario.Name(1,1)).IsVisible())
				.And(you.WillSee(the.Scenario.Name(1,1)).HasText("My Scenario 1"))
				.And(you.WillSee(the.Scenario.Steps(1)).IsNotVisible().Because("no steps failed"))
				.And(you.WillSee(the.Scenario.Duration(1)).IsVisible())
                .Run();
		}
		[TestMethod]
		public async Task Skipped()
		{
            await xB.AddScenario(this, 2)
                .Given(AnHtmlReport.WithASingleSkippedScenario())
                .When(you.NavigateTo(theHtmlReport.WithASingleSkippedScenario))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(1,1)).IsVisible())
				.Then(you.WillSee(the.Scenario.BadgeYellow(1)).IsVisible())
				.And(you.WillSee(the.Scenario.Steps(1)).IsNotVisible().Because("no steps failed"))
                .Run();
		}
		[TestMethod]
		public async Task Failing()
		{
            await xB.AddScenario(this, 3)
                .Given(AnHtmlReport.WithASingleFailedScenario())
                .When(you.NavigateTo(theHtmlReport.WithASingleFailedScenario))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(1,1)).IsVisible())
				.Then(you.WillSee(the.Scenario.BadgeRed(1)).IsVisible())
				.And(you.WillSee(the.Scenario.Steps(1)).IsNotVisible().Because("while the step failed the Failures Only options was not set to true"))
                .Run();
		}
	}
}