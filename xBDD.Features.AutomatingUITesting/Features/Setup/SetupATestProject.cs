namespace xBDD.Features.AutomatingUITesting.Setup
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	public partial class SetupATestProject: xBDDFeatureBase
	{

		[TestMethod]
		public async Task ToUseNewBrowserSessionsForEachScenario()
		{
			await xB.AddScenario(this, 1000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task ToUseTheSameBrowserSessionForAllScenarios()
		{
			await xB.AddScenario(this, 2000)
				.Skip("Untested", Assert.Inconclusive);
		}

	}
}