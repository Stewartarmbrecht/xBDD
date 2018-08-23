namespace xBDD.Features.GenerateReports.BrowseHtmlReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Threading.Tasks;
	using xBDD.Features.Actors;
	using xBDD.Features.Pages;

    [TestClass]
	public class ReviewStepOutput: FeatureTestClass
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
				.Then(you.WillSee(the.Output.Link(3)).IsVisible())
                .Run();
		}
		
		[TestMethod]
		public async Task GeneralText()
		{
			var output = $"Here{System.Environment.NewLine} is{System.Environment.NewLine} my{System.Environment.NewLine} output!";
            await xB.AddScenario(this, 2)
				.When(you.NavigateTo(the.HtmlReport.FromAFailedTestRun))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(1,1)).IsVisible())
				.And(you.ClickWhen(the.Scenario.Name(1,1)).IsVisible())
				.And(you.ClickWhen(the.Output.Link(3)).IsVisible())
				.Then(you.WillSee(the.Output.Section(3)).IsVisible())
				.And(you.WillSee(the.Output.Text(3)).HasText(output))
                .Run();
		}
		
		[TestMethod]
		public async Task Code()
		{
            await xB.AddScenario(this, 3)
				.Skip("Definig", Assert.Inconclusive);
		}
		
		[TestMethod]
		public async Task HtmlWithPreview()
		{
            await xB.AddScenario(this, 4)
				.Skip("Definig", Assert.Inconclusive);
		}
		
		[TestMethod]
		public async Task Collapse()
		{
			 await xB.AddScenario(this, 5)
				.Skip("Definig", Assert.Inconclusive);
		}
		[TestMethod]
		public async Task CollapseAll()
		{
			 await xB.AddScenario(this, 6)
				.Skip("Definig", Assert.Inconclusive);
		}
		[TestMethod]
		public async Task Expand()
		{
			 await xB.AddScenario(this, 7)
				.Skip("Definig", Assert.Inconclusive);
		}
		[TestMethod]
		public async Task ExpandAll()
		{
			 await xB.AddScenario(this, 8)
				.Skip("Definig", Assert.Inconclusive);
		}
	}
}