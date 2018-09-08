namespace xBDD.Features.GenerateReports.BrowseHtmlReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Threading.Tasks;
	using xBDD.Features.Actors;
	using xBDD.Features.Pages;

    [TestClass]
	public class ReviewScenario: xBDDFeatureBase
	{
        private HtmlReportUser you = new HtmlReportUser();
        private HtmlReportPageModel the = new HtmlReportPageModel();

		[TestMethod]
		public async Task Passing()
		{
            await xB.AddScenario(this, 1)
				.When(you.NavigateTo(the.HtmlReport.FromAFailedTestRun))
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
				.When(you.NavigateTo(the.HtmlReport.FromAFailedTestRun))
				.And(you.ClickWhen(the.Area.Name(2)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(5,2)).IsVisible())
				.Then(you.WillSee(the.Scenario.BadgeYellow(11)).IsVisible())
				.And(you.WillSee(the.Scenario.Steps(11)).IsNotVisible().Because("no steps failed"))
                .Run();
		}
		[TestMethod]
		public async Task Failing()
		{
            await xB.AddScenario(this, 3)
				.When(you.NavigateTo(the.HtmlReport.FromAFailedTestRun))
				.And(you.ClickWhen(the.Area.Name(3)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(8,3)).IsVisible())
				.Then(you.WillSee(the.Scenario.BadgeRed(20)).IsVisible())
				.And(you.WillSee(the.Scenario.Steps(20)).IsNotVisible().Because("while the step failed the Failures Only options was not set to true"))
                .Run();
		}
	}
}