namespace xBDD.Features.RunningScenarios.InitialSetup
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	public partial class RunningMSTestProjectScenarios: xBDDFeatureBase
	{

		[TestMethod]
		public async Task RunningAllScenarios()
		{
			await xB.AddScenario(this, 1000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task RunningScenariosFilteredByMSTestTestCateogry()
		{
			await xB.AddScenario(this, 2000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task RunningScenariosFilteredByCapabilityName()
		{
			await xB.AddScenario(this, 3000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task RunningScenariosFilteredByFeatureName()
		{
			await xB.AddScenario(this, 4000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task RunningScenariosFilteredByScenarioName()
		{
			await xB.AddScenario(this, 5000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task RunningScenariosFilteredByAssignment()
		{
			await xB.AddScenario(this, 6000)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task RunningScenariosFilteredByTag()
		{
			await xB.AddScenario(this, 7000)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task RunningScenariosFilteredByReason()
		{
			await xB.AddScenario(this, 8000)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task RunningASingleScenario()
		{
			await xB.AddScenario(this, 9000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task DebuggingASingleScenario()
		{
			await xB.AddScenario(this, 10000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task DocumentingScenariosAndSkippingScenarioExecutionWhenRunningTests()
		{
			await xB.AddScenario(this, 11000)
				.Skip("Defining", Assert.Inconclusive);
		}

	}
}