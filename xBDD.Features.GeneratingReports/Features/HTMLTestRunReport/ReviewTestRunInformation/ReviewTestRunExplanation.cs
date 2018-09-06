namespace xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewTestRunInformation
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	[Assignments("Stewart")]
	public partial class ReviewTestRunExplanation: xBDDFeatureBase
	{

		[TestMethod]
		public async Task ExpandingTheExplanatio()
		{
			await xB.AddScenario(this, 1000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task CollapsingTheExplanation()
		{
			await xB.AddScenario(this, 2000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithNoExplanation()
		{
			await xB.AddScenario(this, 3000)
				.Skip("Untested", Assert.Inconclusive);
		}

	}
}