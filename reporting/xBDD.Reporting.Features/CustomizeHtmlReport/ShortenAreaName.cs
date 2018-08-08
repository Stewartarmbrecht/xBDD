namespace xBDD.Reporting.Features.CustomizeHtmlReport
{
	using xBDD.Test;
	using xBDD.Browser;
	using xBDD.Reporting.Features.Pages.HtmlReportPage;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using xBDD.Reporting.Features.Steps;
	using System.Threading.Tasks;

    [TestClass]
	[AsA("Developer")]
	[By("shorten the area name by removing the beginning of the name that matches a provided string")]
	[YouCan("shorten the area name in the Html report.")]
	public class ShortenAreaName
	{
        private User you = new User();
        private HtmlReport the = new Pages.HtmlReportPage.HtmlReport();
        private ReportLocations theHtmlReport = new Pages.HtmlReportPage.ReportLocations();

		private readonly TestContextWriter outputWriter;

		public ShortenAreaName()
		{
			outputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		public async Task MatchesStartOfAreaName()
		{
            await xB.AddScenario(this)
                .Given(AnHtmlReport.WithASinglePassingScenario(null,null,null,"My "))
				.And("you set the HTML writer was set to skip 'My ' when writing the area name", (s) => {})
                .When(you.NavigateTo(theHtmlReport.WithASinglePassingScenario))
				.Then(you.WillSee(the.Area.Name(1)).IsVisible())
				.And(you.WillSee(the.Area.Name(1)).HasText("Area 1"))
                .Run();
		}
		[TestMethod]
		public async Task MatchesNoneOfAreaName()
		{
            await xB.AddScenario(this)
                .Given(AnHtmlReport.WithASinglePassingScenario(null,null,null,"No Match"))
				.And("you set the HTML writer was set to skip 'No Match' when writing the area name", (s) => {})
                .When(you.NavigateTo(theHtmlReport.WithASinglePassingScenario))
				.Then(you.WillSee(the.Area.Name(1)).IsVisible())
				.And(you.WillSee(the.Area.Name(1)).HasText("My Area 1"))
                .Run();
		}
		[TestMethod]
		public async Task MatchesAllOfAreaName()
		{
            await xB.AddScenario(this)
                .Given(AnHtmlReport.WithASinglePassingScenario(null,null,null,"My Area 1"))
				.And("you set the HTML writer was set to skip 'My Area 1' when writing the area name", (s) => {})
                .When(you.NavigateTo(theHtmlReport.WithASinglePassingScenario))
				.Then(you.WillSee(the.Area.Name(1)).IsVisible())
				.And(you.WillSee(the.Area.Name(1)).HasText("[Missing! (or Full Name Skipped)]"))
                .Run();
		}
	}
}