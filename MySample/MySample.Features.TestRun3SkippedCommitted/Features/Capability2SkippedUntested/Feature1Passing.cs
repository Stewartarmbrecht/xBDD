namespace MySample.Features.TestRun3SkippedCommitted.Capability2SkippedUntested
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Utility;

	[TestClass]
	public partial class Feature1Passing: xBDDFeatureBase
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

	}
}