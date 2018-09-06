namespace xBDD.Features.GeneratingReports.JSONTestRunReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	public partial class GenerateAJsonReportWithScenarioScenarios: xBDDFeatureBase
	{

		[TestMethod]
		public async Task WithFullScenario()
		{
			await xB.AddScenario(this, 1000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithScenarioNameEmpty()
		{
			await xB.AddScenario(this, 2000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithScenarioExplanationEmpty()
		{
			await xB.AddScenario(this, 3000)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithNoSteps()
		{
			await xB.AddScenario(this, 4000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithSteps()
		{
			await xB.AddScenario(this, 5000)
				.Skip("Untested", Assert.Inconclusive);
		}

	}
}