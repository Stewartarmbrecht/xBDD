
namespace xBDD.Features.GenerateReports.BrowseHtmlReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Threading.Tasks;
	using xBDD.Features.Actors;
	using xBDD.Features.Pages;

    [TestClass]
	public class ReviewFeature: FeatureTestClass
	{
        private HtmlReportUser you = new HtmlReportUser();
        private HtmlReportPageModel the = new HtmlReportPageModel();

		[TestMethod]
		public async Task Passing()
		{
            await xB.AddScenario(this, 1)
				.When(you.NavigateTo(the.HtmlReport.FromAFailedTestRun))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.Then(you.WillSee(the.Feature.Name(1,1)).HasText("My Feature 1 Passing"))
				.And(you.WillSee(the.Feature.BadgeGreen(1)).IsVisible())
				.And(you.WillSee(the.Feature.Duration(1)).IsVisible())
				.And(you.WillSee(the.Feature.Scenarios(1)).IsNotVisible().Because("none were failing"))
                .Run();
		}
		[TestMethod]
		public async Task Skipped()
		{
            await xB.AddScenario(this, 2)
				.When(you.NavigateTo(the.HtmlReport.FromAFailedTestRun))
				.And(you.ClickWhen(the.Area.Name(2)).IsVisible())
				.Then(you.WillSee(the.Feature.Name(5,2)).HasText("My Feature 5 Some Skipped"))
				.And(you.WillSee(the.Feature.BadgeYellow(5)).IsVisible())
				.And(you.WillSee(the.Feature.Scenarios(5)).IsNotVisible().Because("none were failing"))
                .Run();
		}
		[TestMethod]
		public async Task Failing()
		{
            await xB.CurrentRun.AddScenario(this, 3)
				.When(you.NavigateTo(the.HtmlReport.FromAFailedTestRun))
				.And(you.ClickWhen(the.Area.Name(3)).IsVisible())
				.Then(you.WillSee(the.Feature.BadgeRed(8)).IsVisible())
				.And(you.WillSee(the.Feature.Scenarios(8)).IsNotVisible().Because("the Failures Only option was not set to true that would cause the failred feature to automatically expand."))
                .Run();
		}
	}
}