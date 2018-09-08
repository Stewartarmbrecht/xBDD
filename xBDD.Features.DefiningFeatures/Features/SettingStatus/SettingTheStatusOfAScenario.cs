namespace xBDD.Features.DefiningFeatures.SettingStatus
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	public partial class SettingTheStatusOfAScenario: xBDDFeatureBase
	{

		[TestMethod]
		public async Task ToDefining()
		{
			await xB.AddScenario(this, 1000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task ToReady()
		{
			await xB.AddScenario(this, 2000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task ToCommitted()
		{
			await xB.AddScenario(this, 3000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task ToUntested()
		{
			await xB.AddScenario(this, 4000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task ToFailing()
		{
			await xB.AddScenario(this, 5000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task ToBlocked()
		{
			await xB.AddScenario(this, 6000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task ToFixing()
		{
			await xB.AddScenario(this, 7000)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task ToBuilt()
		{
			await xB.AddScenario(this, 8000)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task ToDeployed()
		{
			await xB.AddScenario(this, 9000)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task ToExecuting()
		{
			await xB.AddScenario(this, 10000)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task ToDeprecated()
		{
			await xB.AddScenario(this, 11000)
				.Skip("Defining", Assert.Inconclusive);
		}

	}
}