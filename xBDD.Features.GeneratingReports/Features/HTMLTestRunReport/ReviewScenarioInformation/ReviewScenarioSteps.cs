namespace xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewScenarioInformation
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	public partial class ReviewScenarioSteps: xBDDFeatureBase
	{

		[TestMethod]
		public async Task ExpandingSteps()
		{
			await xB.AddScenario(this, 1000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task CollapsingSteps()
		{
			await xB.AddScenario(this, 2000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithNoSteps()
		{
			await xB.AddScenario(this, 3000)
				.Skip("Untested", Assert.Inconclusive);
		}

	}
}