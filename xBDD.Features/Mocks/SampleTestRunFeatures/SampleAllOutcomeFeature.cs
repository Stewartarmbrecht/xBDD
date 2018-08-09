namespace SampleApp.Features.SampleTestRunFeatures
{
	using xBDD;
	using xBDD.Features.Steps;
	using System.Threading.Tasks;

	[AsA("actor")]
	[YouCan("get value")]
	[By("executing a feature")]
	public class SampleAllOutcomeFeature
	{
		private xBDDMock xBM;
		public SampleAllOutcomeFeature(xBDDMock xBM)
		{
			this.xBM = xBM;
		}
		
		public async Task PassingScenario()
		{
			 await xBM.CurrentRun.AddScenario(this, 1)
			 	.Given("Step 1", s => {})
				.When("Step 2", s => {})
				.Then("Step 3", s => {})
				.Run();
		}
		public async Task SkippedScenario()
		{
			 await xBM.CurrentRun.AddScenario(this, 2)
			 	.Given("Step 1", s => {})
				.When("Step 2", s => {})
				.Then("Step 3", s => {})
				.Skip("Not implemented");
		}
		public async Task FailedScenario()
		{
			 await xBM.CurrentRun.AddScenario(this, 3)
			 	.Given("Step 1", s => {})
				.When("Step 2", s => {
					throw new System.Exception("Generic Exception");
				})
				.Then("Step 3", s => {})
				.Run();
		}
	}
}