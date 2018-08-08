namespace xBDD.Reporting.Features.BrowseHtmlReport
{
	using xBDD.Test;
	using xBDD.Browser;
	using xBDD.Reporting.Features.Pages.HtmlReportPage;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using xBDD.Reporting.Features.Steps;
	using System.Threading.Tasks;

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
		public async Task FullStatement()
		{
			string featureStatement = $"As a actor{System.Environment.NewLine}You can derive some value{System.Environment.NewLine}By perform some action";
            await xB.CurrentRun.AddScenario(this)
                .Given(AnHtmlReport.WithASinglePassingScenario("derive some value", "actor", "perform some action"))
                .When(you.NavigateTo(theHtmlReport.WithASinglePassingScenario))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.Then(you.WillSee(the.Feature.Statement(1)).IsVisible())
				.And(you.WillSee(the.Feature.Statement(1)).HasText(featureStatement))
                .Run();
		}
		[TestMethod]
		public async Task PartialStatement()
		{
			string featureStatement = $"As a [Missing!]{System.Environment.NewLine}You can derive some value{System.Environment.NewLine}By [Missing!]";
            await xB.CurrentRun.AddScenario(this)
                .Given(AnHtmlReport.WithASinglePassingScenario("derive some value"))
                .When(you.NavigateTo(theHtmlReport.WithASinglePassingScenario))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.Then(you.WillSee(the.Feature.Statement(1)).IsVisible())
				.And(you.WillSee(the.Feature.Statement(1)).HasText(featureStatement))
                .Run();
		}
		[TestMethod]
		public async Task NoStatement()
		{
            await xB.CurrentRun.AddScenario(this)
                .Given(AnHtmlReport.WithASinglePassingScenario())
                .When(you.NavigateTo(theHtmlReport.WithASinglePassingScenario))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(1)).IsVisible())
				.Then(you.WillSee(the.Scenario.Name(1)).IsVisible())
				.And(you.WillSee(the.Feature.Statement(1)).IsNotThere())
                .Run();
		}
	}
}