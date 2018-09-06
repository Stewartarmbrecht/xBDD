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

		[TestMethod]
		public async Task WithName()
		{
			await xB.AddScenario(this, 1000)
//				.Given(you.NavigateTo(aPassingTestSummaryReport))
//				.Then(you.WillSee(the.TestSummaryName).HasText("My Sample - Test Summary 1 Passing"))
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