namespace xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewFeatureInformation
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	public partial class ReviewFeatureScenarios: xBDDFeatureBase
	{

		[TestMethod]
		public async Task ExpandingScenarios()
		{
			await xB.AddScenario(this, 1000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task CollapsingScenarios()
		{
			await xB.AddScenario(this, 2000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithNoScenarios()
		{
			await xB.AddScenario(this, 3000)
				.Skip("Untested", Assert.Inconclusive);
		}

	}
}