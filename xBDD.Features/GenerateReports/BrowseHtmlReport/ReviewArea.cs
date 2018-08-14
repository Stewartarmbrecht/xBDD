namespace xBDD.Features.GenerateReports.BrowseHtmlReport
{
	using xBDD.Features;
	using xBDD.Browser;
	using xBDD.Features.Steps;
	using xBDD.Features.Pages.HtmlReportPage;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Threading.Tasks;
	using System;

    [TestClass]
	//  [Description("In order to understand how functionality is organized")]
	//  [Description("As a report reviewer")]
	//  [Description("I would like to view the areas in the html report")]
	public class ReviewArea
	{
		private readonly TestContextWriter outputWriter;

        private User you = new User();
        private Area the = new Pages.HtmlReportPage.Area();
        private ReportLocations theHtmlReport = new Pages.HtmlReportPage.ReportLocations();

		public ReviewArea()
		{
			outputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		public async Task Passing()
		{
            await xB.AddScenario(this, 1)
                .Given(AnHtmlReport.WithASinglePassingScenario())
                .When(you.NavigateTo(theHtmlReport.WithASinglePassingScenario))
				.Then(you.WillSee(the.Name(1)).HasText("My Area 1"))
				.And(you.WillSee(the.BadgeGreen(1)).IsVisible())
				.And(you.WillSee(the.Duration(1)).IsVisible())
				.And(you.WillSee(the.FirstAreasFeatureListNotExpandingOrCollapsing).IsNotVisible().Because(" the area is not failing"))
                .Run();
		}
		[TestMethod]
		public async Task Skipped()
		{
            await xB.AddScenario(this, 2)
                .Given(AnHtmlReport.WithASingleSkippedScenario())
                .When(you.NavigateTo(theHtmlReport.WithASingleSkippedScenario))
				.Then(you.WillSee(the.FirstAreaName).HasText("My Area 1"))
				.And(you.WillSee(the.FirstAreaYellowBadge).IsVisible())
				.And(you.WillSee(the.FirstAreasFeatureListNotExpandingOrCollapsing).IsNotVisible().Because(" the area is not failing"))
                .Run();
		}
		[TestMethod]
		public async Task Failing()
		{
            await xB.AddScenario(this, 3)
                .Given(AnHtmlReport.WithASingleFailedScenario())
                .When(you.NavigateTo(theHtmlReport.WithASingleFailedScenario))
				.Then(you.WillSee(the.FirstAreaName).HasText("My Area 1"))
				.And(you.WillSee(the.FirstAreaRedBadge).IsVisible())
				.And(you.WillSee(the.FirstAreasFeatureListNotExpandingOrCollapsing).IsNotVisible().Because(" the area is failing but the Failures Only option was not set to true"))
                .Run();
		}
	}
}