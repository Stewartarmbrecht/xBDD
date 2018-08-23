namespace xBDD.Features.GenerateReports.BrowseHtmlReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Threading.Tasks;
	using xBDD.Features.Actors;
	using xBDD.Features.Pages;

	[TestClass]
	public class ReviewStepException: FeatureTestClass
	{
        private HtmlReportUser you = new HtmlReportUser();
        private HtmlReportPageModel the = new HtmlReportPageModel();

		[TestMethod]
		public async Task CollapsedByDefault()
		{
            await xB.AddScenario(this, 1)
				.When(you.NavigateTo(the.HtmlReport.FromAFailedTestRun))
				.And(you.ClickWhen(the.Area.Name(3)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(8,3)).IsVisible())
				.And(you.ClickWhen(the.Scenario.Name(20,8)).IsVisible())
				.Then(you.WillSee(the.StepException.Message(59)).IsNotVisible().Because("the exception is collapsed by default."))
                .Run();
		}
		
		
		[TestMethod]
		public async Task Collapse()
		{
            await xB.AddScenario(this, 1)
				.Given(you.NavigateTo(the.HtmlReport.FromAFailedTestRun))
				.And(you.ClickWhen(the.Area.Name(3)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(8,3)).IsVisible())
				.And(you.ClickWhen(the.Scenario.Name(20,8)).IsVisible())
				.When(you.ClickWhen(the.StepException.Link(59,20)).IsVisible())
				.And(you.WaitTill(the.StepException.Section(59)).IsVisible())
				.And(you.Click(the.StepException.Link(59,20)))
				.Then(you.WillSee(the.StepException.Section(59)).IsNotThere())
                .Run();
		}
		[TestMethod]
		public async Task CollapseAll()
		{
			 await xB.CurrentRun.AddScenario(this, 2)
				.Skip("Defining", Assert.Inconclusive);
		}
		[TestMethod]
		public async Task Expand()
		{
            await xB.AddScenario(this, 1)
				.Given(you.NavigateTo(the.HtmlReport.FromAFailedTestRun))
				.And(you.ClickWhen(the.Area.Name(3)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(8,3)).IsVisible())
				.And(you.ClickWhen(the.Scenario.Name(20,8)).IsVisible())
				.When(you.ClickWhen(the.StepException.Link(59,20)).IsVisible())
				.Then(you.WillSee(the.StepException.Section(59)).IsVisible())
                .Run();
		}
		[TestMethod]
		public async Task ExpandAll()
		{
			 await xB.CurrentRun.AddScenario(this, 4)
				.Skip("Defining", Assert.Inconclusive);
		}
	}
}
