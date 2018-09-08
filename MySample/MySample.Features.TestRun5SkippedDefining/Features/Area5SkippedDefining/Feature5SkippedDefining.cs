namespace MySample.Features.TestRun5SkippedDefining.Area5SkippedDefining
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	public partial class Feature5SkippedDefining: xBDDFeatureBase
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
				.Run();
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

		[TestMethod]
		public async Task Scenario4SkippedReady()
		{
			await xB.AddScenario(this, 4000)
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
				.Skip("Ready", Assert.Inconclusive);
		}

		[TestMethod]
		public async Task Scenario5SkippedDefining()
		{
			await xB.AddScenario(this, 5000)
				.Skip("Defining", Assert.Inconclusive);
		}

	}
}