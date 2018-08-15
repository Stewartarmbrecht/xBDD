namespace xBDD.Features.GenerateReports.BrowseHtmlReport
{
	using xBDD.Features;
	using xBDD.Browser;
	using xBDD.Features.Pages.HtmlReportPage;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using xBDD.Features.Steps;
	using System.Threading.Tasks;

	[TestClass]
	public class ReviewStepException
	{
        private User you = new User();
        private HtmlReport the = new Pages.HtmlReportPage.HtmlReport();
        private ReportLocations theHtmlReport = new Pages.HtmlReportPage.ReportLocations();

		private readonly TestContextWriter outputWriter;

		public ReviewStepException()
		{
			outputWriter = new TestContextWriter();
		}
		[TestMethod]
		public async Task CollapsedByDefault()
		{
            await xB.AddScenario(this, 1)
                .Given(AnHtmlReport.WithAFailingStepWithAnException())
				.When(you.NavigateTo(theHtmlReport.WithAFailingStepWithAnException))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(1,1)).IsVisible())
				.And(you.ClickWhen(the.Scenario.Name(1,1)).IsVisible())
				.Then(you.WillSee(the.StepException.Message(2)).IsNotVisible().Because("the exception is collapsed by default."))
                .Run();
		}
		
		
		[TestMethod]
		public async Task Collapse()
		{
            await xB.AddScenario(this, 1)
                .Given(AnHtmlReport.WithAFailingStepWithAnException())
				.And(you.NavigateTo(theHtmlReport.WithAFailingStepWithAnException))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(1,1)).IsVisible())
				.And(you.ClickWhen(the.Scenario.Name(1,1)).IsVisible())
				.When(you.ClickWhen(the.StepException.Link(2,1)).IsVisible())
				.And(you.WaitTill(the.StepException.Section(2)).IsVisible())
				.And(you.Click(the.StepException.Link(2,1)))
				.Then(you.WillSee(the.StepException.Section(2)).IsNotThere())
                .Run();
		}
		[TestMethod]
		public async Task CollapseAll()
		{
			 await xB.CurrentRun.AddScenario(this, 2)
				.Skip("Not Started", Assert.Inconclusive);
		}
		[TestMethod]
		public async Task Expand()
		{
            await xB.AddScenario(this, 1)
                .Given(AnHtmlReport.WithAFailingStepWithAnException())
				.And(you.NavigateTo(theHtmlReport.WithAFailingStepWithAnException))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(1,1)).IsVisible())
				.And(you.ClickWhen(the.Scenario.Name(1,1)).IsVisible())
				.When(you.ClickWhen(the.StepException.Link(2,1)).IsVisible())
				.Then(you.WillSee(the.StepException.Section(2)).IsVisible())
                .Run();
		}
		[TestMethod]
		public async Task ExpandAll()
		{
			 await xB.CurrentRun.AddScenario(this, 4)
				.Skip("Not Started", Assert.Inconclusive);
		}
	}
}
