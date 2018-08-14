namespace xBDD.Features.GenerateReports.CustomizeHtmlReport
{
	using xBDD.Features;
	using xBDD.Browser;
	using xBDD.Features.Pages.HtmlReportPage;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using xBDD.Features.Steps;
	using System.Threading.Tasks;

    [TestClass]
	[AsA("Developer")]
	[YouCan("control the order test results are rendered")]
	[By("calling the SortTestRunResults method on the test run: 'xB.CurrentRun.SortTestRunResults' before running the html report")]
	public class SortTestRunResults
	{
        private User you = new User();
        private HtmlReport the = new Pages.HtmlReportPage.HtmlReport();
        private ReportLocations theHtmlReport = new Pages.HtmlReportPage.ReportLocations();

		private readonly TestContextWriter outputWriter;

		public SortTestRunResults()
		{
			outputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		public async Task NotSorted()
		{
			 await xB.AddScenario(this, 1)
			 	.Given(ASampleTestRun.ThatIsNotSorted())
				.When(you.NavigateTo(theHtmlReport.ThatIsNotSorted))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(1)).IsVisible())
				.Then(you.WillSee(the.Feature.Name(1)).HasText("Sample All Outcome Feature").Because("it was the first feature alphabetically"))
				.And(you.WillSee(the.Scenario.Name(1)).HasText("Failed Scenario").Because("it is the first scenario alphabetically"))
				.Run();
		}
		[TestMethod]
		public async Task Sorted()
		{
			 await xB.AddScenario(this, 2)
			 	.Given(ASampleTestRun.ThatIsSorted())
				.When(you.NavigateTo(theHtmlReport.ThatIsSorted))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(1)).IsVisible())
				.Then(you.WillSee(the.Feature.Name(1)).HasText("Sample Passing Feature",-1, true).Because("it was the first in the feature sort"))
				.And(you.WillSee(the.Scenario.Name(1)).HasText("Passing Scenario3",-1, true).Because("it is the first in the feature class definition"))
				.Run();
		}
		[TestMethod]
		public async Task PartiallySorted()
		{
			 await xB.AddScenario(this, 2)
			 	.Given(ASampleTestRun.ThatIsSorted())
				.When(you.NavigateTo(theHtmlReport.ThatIsSorted))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(2)).IsVisible())
				.Then(you.WillSee(the.Feature.Name(2)).HasText("Sample Skipped Feature",-1, true).Because("it was the second in the feature sort"))
				.And(you.WillSee(the.Scenario.Name(6)).HasText("Passing Scenario2",-1, true).Because("it was not provided a sort when the scenario was created and was placed after the sorted scenarios"))
				.Run();
		}
	}
}