namespace xBDD.Features.GenerateReports.BrowseHtmlReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Threading.Tasks;
	using xBDD.Features.Actors;
	using xBDD.Features.Pages;

	[TestClass]
	public class ReviewStepException
	{
        private HtmlReportUser you = new HtmlReportUser();
        private HtmlReportPageModel the = new HtmlReportPageModel();
        

		private readonly TestContextWriter outputWriter;

		public ReviewStepException()
		{
			outputWriter = new TestContextWriter();
		}
		[TestMethod]
		public async Task CollapsedByDefault()
		{
            await xB.AddScenario(this, 1)
                .Given(you.GenerateAReportWithAFailingStepWithAnException())
				.When(you.NavigateTo(the.HtmlReport.WithAFailingStepWithAnException))
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
                .Given(you.GenerateAReportWithAFailingStepWithAnException())
				.And(you.NavigateTo(the.HtmlReport.WithAFailingStepWithAnException))
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
                .Given(you.GenerateAReportWithAFailingStepWithAnException())
				.And(you.NavigateTo(the.HtmlReport.WithAFailingStepWithAnException))
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
