namespace xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestRunInformation
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	public partial class ReviewTestRunExplanation: xBDDFeatureBase
	{

		[TestMethod]
		public async Task ExpandingExplanation()
		{
			await xB.AddScenario(this, 1000)
				.Skip("Committed", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task CollapsingExplanation()
		{
			await xB.AddScenario(this, 2000)
				.Skip("Committed", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithoutExplanation()
		{
			await xB.AddScenario(this, 3000)
				.Skip("Committed", Assert.Inconclusive);
		}

	}
}