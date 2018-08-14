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
	public class ReviewStepStats
	{
        private User you = new User();
        private HtmlReport the = new Pages.HtmlReportPage.HtmlReport();
        private ReportLocations theHtmlReport = new Pages.HtmlReportPage.ReportLocations();

		private readonly TestContextWriter outputWriter;

		public ReviewStepStats()
		{
			outputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		public async Task FailedSkippedAndPassingStepsStats()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this, 1)
                .Given(AnHtmlReport.WithAFullTestRunWithAllOutcomes())
 				.And(you.NavigateTo(theHtmlReport.WithAFullTestRunWithAllOutcomes))
				.And(you.ClickWhen(the.Area.Name(3)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(7)).IsVisible())
				.And(you.ClickWhen(the.Scenario.Name(19)).IsVisible())
				.Then(you.WillSee(the.Step.Duration(56)).IsVisible())
                .Run();
		}
	}
}