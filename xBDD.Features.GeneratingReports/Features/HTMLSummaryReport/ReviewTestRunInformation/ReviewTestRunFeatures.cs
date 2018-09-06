namespace xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestRunInformation
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	public partial class ReviewTestRunFeatures: xBDDFeatureBase
	{

		[TestMethod]
		public async Task ExpandingFeatures()
		{
			await xB.AddScenario(this, 1000)
				.Skip("Committed", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task CollapsingFeatures()
		{
			await xB.AddScenario(this, 2000)
				.Skip("Committed", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithoutFeatures()
		{
			await xB.AddScenario(this, 3000)
				.Skip("Committed", Assert.Inconclusive);
		}

	}
}