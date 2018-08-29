namespace xBDD.Features.GenerateReports.BrowseHtmlReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Threading.Tasks;
	using xBDD.Features.Actors;
	using xBDD.Features.Pages;

    [TestClass]
	//  [Description("In order to understand how functionality is organized")]
	//  [Description("As a report reviewer")]
	//  [Description("I would like to view the features in the html report")]
	public class ReviewScenarioStats: xBDDFeatureBase
	{
        private HtmlReportUser you = new HtmlReportUser();
        private HtmlReportPageModel the = new HtmlReportPageModel();

		[TestMethod]
		public async Task FailedSkippedAndPassingStepsStats()
		{
            await xB.CurrentRun.AddScenario(this, 1)
				.When(you.NavigateTo(the.HtmlReport.FromAFailedTestRun))
				.And(you.ClickWhen(the.Area.Name(3)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(8,3)).IsVisible())
				.Then(you.WillSee(the.ScenarioStepStats.Total(20)).IsVisible())
				.And(you.WillSee(the.ScenarioStepStats.Total(20)).HasText("3"))
				.And(you.WillSee(the.ScenarioStepStats.Total(20)).HasTitleAKAHoverText("Steps"))
                .Run();
		}
	}
}