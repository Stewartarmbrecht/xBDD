namespace xBDD.Features.DefiningFeatures.AddingTags
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	public partial class AddingTagsToACapability: xBDDFeatureBase
	{

		[TestMethod]
		public async Task ViaCode()
		{
			await xB.AddScenario(this, 1000)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task ViaAnAssemblyAttribute()
		{
			await xB.AddScenario(this, 2000)
				.Skip("Defining", Assert.Inconclusive);
		}

	}
}