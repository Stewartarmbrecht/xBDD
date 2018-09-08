namespace xBDD.Features.GenerateReports.BrowseHtmlReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Threading.Tasks;
	using xBDD.Features.Actors;
	using xBDD.Features.Pages;

    [TestClass]
	public class ReviewTestRun: xBDDFeatureBase
	{
        private HtmlReportUser you = new HtmlReportUser();
		private Developer youAsADeveloper = new Developer();
        private HtmlReportPageModel the = new HtmlReportPageModel();

		[TestMethod]
		public async Task FromATestRunWithNoScenarios()
		{
            await xB.AddScenario(this, 1)
				.When(you.NavigateTo(the.HtmlReport.FromATestRunWithNoScenarios))
                .Then(you.WillSee(the.TestRun.Name).IsVisible())
                .And(you.WillSee(the.TestRun.Name).HasText("My Sample Features"))
                .And(you.AreViewingAPageWithTheTitle("My Sample Features"))
                .And(you.WillSee(the.TestRun.BadgeGrey).IsVisible().Because("no scenarios were run"))
                .Run();
		}
		
		[TestMethod]
		public async Task FromATestRunWithNoTests()
		{
			var pathToOutputFile = "../MySample.Features/test-results/MySample.Features.Results.None.Output.txt";
			var pathToTemplateFile = "../xBDD.Features/GenerateReports/BrowseHtmlReport/ReviewTestRun.FromATestRunWithNoTests.template";
            await xB.AddScenario(this, 1)
				.When("you execute a test run with no tests", (s) => {})
				.Then(you.WillSeeTheHtmlReportIsNotCreated("MySample.Features.Results.None.html"))
                .Then(youAsADeveloper.WillSeeTheOutputMatches(pathToTemplateFile, pathToOutputFile, "you will see an html report is generated that displays the test results in a collapsible tree"))
                .Run();
		}
		
		[TestMethod]
		public async Task PassingTestRun()
		{
            await xB.AddScenario(this, 2)
				.When(you.NavigateTo(the.HtmlReport.FromAPassingTestRun))
                .Then(you.WillSee(the.TestRun.BadgeGreen).IsVisible())
				.And(you.WillSee(the.TestRun.Duration).IsVisible())
                .Run();
		}
		
		[TestMethod]
		public async Task PassingWithSomeSkipped()
		{
            await xB.AddScenario(this, 3)
				.When(you.NavigateTo(the.HtmlReport.FromASkippedTestRun))
                .Then(you.WillSee(the.TestRun.BadgeYellow).IsVisible())
                .Run();
		}
		
		[TestMethod]
		public async Task Failing()
		{
            await xB.AddScenario(this, 4)
				.When(you.NavigateTo(the.HtmlReport.FromAFailedTestRun))
                .Then(you.WillSee(the.TestRun.BadgeRed).IsVisible())
                .Run();
		}
	}
}