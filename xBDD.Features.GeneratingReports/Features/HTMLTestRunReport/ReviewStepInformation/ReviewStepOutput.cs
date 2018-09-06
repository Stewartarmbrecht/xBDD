namespace xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewStepInformation
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	public partial class ReviewStepOutput: xBDDFeatureBase
	{

		[TestMethod]
		public async Task ExpandingOutput()
		{
			await xB.AddScenario(this, 1000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task CollapsingOutput()
		{
			await xB.AddScenario(this, 2000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithoutOutput()
		{
			await xB.AddScenario(this, 3000)
				.Skip("Untested", Assert.Inconclusive);
		}

	}
}