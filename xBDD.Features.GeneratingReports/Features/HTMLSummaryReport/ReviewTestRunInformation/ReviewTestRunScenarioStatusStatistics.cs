namespace xBDD.Features.GeneratingReports.HTMLSummaryReport.ReviewTestRunInformation
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	public partial class ReviewTestRunScenarioStatusStatistics: xBDDFeatureBase
	{

		[TestMethod]
		public async Task Expanding()
		{
			await xB.AddScenario(this, 1000)
				.Skip("Committed", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task Collapsing()
		{
			await xB.AddScenario(this, 2000)
				.Skip("Committed", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAllPassing()
		{
			await xB.AddScenario(this, 3000)
				.Skip("Committed", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithSomeSkipped()
		{
			await xB.AddScenario(this, 4000)
				.Skip("Committed", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithSomeFailing()
		{
			await xB.AddScenario(this, 5000)
				.Skip("Committed", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithSomeSkippedAndSomeFailing()
		{
			await xB.AddScenario(this, 6000)
				.Skip("Committed", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAllSkipped()
		{
			await xB.AddScenario(this, 7000)
				.Skip("Committed", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAllFailing()
		{
			await xB.AddScenario(this, 8000)
				.Skip("Committed", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithNoScenarios()
		{
			await xB.AddScenario(this, 9000)
				.Skip("Committed", Assert.Inconclusive);
		}

	}
}