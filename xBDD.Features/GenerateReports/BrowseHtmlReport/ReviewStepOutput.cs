namespace xBDD.Features.GenerateReports.BrowseHtmlReport
{
	using xBDD.Features;
	using xBDD.Browser;
	using xBDD.Features.Pages.HtmlReportPage;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using xBDD.Features.Steps;
	using System.Threading.Tasks;

    [TestClass]
	public class ReviewStepOutput
	{
        private User you = new User();
        private HtmlReport the = new Pages.HtmlReportPage.HtmlReport();
        private ReportLocations theHtmlReport = new Pages.HtmlReportPage.ReportLocations();

		private readonly TestContextWriter outputWriter;

		public ReviewStepOutput()
		{
			outputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		public async Task CollapsedByDefault()
		{
			var output = $"Here{System.Environment.NewLine} is{System.Environment.NewLine} my{System.Environment.NewLine} output!";
			var format = TextFormat.text;
            await xB.AddScenario(this, 1)
                .Given(AnHtmlReport.WithAStepWithOutput(output, format))
				.When(you.NavigateTo(theHtmlReport.WithAStepWithOutput))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(1,1)).IsVisible())
				.And(you.ClickWhen(the.Scenario.Name(1,1)).IsVisible())
				.Then(you.WillSee(the.Output.Link(1)).IsVisible())
                .Run();
		}
		
		[TestMethod]
		public async Task GeneralText()
		{
			var output = $"Here{System.Environment.NewLine} is{System.Environment.NewLine} my{System.Environment.NewLine} output!";
			var format = TextFormat.text;
            await xB.AddScenario(this, 2)
                .Given(AnHtmlReport.WithAStepWithOutput(output, format))
				.When(you.NavigateTo(theHtmlReport.WithAStepWithOutput))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(1,1)).IsVisible())
				.And(you.ClickWhen(the.Scenario.Name(1,1)).IsVisible())
				.And(you.ClickWhen(the.Output.Link(1)).IsVisible())
				.Then(you.WillSee(the.Output.Section(1)).IsVisible())
				.And(you.WillSee(the.Output.Text(1)).HasText(output))
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