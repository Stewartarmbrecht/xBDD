namespace xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewFeatureInformation
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	public partial class ReviewFeatureExplanation: xBDDFeatureBase
	{

		[TestMethod]
		public async Task ExpandingExplanation()
		{
			await xB.AddScenario(this, 1000)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task CollapsingExplanation()
		{
			await xB.AddScenario(this, 2000)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithNoExplanation()
		{
			await xB.AddScenario(this, 3000)
				.Skip("Defining", Assert.Inconclusive);
		}

	}
}