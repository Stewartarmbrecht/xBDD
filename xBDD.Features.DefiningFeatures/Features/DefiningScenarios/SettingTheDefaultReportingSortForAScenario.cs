namespace xBDD.Features.DefiningFeatures.DefiningScenarios
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	public partial class SettingTheDefaultReportingSortForAScenario: xBDDFeatureBase
	{

		[TestMethod]
		public async Task SettingTheSortOnAllScenarios()
		{
			await xB.AddScenario(this, 1000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task SettingTheSortOnNoneOfTheScenarios()
		{
			await xB.AddScenario(this, 2000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task SettingTheSortOnSomeOfTheScenarios()
		{
			await xB.AddScenario(this, 3000)
				.Skip("Untested", Assert.Inconclusive);
		}

	}
}