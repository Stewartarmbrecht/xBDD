namespace xBDD.Features.GenerateReports.BrowseHtmlReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Threading.Tasks;
	using xBDD.Features.Actors;
	using xBDD.Features.Pages;

    [TestClass]
	public class ReviewStep: xBDDFeatureBase
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
				.And(you.ClickWhen(the.Scenario.Name(1,1)).IsVisible())
				.Then(you.WillSee(the.Step.BadgeGreen(1)).IsVisible())
				.And(you.WillSee(the.Step.Name(1)).HasText("Given my step 1"))
                .Run();
		}
		[TestMethod]
		public async Task Skipped()
		{
            await xB.AddScenario(this, 2)
				.When(you.NavigateTo(the.HtmlReport.FromAFailedTestRun))
				.And(you.ClickWhen(the.Area.Name(2)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(5,2)).IsVisible())
				.And(you.ClickWhen(the.Scenario.Name(11,5)).IsVisible())
				.Then(you.WillSee(the.Step.BadgeYellow(31)).IsVisible())
				.And(you.WillSee(the.Step.Name(31)).HasText("Given my step 31"))
                .Run();
		}
		[TestMethod]
		public async Task Failing()
		{
            await xB.AddScenario(this, 3)
				.When(you.NavigateTo(the.HtmlReport.FromAFailedTestRun))
				.And(you.ClickWhen(the.Area.Name(3)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(8,3)).IsVisible())
				.And(you.ClickWhen(the.Scenario.Name(20,8)).IsVisible())
				.Then(you.WillSee(the.Step.BadgeRed(59)).IsVisible().Because("the report will be expanded to the failed step"))
                .Run();
		}
		[TestMethod]
		public async Task WithException()
		{
            await xB.AddScenario(this, 4)
				.When(you.NavigateTo(the.HtmlReport.FromAFailedTestRun))
				.And(you.ClickWhen(the.Area.Name(3)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(8,3)).IsVisible())
				.And(you.ClickWhen(the.Scenario.Name(20,8)).IsVisible())
				.And(you.ClickWhen(the.StepException.Link(59,20)).IsVisible())
				.Then(you.WillSee(the.StepException.Section(59)).IsVisible())
				.Then(you.WillSee(the.StepException.Type(59)).IsVisible())
				.Then(you.WillSee(the.StepException.Message(59)).IsVisible())
				.Then(you.WillSee(the.StepException.StackTrace(59)).IsVisible())
                .Run();
		}
		[TestMethod]
		public async Task WithInnerException()
		{
            await xB.AddScenario(this, 5)
				.When(you.NavigateTo(the.HtmlReport.FromAFailedTestRun))
				.And(you.ClickWhen(the.Area.Name(3)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(8,3)).IsVisible())
				.And(you.ClickWhen(the.Scenario.Name(21,8)).IsVisible())
				.And(you.ClickWhen(the.StepException.Link(62,21)).IsVisible())
				.Then(you.WillSee(the.StepException.InnerException(62)).IsVisible())
				.Then(you.WillSee(the.StepException.InnerExceptionType(62)).IsVisible())
				.Then(you.WillSee(the.StepException.InnerExceptionMessage(62)).IsVisible())
				.Then(you.WillSee(the.StepException.InnerExceptionStackTrace(62)).IsVisible())
                .Run();
		}
	}
}