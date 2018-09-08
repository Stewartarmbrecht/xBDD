namespace xBDD.Features.DefiningFeatures.DefiningSteps
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	public partial class SharingValuesBetweenSteps: xBDDFeatureBase
	{

		[TestMethod]
		public async Task ObjectRefereneces()
		{
			await xB.AddScenario(this, 1000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task LiteralValues()
		{
			await xB.AddScenario(this, 2000)
				.Skip("Untested", Assert.Inconclusive);
		}

	}
}