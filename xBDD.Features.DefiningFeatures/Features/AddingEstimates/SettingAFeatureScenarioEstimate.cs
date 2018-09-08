namespace xBDD.Features.DefiningFeatures.AddingEstimates
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	public partial class SettingAFeatureScenarioEstimate: xBDDFeatureBase
	{

		[TestMethod]
		public async Task Placeholder()
		{
			await xB.AddScenario(this, 1000)
				.Skip("Defining", Assert.Inconclusive);
		}

	}
}