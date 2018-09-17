namespace xBDD.Features.GeneratingReports.JSONTestRunReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	public partial class GenerateAJsonReportWithCapabilityScenarios: xBDDFeatureBase
	{

		[TestMethod]
		public async Task WithFullCapability()
		{
			await xB.AddScenario(this, 1000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithCapabilityNameClipping()
		{
			await xB.AddScenario(this, 2000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithCapabilityNameEmpty()
		{
			await xB.AddScenario(this, 3000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithCapabilityExplanationEmpty()
		{
			await xB.AddScenario(this, 4000)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithNoFeatures()
		{
			await xB.AddScenario(this, 5000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithFeatures()
		{
			await xB.AddScenario(this, 6000)
				.Skip("Untested", Assert.Inconclusive);
		}

	}
}