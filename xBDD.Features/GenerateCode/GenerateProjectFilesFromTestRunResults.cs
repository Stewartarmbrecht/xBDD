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
            var xBDDMock = new xBDDMock();
            await xB.CurrentRun.AddScenario(this, 1)
                .Given(you.ExecuteATestRunWithAFullTestRunWithAllOutcomes(xBDDMock))
                .WhenAsync("you execute the following code:", async (s) => { 
                    await xBDDMock.CurrentRun.TestRun.WriteToCode("","./FullTestRunWithAllOutcomesCode/","");
                 }, "xBDD.CurrentRun.WriteToCode(\"\", \"./FullTestRunWithAllOutcomesCode/\")", TextFormat.sh)
                .Then("the following files will be generated.", (s) => { 
                 })
                .Run();
        }
    }    
}