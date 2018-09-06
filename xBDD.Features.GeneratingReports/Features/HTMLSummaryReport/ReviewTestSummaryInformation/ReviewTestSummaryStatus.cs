namespace xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestSummaryInformation
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	[Assignments("Stewart")]
	public partial class ReviewTestSummaryStatus: xBDDFeatureBase
	{

		[TestMethod]
		public async Task WithPassingStatus()
		{
			await xB.AddScenario(this, 1000)
				.Skip("Committed", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithSomeSkippedStatus()
		{
			await xB.AddScenario(this, 2000)
				.Skip("Committed", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithSomeFailingStatus()
		{
			await xB.AddScenario(this, 3000)
				.Skip("Committed", Assert.Inconclusive);
		}

	}
}