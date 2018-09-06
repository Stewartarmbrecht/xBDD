namespace xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestRunInformation
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	public partial class ReviewTestRunName: xBDDFeatureBase
	{

		[TestMethod]
		public async Task WithName()
		{
			await xB.AddScenario(this, 1000)
				.Skip("Committed", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithNoName()
		{
			await xB.AddScenario(this, 2000)
				.Skip("Committed", Assert.Inconclusive);
		}

	}
}