namespace xBDD.Features.GenerateReports.BrowseHtmlReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Threading.Tasks;
	using xBDD.Features.Actors;
	using xBDD.Features.Pages;

    [TestClass]
	public class ReviewScenario
	{
        private HtmlReportUser you = new HtmlReportUser();
        private HtmlReportPageModel the = new HtmlReportPageModel();
        

		private readonly TestContextWriter outputWriter;

		public ReviewScenario()
		{
			outputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		public async Task Passing()
		{
            await xB.AddScenario(this, 1)
                .Given(you.GenerateAReportWithASinglePassingScenario())
                .When(you.NavigateTo(the.HtmlReport.WithASinglePassingScenario))
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
                .Given(you.GenerateAReportWithASingleSkippedScenario())
                .When(you.NavigateTo(the.HtmlReport.WithASingleSkippedScenario))
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
                .Given(you.GenerateAReportWithASingleFailedScenario())
                .When(you.NavigateTo(the.HtmlReport.WithASingleFailedScenario))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(1,1)).IsVisible())
				.Then(you.WillSee(the.Scenario.BadgeRed(1)).IsVisible())
				.And(you.WillSee(the.Scenario.Steps(1)).IsNotVisible().Because("while the step failed the Failures Only options was not set to true"))
                .Run();
		}
	}
}