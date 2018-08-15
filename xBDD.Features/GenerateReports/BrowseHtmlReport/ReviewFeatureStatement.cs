namespace xBDD.Features.GenerateReports.BrowseHtmlReport
{
	using xBDD.Features;
	using xBDD.Browser;
	using xBDD.Features.Pages.HtmlReportPage;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using xBDD.Features.Steps;
	using System.Threading.Tasks;

	[AsA("Developer")]
	[YouCan("understand more detail about a feature")]
	[By("reviewing the feature statement")]
    [TestClass]
	public class ReviewFeatureStatement
	{
        private User you = new User();
        private HtmlReport the = new Pages.HtmlReportPage.HtmlReport();
        private ReportLocations theHtmlReport = new Pages.HtmlReportPage.ReportLocations();

		private readonly TestContextWriter outputWriter;

		public ReviewFeatureStatement()
		{
			outputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		public async Task CollapsedByDefault()
		{
            await xB.AddScenario(this, 1)
                .Given(AnHtmlReport.WithASinglePassingScenario("derive some value", "actor", "perform some action"))
				.When(you.NavigateTo(theHtmlReport.WithASinglePassingScenario))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.Then(you.WillSee(the.Feature.Statement(1)).IsNotVisible().Because("the statement is collapsed by default."))
                .Run();
		}
		
		[TestMethod]
		public async Task Expand()
		{
            await xB.AddScenario(this, 2)
                .Given(AnHtmlReport.WithASinglePassingScenario("derive some value", "actor", "perform some action"))
				.When(you.NavigateTo(theHtmlReport.WithASinglePassingScenario))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.And(you.ClickWhen(the.Feature.StatementLink(1)).IsVisible())
				.Then(you.WillSee(the.Feature.Statement(1)).IsVisible())
                .Run();
		}
		
		[TestMethod]
		public async Task Collapse()
		{
            await xB.AddScenario(this, 2)
                .Given(AnHtmlReport.WithASinglePassingScenario("derive some value", "actor", "perform some action"))
				.When(you.NavigateTo(theHtmlReport.WithASinglePassingScenario))
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
				.Skip("Not Started");
		}
		[TestMethod]
		public async Task CollapseAll()
		{
			 await xB.CurrentRun.AddScenario(this, 5)
				.Skip("Not Started");
		}
		[TestMethod]
		public async Task FullStatement()
		{
			string featureStatement = $"As a actor{System.Environment.NewLine}You can derive some value{System.Environment.NewLine}By perform some action";
            await xB.CurrentRun.AddScenario(this, 6)
                .Given(AnHtmlReport.WithASinglePassingScenario("derive some value", "actor", "perform some action"))
                .When(you.NavigateTo(theHtmlReport.WithASinglePassingScenario))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.And(you.ClickWhen(the.Feature.StatementLink(1)).IsVisible())
				.Then(you.WillSee(the.Feature.Statement(1)).IsVisible())
				.And(you.WillSee(the.Feature.Statement(1)).HasText(featureStatement))
                .Run();
		}
		[TestMethod]
		public async Task PartialStatement()
		{
			string featureStatement = $"As a [Missing!]{System.Environment.NewLine}You can derive some value{System.Environment.NewLine}By [Missing!]";
            await xB.CurrentRun.AddScenario(this, 7)
                .Given(AnHtmlReport.WithASinglePassingScenario("derive some value"))
                .When(you.NavigateTo(theHtmlReport.WithASinglePassingScenario))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.And(you.ClickWhen(the.Feature.StatementLink(1)).IsVisible())
				.Then(you.WillSee(the.Feature.Statement(1)).IsVisible())
				.And(you.WillSee(the.Feature.Statement(1)).HasText(featureStatement))
                .Run();
		}
		[TestMethod]
		public async Task NoStatement()
		{
            await xB.CurrentRun.AddScenario(this, 8)
                .Given(AnHtmlReport.WithASinglePassingScenario())
                .When(you.NavigateTo(theHtmlReport.WithASinglePassingScenario))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(1,1)).IsVisible())
				.Then(you.WillSee(the.Scenario.Name(1,1)).IsVisible())
				.And(you.WillSee(the.Feature.Statement(1)).IsNotThere())
				.And(you.WillSee(the.Feature.StatementLink(1)).IsNotThere())
                .Run();
		}
	}
}