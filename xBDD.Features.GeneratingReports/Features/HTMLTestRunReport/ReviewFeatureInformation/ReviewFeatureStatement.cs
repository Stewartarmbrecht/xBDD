namespace xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewFeatureInformation
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	public partial class ReviewFeatureStatement: xBDDFeatureBase
	{

		[TestMethod]
		public async Task ExpandingFeatureStatement()
		{
			await xB.AddScenario(this, 1000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task CollapsingFeatureStatement()
		{
			await xB.AddScenario(this, 2000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithFullStatement()
		{
			await xB.AddScenario(this, 3000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithMissingParts()
		{
			await xB.AddScenario(this, 4000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithoutStatement()
		{
			await xB.AddScenario(this, 5000)
				.Skip("Untested", Assert.Inconclusive);
		}

	}
}