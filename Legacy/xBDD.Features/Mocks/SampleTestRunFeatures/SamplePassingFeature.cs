namespace SampleApp.Features.SampleTestRunFeatures
{
	using xBDD;
	using System.Threading.Tasks;

	[AsA("actor")]
	[YouCan("get value")]
	[By("executing a feature")]
	public class SamplePassingFeature
	{
		private xBDDMock xBM;
		public SamplePassingFeature(xBDDMock xBM)
		{
			this.xBM = xBM;
		}
		
		public async Task PassingScenario3()
		{
			 await xBM.CurrentRun.AddScenario(this, 1)
			 	.Given("Step 1", s => {})
				.When("Step 2", s => {})
				.Then("Step 3", s => {})
				.Run();
		}
		public async Task PassingScenario2()
		{
			 await xBM.CurrentRun.AddScenario(this, 2)
			 	.Given("Step 1", s => {})
				.When("Step 2", s => {})
				.Then("Step 3", s => {})
				.Run();
		}
		public async Task PassingScenario1()
		{
			 await xBM.CurrentRun.AddScenario(this, 3)
			 	.Given("Step 1", s => {})
				.When("Step 2", s => {})
				.Then("Step 3", s => {})
				.Run();
		}
	}
}