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
			 	.Given(you.GenerateAnHtmlReportUsingATestRunThatIsNotSorted())
				.When(you.NavigateTo(the.HtmlReport.ThatIsNotSorted))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(1,1)).IsVisible())
				.Then(you.WillSee(the.Feature.Name(1,1)).HasText("Sample All Outcome Feature").Because("it was the first feature alphabetically"))
				.And(you.WillSee(the.Scenario.Name(1,1)).HasText("Failed Scenario").Because("it is the first scenario alphabetically"))
				.Run();
		}
		[TestMethod]
		public async Task Sorted()
		{
			 await xB.AddScenario(this, 2)
			 	.Given(you.GenerateAnHtmlReportUsingATestRunThatIsSorted())
				.When(you.NavigateTo(the.HtmlReport.ThatIsSorted))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(1,1)).IsVisible())
				.Then(you.WillSee(the.Feature.Name(1,1)).HasText("Sample Passing Feature",-1, true).Because("it was the first in the feature sort"))
				.And(you.WillSee(the.Scenario.Name(1,1)).HasText("Passing Scenario3",-1, true).Because("it is the first in the feature class definition"))
				.Run();
		}
		[TestMethod]
		public async Task PartiallySorted()
		{
			 await xB.AddScenario(this, 2)
			 	.Given(you.GenerateAnHtmlReportUsingATestRunThatIsSorted())
				.When(you.NavigateTo(the.HtmlReport.ThatIsSorted))
				.And(you.ClickWhen(the.Area.Name(1)).IsVisible())
				.And(you.ClickWhen(the.Feature.Name(2,1)).IsVisible())
				.Then(you.WillSee(the.Feature.Name(2,1)).HasText("Sample Skipped Feature",-1, true).Because("it was the second in the feature sort"))
				.And(you.WillSee(the.Scenario.Name(6,2)).HasText("Passing Scenario2",-1, true).Because("it was not provided a sort when the scenario was created and was placed after the sorted scenarios"))
				.Run();
		}
	}
}