namespace xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestSummaryInformation
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[AsA("Test Results Reviewer")]
	[YouCan("view the explanation given for a test run")]
	[SoThat("you can understand the features included in the test run and how the solution is architected to provide the features")]
	[TestClass]
	[Assignments("Stewart")]
	public partial class ReviewTestSummaryExplanation: xBDDFeatureBase
	{

		[TestMethod]
		public async Task ExpandingTheExplanation()
		{
			await xB.AddScenario(this, 1000)
				.Skip("Committed", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task CollapsingTheExplanation()
		{
			await xB.AddScenario(this, 2000)
				.Skip("Committed", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithNoExplanation()
		{
			await xB.AddScenario(this, 3000)
				.Skip("Committed", Assert.Inconclusive);
		}

	}
}