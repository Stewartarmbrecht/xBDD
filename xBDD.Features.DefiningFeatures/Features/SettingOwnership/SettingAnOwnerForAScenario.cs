namespace xBDD.Features.DefiningFeatures.SettingOwnership
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	public partial class SettingAnOwnerForAScenario: xBDDFeatureBase
	{

		[TestMethod]
		public async Task SettingASingleOwner()
		{
			await xB.AddScenario(this, 1000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task SettingMultipleOwners()
		{
			await xB.AddScenario(this, 2000)
				.Skip("Untested", Assert.Inconclusive);
		}

	}
}