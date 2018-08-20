namespace xBDD.Features.GenerateCode
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Threading.Tasks;
	using xBDD.Features.Actors;
	using xBDD.Features.Pages;

    [TestClass]
    [AsA(Developer.Name)]
    [YouCan("generate a functioning test project from test run results")]
    [By("calling the WriteAllCode method on the TestRun object.")]
    public class GenerateProjectFilesFromTestRunResults: FeatureTestClass
    {
        Developer you = new Developer();

        [TestMethod]
        public async Task StandardFullReport()
        {
            await xB.CurrentRun.AddScenario(this, 1)
                .Given(you.HaveATestProjectThatProducesAllOutcomes())
                .And(you.HaveTheFollowingTestSetupAndBreakdownClass("that includes the line to generate code"))
                .And("you include this line of code:", 
                    (s) => { }, 
                    "xBDD.CurrentRun.WriteToCode(\"MySample.Features\", \"./Code/\", \"My Sample - Features - \")", 
                    TextFormat.cs)
                .When(you.ExecuteTheTestRun())
                .Then("the following files will be generated.", (s) => { 
                 })
                .Run();
        }
    }    
}