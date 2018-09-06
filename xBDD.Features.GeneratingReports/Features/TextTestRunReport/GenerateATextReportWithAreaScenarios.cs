namespace xBDD.Features.GeneratingReports.TextTestRunReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	public partial class GenerateATextReportWithAreaScenarios: xBDDFeatureBase
	{

		[TestMethod]
		public async Task WithFullArea()
		{
			await xB.AddScenario(this, 1000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAreaNameClipping()
		{
			await xB.AddScenario(this, 2000)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAreaNameEmpty()
		{
			await xB.AddScenario(this, 3000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithAreaExplanationEmpty()
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