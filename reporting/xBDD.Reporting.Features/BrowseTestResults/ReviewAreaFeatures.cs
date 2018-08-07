namespace xBDD.Reporting.Features.BrowseTestResults
{
	using xBDD;
	using xBDD.Test;
	using xBDD.Browser;
	using xBDD.Reporting.Test.Steps;
	using System.Threading.Tasks;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
	[AsA("test results reviewer")]
	[YouCan("review area features")]
	[By("clicking on the area name to expand and collapse the area's feature list")]
	public class ReviewAreaFeatures
	{
		private readonly TestContextWriter outputWriter;

		public ReviewAreaFeatures()
		{
			outputWriter = new TestContextWriter();
		}

        [TestMethod]
        public async Task Expand()
		{
            User you = new User();
			Pages the = new Pages();
            await xB.AddScenario(this)
				.Given(AnHtmlReport.OfAPassingFullTestRun())
                .When(you.NavigateTo(the.TestResults))
                .And(you.WaitTill(the.FirstAreaName).IsVisible(5000))
                .And(you.Click(the.FirstAreaName))
                .Then(you.WillSee(the.FirstAreasFeatureListNotExpandingOrCollapsing).IsVisible(2000))
                .Run();
		}

        [TestMethod]
        public async Task ExpandAll()
		{
            User you = new User();
			Pages the = new Pages();
            await xB.AddScenario(this)
				.Given(AnHtmlReport.OfAPassingFullTestRun())
                .When(you.NavigateTo(the.TestResults))
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
            User you = new User();
			Pages the = new Pages();
            await xB.AddScenario(this)
				.Given(AnHtmlReport.OfAPassingFullTestRun())
                .When(you.NavigateTo(the.TestResults))
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
            User you = new User();
			Pages the = new Pages();
            await xB.AddScenario(this)
				.Given(AnHtmlReport.OfAPassingFullTestRun())
                .When(you.NavigateTo(the.TestResults))
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
