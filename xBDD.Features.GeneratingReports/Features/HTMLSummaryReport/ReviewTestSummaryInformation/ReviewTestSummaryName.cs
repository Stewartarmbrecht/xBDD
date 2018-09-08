namespace xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestSummaryInformation
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	[Assignments("Stewart")]
	public partial class ReviewTestSummaryName: xBDDFeatureBase
	{
		xBDD.Browser.BrowserUser you = new xBDD.Browser.BrowserUser();
		(string Description, string FilePath) aPassingTestSummaryReport = (Description: "a passing test summary report", FilePath: ""); 

		[TestMethod]
		public async Task WithName()
		{
			await xB.AddScenario(this, 1000)
				.Given(you.NavigateTo(aPassingTestSummaryReport))
				.Then(you.WillSee("the test summary name", "report-name").HasText("My Sample - Test Summary 1 Passing"))
				.Skip("Committed", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithNoName()
		{
			await xB.AddScenario(this, 2000)
//				.Given(you.NavigateTo(aPassingTestSummaryReport))
//				.Then(you.WillSee(the.TestSummaryName).HasText("[Missing!]"))
				.Skip("Committed", Assert.Inconclusive);
		}

	}
}