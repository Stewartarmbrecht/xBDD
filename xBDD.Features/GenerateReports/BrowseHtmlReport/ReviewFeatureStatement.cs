namespace xBDD.Features.GenerateReports.BrowseHtmlReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Threading.Tasks;
	using xBDD.Features.Actors;
	using xBDD.Features.Pages;

	[AsA("Developer")]
	[YouCan("understand more detail about a feature")]
	[By("reviewing the feature statement")]
    [TestClass]
	public class ReviewFeatureStatement: FeatureTestClass
	{
        private HtmlReportUser you = new HtmlReportUser();
        private HtmlReportPageModel the = new HtmlReportPageModel();
        		
		[TestMethod]
		public async Task CollapsedByDefault()
		{
            await xB.AddScenario(this, 1)
				.When(you.NavigateTo(the.HtmlReport.FromAPassingTestRun))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.Then(you.WillSee(the.Feature.Statement(1)).IsNotVisible().Because("the statement is collapsed by default."))
                .Run();
		}
		
		[TestMethod]
		public async Task Expand()
		{
            await xB.AddScenario(this, 2)
				.When(you.NavigateTo(the.HtmlReport.FromAPassingTestRun))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.And(you.ClickWhen(the.Feature.StatementLink(1)).IsVisible())
				.Then(you.WillSee(the.Feature.Statement(1)).IsVisible())
                .Run();
		}
		
		[TestMethod]
		public async Task Collapse()
		{
            await xB.AddScenario(this, 2)
				.When(you.NavigateTo(the.HtmlReport.FromAPassingTestRun))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.And(you.ClickWhen(the.Feature.StatementLink(1)).IsVisible(-1, true))
				.And(you.WaitTill(the.Feature.Statement(1)).IsVisible(-1, true))
				.And(you.Wait(250))
				.When(you.Click(the.Feature.StatementLink(1)))
				.Then(you.WillSee(the.Feature.Statement(1)).IsNotVisible(-1, true))
                .Run();
		}
		[TestMethod]
		public async Task ExpandAll()
		{
			 await xB.CurrentRun.AddScenario(this, 4)
				.Skip("Definig", Assert.Inconclusive);
		}
		[TestMethod]
		public async Task CollapseAll()
		{
			 await xB.CurrentRun.AddScenario(this, 5)
				.Skip("Definig", Assert.Inconclusive);
		}
		[TestMethod]
		public async Task FullStatement()
		{
			string featureStatement = $"As a sample user{System.Environment.NewLine}You can have my feature 1 value{System.Environment.NewLine}By execute my feature 1";
            await xB.CurrentRun.AddScenario(this, 6)
                .When(you.NavigateTo(the.HtmlReport.FromAPassingTestRun))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.And(you.ClickWhen(the.Feature.StatementLink(1)).IsVisible())
				.Then(you.WillSee(the.Feature.Statement(1)).IsVisible())
				.And(you.WillSee(the.Feature.Statement(1)).HasText(featureStatement))
                .Run();
		}
		[TestMethod]
		public async Task PartialStatement()
		{
			string featureStatement = $"As a [Missing!]{System.Environment.NewLine}You can have my feature 2 value{System.Environment.NewLine}By [Missing!]";
            await xB.CurrentRun.AddScenario(this, 7)
                .When(you.NavigateTo(the.HtmlReport.FromAPassingTestRun))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.And(you.ClickWhen(the.Feature.StatementLink(2)).IsVisible())
				.Then(you.WillSee(the.Feature.Statement(2)).IsVisible())
				.And(you.WillSee(the.Feature.Statement(2)).HasText(featureStatement))
                .Run();
		}
		[TestMethod]
		public async Task NoStatement()
		{
            await xB.CurrentRun.AddScenario(this, 8)
                .When(you.NavigateTo(the.HtmlReport.FromAPassingTestRun))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(3,1)).IsVisible())
				.Then(you.WillSee(the.Scenario.Name(7,3)).IsVisible())
				.And(you.WillSee(the.Feature.Statement(3)).IsNotThere())
				.And(you.WillSee(the.Feature.StatementLink(3)).IsNotThere())
                .Run();
		}
	}
}