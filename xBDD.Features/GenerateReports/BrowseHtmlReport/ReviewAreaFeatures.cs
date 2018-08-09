namespace xBDD.Features.GenerateReports.BrowseHtmlReport
{
	using xBDD;
	using xBDD.Features;
	using xBDD.Browser;
	using xBDD.Features.Steps;
    using xBDD.Features.Pages.HtmlReportPage;
	using System.Threading.Tasks;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
	[AsA("test results reviewer")]
	[YouCan("review area features")]
	[By("clicking on the area name to expand and collapse the area's feature list")]
	public class ReviewAreaFeatures
	{
		private readonly TestContextWriter outputWriter;
        private User you = new User();
        private Area the = new Pages.HtmlReportPage.Area();
        private ReportLocations theHtmlReport = new Pages.HtmlReportPage.ReportLocations();


		public ReviewAreaFeatures()
		{
			outputWriter = new TestContextWriter();
		}

        [TestMethod]
        public async Task Expand()
		{
            await xB.AddScenario(this)
				.Given(AnHtmlReport.WithAPassingFullTestRun())
                .When(you.NavigateTo(theHtmlReport.WithAPassingFullTestRun))
                .And(you.WaitTill(the.FirstAreaName).IsVisible(5000))
                .And(you.Click(the.FirstAreaName))
                .Then(you.WillSee(the.FirstAreasFeatureListNotExpandingOrCollapsing).IsVisible(2000))
                .Run();
		}

        [TestMethod]
        public async Task ExpandAll()
		{
            await xB.AddScenario(this)
				.Given(AnHtmlReport.WithAPassingFullTestRun())
                .When(you.NavigateTo(theHtmlReport.WithAPassingFullTestRun))
                .And(you.WaitTill(the.FirstAreaName).IsVisible(5000))
                .And(you.Click(the.MenuButton,1000))
                .And(you.Click(the.ExpandAllAreasLink,1000))
                .Then(you.WillSee(the.FirstAreasFeatureListNotExpandingOrCollapsing).IsVisible(2000))
                .And(you.WillSee(the.SecondAreasFeatureListNotExpandingOrCollapsing).IsVisible(2000))
                .Run();
		}

		[TestMethod]
		public async Task Collapse()
		{
            await xB.AddScenario(this)
				.Given(AnHtmlReport.WithAPassingFullTestRun())
                .When(you.NavigateTo(theHtmlReport.WithAPassingFullTestRun))
                .And(you.WaitTill(the.FirstAreaName).IsVisible(5000))
                .And(you.Click(the.MenuButton))
                .And(you.Click(the.ExpandAllAreasLink))
                .And(you.WaitTill(the.FirstAreasFeatureListNotExpandingOrCollapsing).IsVisible(2000))
                .And(you.Click(the.FirstAreaName))
                .Then(you.WillSee(the.FirstAreasFeatureListNotExpandingOrCollapsing).IsNotVisible(1000))
                .Run();
		}

        [TestMethod]
        public async Task CollapseAll()
		{
            await xB.AddScenario(this)
				.Given(AnHtmlReport.WithAPassingFullTestRun())
                .When(you.NavigateTo(theHtmlReport.WithAPassingFullTestRun))
                .And(you.WaitTill(the.FirstAreaName).IsVisible(5000))
                .And(you.Click(the.MenuButton))
                .And(you.Click(the.ExpandAllAreasLink))
                .And(you.WaitTill(the.FirstAreasFeatureListNotExpandingOrCollapsing).IsVisible(2000))
                .And(you.WaitTill(the.SecondAreasFeatureListNotExpandingOrCollapsing).IsVisible(2000))
                .And(you.Click(the.CollapseAllAreasLink))
                .Then(you.WillSee(the.FirstAreasFeatureListNotExpandingOrCollapsing).IsNotVisible(2000))
                .And(you.WillSee(the.SecondAreasFeatureListNotExpandingOrCollapsing).IsNotVisible(2000))
                .Skip("Not Implemented");
		}

	}
}
