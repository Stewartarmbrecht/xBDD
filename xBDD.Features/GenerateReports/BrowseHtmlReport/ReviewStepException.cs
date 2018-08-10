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
				.Then(you.WillSee(the.StepException.Message(2)).IsNotVisible().Because("the exception is collapsed by default."))
                .Run();
		}
		
		
		[TestMethod]
		public async Task Collapse()
		{
            await xB.AddScenario(this, 1)
                .Given(AnHtmlReport.WithAFailingStepWithAnException())
				.And(you.NavigateTo(theHtmlReport.WithAFailingStepWithAnException))
				.When(you.ClickWhen(the.StepException.Link(2)).IsVisible())
				.Then(you.WillSee(the.StepException.Section(2)).IsVisible())
                .Run();
		}
		[TestMethod]
		public async Task CollapseAll()
		{
			 await xB.CurrentRun.AddScenario(this, 2)
				.Skip("Not Started");
		}
		[TestMethod]
		public async Task Expand()
		{
			 await xB.CurrentRun.AddScenario(this, 3)
				.Skip("Not Started");
		}
		[TestMethod]
		public async Task ExpandAll()
		{
			 await xB.CurrentRun.AddScenario(this, 4)
				.Skip("Not Started");
		}
		[TestMethod]
		public async Task DefaultCollapsedWhenMoreThan5()
		{
			 await xB.CurrentRun.AddScenario(this, 5)
				.Skip("Not Started");
		}
	}
}
