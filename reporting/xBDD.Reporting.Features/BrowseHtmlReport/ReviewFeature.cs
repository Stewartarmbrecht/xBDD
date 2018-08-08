
namespace xBDD.Reporting.Features.BrowseHtmlReport
{
	using xBDD.Test;
	using xBDD.Browser;
	using xBDD.Reporting.Features.Pages.HtmlReportPage;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using xBDD.Reporting.Features.Steps;
	using System.Threading.Tasks;

    [TestClass]
	public class ReviewFeature
	{
        private User you = new User();
        private HtmlReport the = new Pages.HtmlReportPage.HtmlReport();
        private ReportLocations theHtmlReport = new Pages.HtmlReportPage.ReportLocations();

		private readonly TestContextWriter outputWriter;

		public ReviewFeature()
		{
			outputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		public async Task Passing()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.AddScenario(this)
                .Given(AnHtmlReport.WithASinglePassingScenario())
                .When(you.NavigateTo(theHtmlReport.WithASinglePassingScenario))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.Then(you.WillSee(the.Feature.Name(1)).HasText("My Feature 1"))
				.And(you.WillSee(the.Feature.BadgeGreen(1)).IsVisible())
				.And(you.WillSee(the.Feature.Scenarios(1)).IsNotVisible().Because("none were failing"))
                .Run();
		}
		[TestMethod]
		public async Task Skipped()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.AddScenario(this)
                .Given(AnHtmlReport.WithASingleSkippedScenario())
                .When(you.NavigateTo(theHtmlReport.WithASingleSkippedScenario))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.Then(you.WillSee(the.Feature.Name(1)).HasText("My Feature 1"))
				.And(you.WillSee(the.Feature.BadgeYellow(1)).IsVisible())
				.And(you.WillSee(the.Feature.Scenarios(1)).IsNotVisible().Because("none were failing"))
                .Run();
		}
		[TestMethod]
		public async Task Failing()
		{
            WebBrowser browser = new WebBrowser(WebDriver.Current);
            await xB.CurrentRun.AddScenario(this)
                .Given(AnHtmlReport.WithASingleFailedScenario())
                .When(you.NavigateTo(theHtmlReport.WithASingleFailedScenario))
				.Then(you.WillSee(the.Feature.BadgeRed(1)).IsVisible())
				.And(you.WillSee(the.Feature.Scenarios(1)).IsVisible())
                .Run();
		}
	}
}