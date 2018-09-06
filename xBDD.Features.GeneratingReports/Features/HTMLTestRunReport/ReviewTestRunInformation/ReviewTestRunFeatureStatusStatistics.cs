namespace xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewTestRunInformation
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	public partial class ReviewTestRunFeatureStatusStatistics: xBDDFeatureBase
	{

		[TestMethod]
		public async Task WithAllPassing()
		{
			await xB.AddScenario(this, 1000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithSomeSkipped()
		{
			await xB.AddScenario(this, 2000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithSomeFailing()
		{
			await xB.AddScenario(this, 3000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithSomeSkippedAndSomeFailing()
		{
			await xB.AddScenario(this, 4000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAllSkipped()
		{
			await xB.AddScenario(this, 5000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAllFailing()
		{
			await xB.AddScenario(this, 6000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithNoFeatures()
		{
			await xB.AddScenario(this, 7000)
				.Skip("Untested", Assert.Inconclusive);
		}

	}
}