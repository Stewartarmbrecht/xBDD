namespace xBDD.Features.DefiningFeatures.SettingStatus
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	public partial class SettingTheStatusOfAFeature: xBDDFeatureBase
	{

		[TestMethod]
		public async Task ToDefining()
		{
			await xB.AddScenario(this, 1000)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task ToReady()
		{
			await xB.AddScenario(this, 2000)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task ToBuilding()
		{
			await xB.AddScenario(this, 3000)
				.Skip("Defining", Assert.Inconclusive);
		}

	}
}