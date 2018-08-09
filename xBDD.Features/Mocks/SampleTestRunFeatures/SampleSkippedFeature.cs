namespace SampleApp.Features.SampleTestRunFeatures
{
	using xBDD;
	using System.Threading.Tasks;

	[AsA("actor")]
	[YouCan("get value")]
	[By("executing a feature")]
	public class SampleSkippedFeature
	{
		private xBDDMock xBM;
		public SampleSkippedFeature(xBDDMock xBM)
		{
			this.xBM = xBM;
		}
		
		public async Task PassingScenario1()
		{
			 await xBM.CurrentRun.AddScenario(this, 1)
			 	.Given("Step 1", s => {})
				.When("Step 2", s => {})
				.Then("Step 3", s => {})
				.Run();
		}
		public async Task PassingScenario2()
		{
			 await xBM.CurrentRun.AddScenario(this)
			 	.Given("Step 1", s => {})
				.When("Step 2", s => {})
				.Then("Step 3", s => {})
				.Run();
		}
		public async Task SkippedScenario()
		{
			 await xBM.CurrentRun.AddScenario(this, 3)
			 	.Given("Step 1", s => {})
				.When("Step 2", s => {})
				.Then("Step 3", s => {})
				.Skip("No reason");
		}
	}
}