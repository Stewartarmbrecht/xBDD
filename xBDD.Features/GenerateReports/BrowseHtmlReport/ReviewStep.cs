namespace xBDD.Features.GenerateReports.BrowseHtmlReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Threading.Tasks;
	using xBDD.Features.Actors;
	using xBDD.Features.Pages;

    [TestClass]
	public class ReviewStep
	{
        private HtmlReportUser you = new HtmlReportUser();
        private HtmlReportPageModel the = new HtmlReportPageModel();

		private readonly TestContextWriter outputWriter;

		public ReviewStep()
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
				.And(you.ClickWhen(the.Scenario.Name(1,1)).IsVisible())
				.Then(you.WillSee(the.Step.BadgeGreen(1)).IsVisible())
				.And(you.WillSee(the.Step.Name(1)).HasText("Given my step 1"))
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
				.And(you.ClickWhen(the.Scenario.Name(1,1)).IsVisible())
				.Then(you.WillSee(the.Step.BadgeYellow(1)).IsVisible())
				.And(you.WillSee(the.Step.Name(1)).HasText("Given my step 1"))
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
				.And(you.ClickWhen(the.Scenario.Name(1,1)).IsVisible())
				.Then(you.WillSee(the.Step.BadgeRed(2)).IsVisible().Because("the report will be expanded to the failed step"))
                .Run();
		}
		[TestMethod]
		public async Task WithException()
		{
            await xB.AddScenario(this, 4)
                .Given(you.GenerateAReportWithAFailingStepWithAnException())
                .When(you.NavigateTo(the.HtmlReport.WithAFailingStepWithAnException))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(1,1)).IsVisible())
				.And(you.ClickWhen(the.Scenario.Name(1,1)).IsVisible())
				.And(you.ClickWhen(the.StepException.Link(2,1)).IsVisible())
				.Then(you.WillSee(the.StepException.Section(2)).IsVisible())
				.Then(you.WillSee(the.StepException.Type(2)).IsVisible())
				.Then(you.WillSee(the.StepException.Message(2)).IsVisible())
				.Then(you.WillSee(the.StepException.StackTrace(2)).IsVisible())
                .Run();
		}
		[TestMethod]
		public async Task WithInnerException()
		{
            await xB.AddScenario(this, 5)
                .Given(you.GenerateAReportWithAFailingStepWithANestedException())
                .When(you.NavigateTo(the.HtmlReport.WithAFailingStepWithANestedException))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(1,1)).IsVisible())
				.And(you.ClickWhen(the.Scenario.Name(1,1)).IsVisible())
				.And(you.ClickWhen(the.StepException.Link(2,1)).IsVisible())
				.Then(you.WillSee(the.StepException.InnerException(2)).IsVisible())
				.Then(you.WillSee(the.StepException.InnerExceptionType(2)).IsVisible())
				.Then(you.WillSee(the.StepException.InnerExceptionMessage(2)).IsVisible())
				.Then(you.WillSee(the.StepException.InnerExceptionStackTrace(2)).IsVisible())
                .Run();
		}
	}
}