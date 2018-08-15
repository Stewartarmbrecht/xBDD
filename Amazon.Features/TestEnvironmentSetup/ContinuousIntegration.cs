namespace Amazon.Features.SearchingProducts
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Threading.Tasks;
    using xBDD;
    using xBDD.Browser;

	[TestClass]
	[AsA("developer")]
	[YouCan("verify that your code changes did not cause a regression")]
	[By("using the continuous integration pipeline")]
	public class ContinuousIntegration: IFeature
	{
		private User you = new User();
		public IOutputWriter OutputWriter { get; private set; }

		public ContinuousIntegration()
		{
			OutputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		public async Task PassingCheckIn()
		{
			await xB.AddScenario(this)
				.Given("you have made a code change")
				.When("you check in the change")
				.Then("the build server will build and run all tests")
				.Document();
		}
	}
}