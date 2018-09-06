namespace MySample.Features.TestRun5SkippedDefining.Area4SkippedReady
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	public partial class Feature3SkippedCommitted: xBDDFeatureBase
	{

		[TestMethod]
		public async Task Scenario1Passing()
		{
			await xB.AddScenario(this, 1000)
				.Given("Step 1 Passing",
					(s) => { 
						// Enter your code here.
					})
				.When("Step 2 Passing",
					(s) => { 
						// Enter your code here.
					})
				.Then("Step 3 Passing",
					(s) => { 
						// Enter your code here.
					})
				.Skip("Defining", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task Scenario2SkippedUntested()
		{
			await xB.AddScenario(this, 2000)
				.Skip("Untested", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task Scenario3SkippedCommitted()
		{
			await xB.AddScenario(this, 3000)
				.Given("Step 1 Skipped",
					(s) => { 
						// Enter your code here.
					})
				.When("Step 2 Skipped",
					(s) => { 
						// Enter your code here.
					})
				.Then("Step 3 Skipped",
					(s) => { 
						// Enter your code here.
					})
				.Skip("Committed", Assert.Inconclusive);
		}

	}
}