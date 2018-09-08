namespace xBDD.Features.DefiningFeatures.SettingIds
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	public partial class SettingAnIDForAFeature: xBDDFeatureBase
	{

		[TestMethod]
		public async Task ViaAnAttribute()
		{
			await xB.AddScenario(this, 1000)
				.Skip("Defining", Assert.Inconclusive);
		}

	}
}