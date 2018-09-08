namespace xBDD.Features.DefiningFeatures.DefiningScenarios
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	public partial class SettingAnOutputWriterForAScenario: xBDDFeatureBase
	{

		[TestMethod]
		public async Task WhenCreatingAScenario()
		{
			await xB.AddScenario(this, 1000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WhenCreatingAFeature()
		{
			await xB.AddScenario(this, 2000)
				.Skip("Untested", Assert.Inconclusive);
		}

	}
}