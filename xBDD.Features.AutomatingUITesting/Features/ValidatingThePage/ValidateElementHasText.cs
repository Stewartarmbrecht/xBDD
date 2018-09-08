namespace xBDD.Features.AutomatingUITesting.ValidatingThePage
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	public partial class ValidateElementHasText: xBDDFeatureBase
	{

		[TestMethod]
		public async Task WithSuccess()
		{
			await xB.AddScenario(this, 1000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithCustomStepName()
		{
			await xB.AddScenario(this, 2000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithSpecificWaitTime()
		{
			await xB.AddScenario(this, 3000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithPageCapturedAsOutput()
		{
			await xB.AddScenario(this, 4000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithElementScreenshotCapturedAsOutput()
		{
			await xB.AddScenario(this, 5000)
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task WithFailure()
		{
			await xB.AddScenario(this, 6000)
				.Skip("Untested", Assert.Inconclusive);
		}

	}
}