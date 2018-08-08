namespace xBDD.Reporting.Features.BrowseHtmlReport
{
	using xBDD.Test;
	using xBDD.Browser;
	using xBDD.Reporting.Features.Pages.HtmlReportPage;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using xBDD.Reporting.Features.Steps;
	using System.Threading.Tasks;

    [TestClass]
	//  [Description("In order to understand how functionality is organized")]
	//  [Description("As a report reviewer")]
	//  [Description("I would like to view the areas in the html report")]
	public class ReviewStep
	{
        private User you = new User();
        private HtmlReport the = new Pages.HtmlReportPage.HtmlReport();
        private ReportLocations theHtmlReport = new Pages.HtmlReportPage.ReportLocations();

		private readonly TestContextWriter outputWriter;

		public ReviewStep()
		{
			outputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		public async Task Passing()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.AddScenario(this)
                .Given(AnHtmlReport.WithASinglePassingScenario())
                .When(you.NavigateTo(theHtmlReport.WithASinglePassingScenario))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(1)).IsVisible())
				.And(you.ClickWhen(the.Scenario.Name(1)).IsVisible())
				.Then(you.WillSee(the.Step.BadgeGreen(1)).IsVisible())
				.And(you.WillSee(the.Step.Name(1)).HasText("Given my step 1"))
                .Run();
		}
		[TestMethod]
		public async Task Skipped()
		{
            await xB.AddScenario(this)
                .Given(AnHtmlReport.WithASingleSkippedScenario())
                .When(you.NavigateTo(theHtmlReport.WithASingleSkippedScenario))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(1)).IsVisible())
				.And(you.ClickWhen(the.Scenario.Name(1)).IsVisible())
				.Then(you.WillSee(the.Step.BadgeYellow(1)).IsVisible())
				.And(you.WillSee(the.Step.Name(1)).HasText("Given my step 1"))
                .Run();
		}
		[TestMethod]
		public async Task Failing()
		{
            await xB.AddScenario(this)
                .Given(AnHtmlReport.WithASingleFailedScenario())
                .When(you.NavigateTo(theHtmlReport.WithASingleFailedScenario))
				.Then(you.WillSee(the.Step.BadgeRed(2)).IsVisible().Because("the report will be expanded to the failed step"))
                .Run();
		}
		[TestMethod]
		public async Task WithException()
		{
            await xB.AddScenario(this)
                .Given(AnHtmlReport.WithAFailingStepWithAnException())
                .When(you.NavigateTo(theHtmlReport.WithAFailingStepWithAnException))
				.Then(you.WillSee(the.StepException.Section(2)).IsVisible())
				.Then(you.WillSee(the.StepException.Type(2)).IsVisible())
				.Then(you.WillSee(the.StepException.Message(2)).IsVisible())
				.Then(you.WillSee(the.StepException.StackTrace(2)).IsVisible())
                .Run();
		}
		[TestMethod]
		public async Task WithInnerException()
		{
            await xB.AddScenario(this)
                .Given(AnHtmlReport.WithAFailingStepWithANestedException())
                .When(you.NavigateTo(theHtmlReport.WithAFailingStepWithANestedException))
				.Then(you.WillSee(the.StepException.InnerException(2)).IsVisible())
				.Then(you.WillSee(the.StepException.InnerExceptionType(2)).IsVisible())
				.Then(you.WillSee(the.StepException.InnerExceptionMessage(2)).IsVisible())
				.Then(you.WillSee(the.StepException.InnerExceptionStackTrace(2)).IsVisible())
                .Run();
		}
	}
}