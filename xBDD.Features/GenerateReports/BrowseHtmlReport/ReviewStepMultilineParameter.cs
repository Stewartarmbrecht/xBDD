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
			var input = $"Here{System.Environment.NewLine} is{System.Environment.NewLine} my{System.Environment.NewLine} input!";
			var format = TextFormat.text;
            await xB.AddScenario(this, 1)
                .Given(you.GenerateAReportWithAStepWithAMultilineParameter(input, format))
				.When(you.NavigateTo(the.HtmlReport.WithAStepWithAMultilineParameter))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(1,1)).IsVisible())
				.And(you.ClickWhen(the.Scenario.Name(1,1)).IsVisible())
				.Then(you.WillSee(the.Input.Link(1)).IsVisible())
                .Run();
		}
		
		[TestMethod]
		public async Task GeneralText()
		{
			var input = $"Here{System.Environment.NewLine} is{System.Environment.NewLine} my{System.Environment.NewLine} Input!";
			var format = TextFormat.text;
            await xB.AddScenario(this, 2)
                .Given(you.GenerateAReportWithAStepWithAMultilineParameter(input, format))
				.When(you.NavigateTo(the.HtmlReport.WithAStepWithAMultilineParameter))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(1,1)).IsVisible())
				.And(you.ClickWhen(the.Scenario.Name(1,1)).IsVisible())
				.And(you.ClickWhen(the.Input.Link(1)).IsVisible())
				.Then(you.WillSee(the.Input.Section(1)).IsVisible())
				.And(you.WillSee(the.Input.Text(1)).HasText(input))
                .Run();
		}
		
		[TestMethod]
		public async Task Code()
		{
            await xB.AddScenario(this, 3)
				.Skip("Not Started", Assert.Inconclusive);
		}
		
		[TestMethod]
		public async Task HtmlWithPreview()
		{
            await xB.AddScenario(this, 4)
				.Skip("Not Started", Assert.Inconclusive);
		}
		
		[TestMethod]
		public async Task Collapse()
		{
			 await xB.AddScenario(this, 5)
				.Skip("Not Started", Assert.Inconclusive);
		}
		[TestMethod]
		public async Task CollapseAll()
		{
			 await xB.AddScenario(this, 6)
				.Skip("Not Started", Assert.Inconclusive);
		}
		[TestMethod]
		public async Task Expand()
		{
			 await xB.AddScenario(this, 7)
				.Skip("Not Started", Assert.Inconclusive);
		}
		[TestMethod]
		public async Task ExpandAll()
		{
			 await xB.AddScenario(this, 8)
				.Skip("Not Started", Assert.Inconclusive);
		}
	}
}