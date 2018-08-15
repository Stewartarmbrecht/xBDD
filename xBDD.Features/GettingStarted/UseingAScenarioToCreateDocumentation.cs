namespace xBDD.Features.GettingStarted
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Threading.Tasks;
	using xBDD;
	using xBDD.Browser;

	[TestClass]
	[AsA("developer")]
	[YouCan("add a scenario that only creates documentation and does not run any code")]
	[By("calling the Document method on the scenario")]
	public class UsingAScenarioToCreateDocumentation: IFeature
	{
		private User you = new User();

		public IOutputWriter OutputWriter { get; private set; }

		public UsingAScenarioToCreateDocumentation()
		{
			OutputWriter = new TestContextWriter();
		}
		
		[TestMethod]
		[TestCategory("Long")]
		public async Task RunningADocumentationScenario()
		{
			var codePath = "../Amazon.Features/TestEnvironmentSetup/ContinuousIntegration.cs";
			var templateFilePath = "./GettingStarted/MSTestFirstDocumentationScenarioOutputTemplate.txt";

			Wrapper<string> output = new Wrapper<string>();
			
			await xB.AddScenario(this, 2)
				.Given(You.CodeTheFollowingMSTestFeatureDefinition(codePath))
				.When(You.RunTheMSTestProject("dotnet test -v n --filter Name~PassingCheckIn", "../../../../Amazon.Features/", output))
				.Then(You.WillSeeTheOutputMatches(templateFilePath,output))
				.Run();

		}
	}
}