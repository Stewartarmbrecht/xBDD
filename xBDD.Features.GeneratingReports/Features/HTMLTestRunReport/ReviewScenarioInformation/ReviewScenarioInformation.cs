namespace xBDD.Features.GeneratingReports.HTMLTestRunReport.ReviewScenarioInformation
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	public partial class ReviewScenarioInformation: xBDDFeatureBase
	{

		[TestMethod]
		public async Task WithName()
		{
			await xB.AddScenario(this, 1000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithNoName()
		{
			await xB.AddScenario(this, 2000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithSingleAssignments()
		{
			await xB.AddScenario(this, 3000)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithMultipleAssignments()
		{
			await xB.AddScenario(this, 4000)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithSingleTag()
		{
			await xB.AddScenario(this, 5000)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithMultipleTags()
		{
			await xB.AddScenario(this, 6000)
				.Skip("Defining", Assert.Inconclusive);
		}

	}
}