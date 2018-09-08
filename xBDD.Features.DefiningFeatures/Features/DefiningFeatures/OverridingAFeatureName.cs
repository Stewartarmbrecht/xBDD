namespace xBDD.Features.DefiningFeatures.DefiningFeatures
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	public partial class OverridingAFeatureName: xBDDFeatureBase
	{

		[TestMethod]
		public async Task WhenAddingAScenario()
		{
			await xB.AddScenario(this, 1000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task ViaAnAttribute()
		{
			await xB.AddScenario(this, 2000)
				.Skip("Untested", Assert.Inconclusive);
		}

	}
}