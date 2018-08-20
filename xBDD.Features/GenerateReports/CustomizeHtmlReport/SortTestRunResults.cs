namespace xBDD.Features.GenerateReports.CustomizeHtmlReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Threading.Tasks;
	using xBDD.Features.Actors;
	using xBDD.Features.Pages;

    [TestClass]
	[AsA("Developer")]
	[YouCan("control the order test results are rendered")]
	[By("calling the SortTestRunResults method on the test run: 'xB.CurrentRun.SortTestRunResults' before running the html report")]
	public class SortTestRunResults: FeatureTestClass
	{
        private HtmlReportUser you = new HtmlReportUser();
        private HtmlReportPageModel the = new HtmlReportPageModel();
		
		[TestMethod]
		public async Task NotSorted()
		{
			 await xB.AddScenario(this, 1)
				.When(you.NavigateTo(the.HtmlReport.FromAFailedUnsortedTestRun))
				.And(you.ClickWhen(the.Area.Name(6)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(13,6)).IsVisible())
				.Then(you.WillSee(the.Feature.Name(13,6)).HasText("My Feature 12 Third").Because("it was the first feature alphabetically"))
				.And(you.WillSee(the.Scenario.Name(33,13)).HasText("My Scenario 30 Unsorted 38 Sorted").Because("it is the first scenario alphabetically"))
				.Run();
		}
		[TestMethod]
		public async Task Sorted()
		{
			 await xB.AddScenario(this, 2)
				.When(you.NavigateTo(the.HtmlReport.FromAFailedFullySortedTestRun))
				.And(you.ClickWhen(the.Area.Name(6)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(13,6)).IsVisible())
				.Then(you.WillSee(the.Feature.Name(13,6)).HasText("My Feature 13 First").Because("it was sorted to be first"))
				.And(you.WillSee(the.Scenario.Name(33,13)).HasText("My Scenario 35 Unsorted 30 Sorted").Because("it is the first scenario sorted"))
				.Run();
		}
		[TestMethod]
		public async Task PartiallySorted()
		{
			 await xB.AddScenario(this, 2)
				.When(you.NavigateTo(the.HtmlReport.FromAFailedTestRun))
				.And(you.ClickWhen(the.Area.Name(9)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(19,9)).IsVisible())
				.Then(you.WillSee(the.Feature.Name(19,9)).HasText("My Feature 0 Unsorted",-1, true).Because("it was the second in the feature sort"))
				.And(you.WillSee(the.Scenario.Name(45,19)).HasText("My Scenario 0 Unsorted",-1, true).Because("it was not provided a sort when the scenario was created and was placed after the sorted scenarios"))
				.Run();
		}
	}
}