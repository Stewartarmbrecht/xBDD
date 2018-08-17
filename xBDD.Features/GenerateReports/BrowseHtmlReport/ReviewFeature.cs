
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
                .Given(you.GenerateAReportWithASinglePassingScenario())
                .When(you.NavigateTo(the.HtmlReport.WithASinglePassingScenario))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.Then(you.WillSee(the.Feature.Name(1,1)).HasText("My Feature 1"))
				.And(you.WillSee(the.Feature.BadgeGreen(1)).IsVisible())
				.And(you.WillSee(the.Feature.Duration(1)).IsVisible())
				.And(you.WillSee(the.Feature.Scenarios(1)).IsNotVisible().Because("none were failing"))
                .Run();
		}
		[TestMethod]
		public async Task Skipped()
		{
            await xB.AddScenario(this, 2)
                .Given(you.GenerateAReportWithASingleSkippedScenario())
                .When(you.NavigateTo(the.HtmlReport.WithASingleSkippedScenario))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.Then(you.WillSee(the.Feature.Name(1,1)).HasText("My Feature 1"))
				.And(you.WillSee(the.Feature.BadgeYellow(1)).IsVisible())
				.And(you.WillSee(the.Feature.Scenarios(1)).IsNotVisible().Because("none were failing"))
                .Run();
		}
		[TestMethod]
		public async Task Failing()
		{
            await xB.CurrentRun.AddScenario(this, 3)
                .Given(you.GenerateAReportWithASingleFailedScenario())
                .When(you.NavigateTo(the.HtmlReport.WithASingleFailedScenario))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.Then(you.WillSee(the.Feature.BadgeRed(1)).IsVisible())
				.And(you.WillSee(the.Feature.Scenarios(1)).IsNotVisible().Because("the Failures Only option was not set to true that would cause the failred feature to automatically expand."))
                .Run();
		}
	}
}