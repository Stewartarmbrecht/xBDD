namespace xBDD.Features.GenerateReports.BrowseHtmlReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Threading.Tasks;
	using xBDD.Features.Actors;
	using xBDD.Features.Pages;

    [TestClass]
	[AsA("test results reviewer")]
	[YouCan("review area features")]
	[By("clicking on the area name to expand and collapse the area's feature list")]
	public class ReviewAreaFeatures: xBDDFeatureBase
	{
        private HtmlReportUser you = new HtmlReportUser();
        private HtmlReportPageModel the = new HtmlReportPageModel();

        [TestMethod]
        public async Task Expand()
		{
            await xB.AddScenario(this, 1)
                .When(you.NavigateTo(the.HtmlReport.FromAFailedTestRun))
                .And(you.WaitTill(the.Area.Name(1)).IsVisible())
                .And(you.Click(the.Area.Name(1)))
                .Then(you.WillSee(the.Area.Features(1)).IsVisible())
                .Run();
		}

        [TestMethod]
        public async Task ExpandAll()
		{
            await xB.AddScenario(this, 2)
                .When(you.NavigateTo(the.HtmlReport.FromAFailedTestRun))
                .And(you.WaitTill(the.Area.Name(1)).IsVisible())
                .And(you.Click(the.Menu.ExpandAllAreasLink))
                .Then(you.WillSee(the.Area.Features(1)).IsVisible())
                .And(you.WillSee(the.Area.Features(2)).IsVisible())
                .Run();
		}

		[TestMethod]
		public async Task Collapse()
		{
            await xB.AddScenario(this, 3)
                .When(you.NavigateTo(the.HtmlReport.FromAFailedTestRun))
                .And(you.WaitTill(the.Area.Name(1)).IsVisible())
                .And(you.Click(the.Menu.ExpandAllAreasLink))
                .And(you.WaitTill(the.Area.Features(1)).IsVisible())
                .And(you.Click(the.Area.Name(1)))
                .Then(you.WillSee(the.Area.Features(1)).IsNotThere())
                .Run();
		}

        [TestMethod]
        public async Task CollapseAll()
		{
            await xB.AddScenario(this, 4)
				.Given(you.GenerateAReportWithAPassingFullTestRun())
                .When(you.NavigateTo(the.HtmlReport.FromAFailedTestRun))
                .And(you.WaitTill(the.Area.Name(1)).IsVisible())
                .And(you.Click(the.Menu.ExpandAllAreasLink))
                .And(you.WaitTill(the.Area.Features(1)).IsVisible())
                .And(you.WaitTill(the.Area.Features(2)).IsVisible())
                .And(you.Click(the.Menu.CollapseAllAreasLink))
                .And(you.WaitTill(the.Area.Features(1)).IsNotVisible())
                .And(you.WaitTill(the.Area.Features(2)).IsNotVisible())
				.Skip("Not Implemented", Assert.Inconclusive);
		}

	}
}
