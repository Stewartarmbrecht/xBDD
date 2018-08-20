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
	public class ReviewStepStats: FeatureTestClass
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
				.And(you.ClickWhen(the.Scenario.Name(20,8)).IsVisible())
				.Then(you.WillSee(the.Step.Duration(59)).IsVisible())
                .Run();
		}
	}
}