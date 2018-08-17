namespace xBDD.Features.GettingStarted
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using xBDD.Features;
    using xBDD.Features.Actors;

	[TestClass]
	[AsA(Developer.Name)]
	[YouCan("add a scenario that only creates documentation and does not run any code")]
	[By("calling the Document method on the scenario")]
	public class UsingAScenarioToCreateDocumentation: FeatureTestClass
	{
		private Developer you = new Developer();

		[TestMethod]
		[TestCategory("Long")]
		public async Task RunningADocumentationScenario()
		{
			var codePath = "../Amazon.Features/TestEnvironmentSetup/ContinuousIntegration.cs";
			var templateFilePath = "./GettingStarted/MSTestFirstDocumentationScenarioOutputTemplate.txt";

			Wrapper<string> output = new Wrapper<string>();
			
			await xB.AddScenario(this, 2)
				.Given(you.HaveTheFollowingClass("that executes a documentation scenario", codePath))
				.When(you.RunTheMSTestProject("dotnet test -v n --filter Name~PassingCheckIn", "../../../../Amazon.Features/", output))
				.Then(you.WillSeeTheOutputMatches(templateFilePath,output))
				.Run();

		}
	}
}