namespace xBDD.Features.GettingStarted
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Browser;
	using xBDD.Features.Actors;

	[TestClass]
	[AsA(Developer.Name)]
	[YouCan("include (document) scenarios that are not ready to run")]
	[By("calling the Skip method on the scenario instead of the Run method.")]
	public class SkippingAScenario: IFeature
	{
		private Developer you = new Developer();

		public IOutputWriter OutputWriter { get; private set; }

		public SkippingAScenario()
		{
			OutputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		[TestCategory("Long")]
		public async Task RunningASkippedScenario()
		{
			var codePath = "../Amazon.Features/SearchingProducts/SearchingAllProducts_Skipped.cs";
			var templateFilePath = "./GettingStarted/MSTestFirstSkippedScenarioOutputTemplate.txt";

			Wrapper<string> output = new Wrapper<string>();
			
			await xB.AddScenario(this, 2)
				.Given(you.HaveTheFollowingClass("that defines a skipped scenario", codePath))
				.When(you.RunTheMSTestProject("dotnet test --filter Name~SearchWithSearchButton_Skipped", "../../../../Amazon.Features/", output))
				.Then(you.WillSeeTheOutputMatches(templateFilePath,output))
				.Run();

		}
	}
}