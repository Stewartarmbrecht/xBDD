namespace xBDD.Features.GenerateReports.BrowseHtmlReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Threading.Tasks;
	using xBDD.Features.Actors;
	using xBDD.Features.Pages;

    [TestClass]
	public class ReviewStepMultilineParameter: FeatureTestClass
	{
        private HtmlReportUser you = new HtmlReportUser();
        private HtmlReportPageModel the = new HtmlReportPageModel();

		[TestMethod]
		public async Task CollapsedByDefault()
		{
            await xB.AddScenario(this, 1)
				.When(you.NavigateTo(the.HtmlReport.FromAFailedTestRun))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(1,1)).IsVisible())
				.And(you.ClickWhen(the.Scenario.Name(1,1)).IsVisible())
				.Then(you.WillSee(the.Input.Link(2)).IsVisible())
				.And(you.WillSee(the.Input.Section(2)).IsNotVisible())
                .Run();
		}
		
		[TestMethod]
		public async Task GeneralText()
		{
			var input = $"Here{System.Environment.NewLine} is{System.Environment.NewLine} my{System.Environment.NewLine} Input!";
            await xB.AddScenario(this, 2)
				.When(you.NavigateTo(the.HtmlReport.FromAFailedTestRun))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(1,1)).IsVisible())
				.And(you.ClickWhen(the.Scenario.Name(1,1)).IsVisible())
				.And(you.ClickWhen(the.Input.Link(2)).IsVisible())
				.Then(you.WillSee(the.Input.Section(2)).IsVisible())
				.And(you.WillSee(the.Input.Text(2)).HasText(input))
                .Run();
		}
		
		[TestMethod]
		public async Task Code()
		{
            await xB.AddScenario(this, 3)
				.Skip("Untested", Assert.Inconclusive);
		}
		
		[TestMethod]
		public async Task HtmlWithPreview()
		{
            await xB.AddScenario(this, 4)
				.Skip("Untested", Assert.Inconclusive);
		}
		
		[TestMethod]
		public async Task Collapse()
		{
			 await xB.AddScenario(this, 5)
				.Skip("Untested", Assert.Inconclusive);
		}
		[TestMethod]
		public async Task CollapseAll()
		{
			 await xB.AddScenario(this, 6)
				.Skip("Defining", Assert.Inconclusive);
		}
		[TestMethod]
		public async Task Expand()
		{
			 await xB.AddScenario(this, 7)
				.Skip("Untested", Assert.Inconclusive);
		}
		[TestMethod]
		public async Task ExpandAll()
		{
			 await xB.AddScenario(this, 8)
				.Skip("Defining", Assert.Inconclusive);
		}
	}
}