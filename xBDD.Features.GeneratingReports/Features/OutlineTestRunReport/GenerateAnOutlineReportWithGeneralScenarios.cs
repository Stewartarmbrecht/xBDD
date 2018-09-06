namespace xBDD.Features.GeneratingReports.OutlineTestRunReport
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	public partial class GenerateAnOutlineReportWithGeneralScenarios: xBDDFeatureBase
	{

		[TestMethod]
		public async Task WithFullTestRun()
		{
			await xB.AddScenario(this, 1000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithEmptyTestRun()
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

		[TestMethod]
		public async Task WithNoTestsInTheProject()
		{
			await xB.AddScenario(this, 4000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithTestFiltering()
		{
			await xB.AddScenario(this, 5000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithXBDDTestRunFiltering()
		{
			await xB.AddScenario(this, 6000)
				.Skip("Defining", Assert.Inconclusive);
		}

	}
}