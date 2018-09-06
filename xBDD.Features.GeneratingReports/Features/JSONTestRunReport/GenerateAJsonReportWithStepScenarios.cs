namespace xBDD.Features.GeneratingReports.JSONTestRunReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	public partial class GenerateAJsonReportWithStepScenarios: xBDDFeatureBase
	{

		[TestMethod]
		public async Task WithFullStep()
		{
			await xB.AddScenario(this, 1000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithStepNameEmpty()
		{
			await xB.AddScenario(this, 2000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithStepExplanationEmpty()
		{
			await xB.AddScenario(this, 3000)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithStepInputEmpty()
		{
			await xB.AddScenario(this, 4000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithStepOutputEmpty()
		{
			await xB.AddScenario(this, 5000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithStepException()
		{
			await xB.AddScenario(this, 6000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithStepInnerException()
		{
			await xB.AddScenario(this, 7000)
				.Skip("Untested", Assert.Inconclusive);
		}

	}
}