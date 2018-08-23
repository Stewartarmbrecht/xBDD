
namespace xBDD.Features.DefiningFeatures.InitialSetup
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class GeneratingANewProject: FeatureTestClass
    {

        [TestMethod]
        public async Task GeneratingAnMSTestProject()
        {
            await xB.CurrentRun.AddScenario(this, 4)
                .Given("you have the latest version of dotnet core installed", (s) => {  })
                .And("you open bash, powershell, or a command window", (s) => {  })
                .And("you Install the dotnet-xbdd tools:", (s) => {  })
                .And("you create a folder for your test project and navigate to the folder", (s) => {  })
                .Given(" a new test project using the installed xbdd tools:", (s) => {  })
                .Given("and run the new test project", (s) => {  })
                .Skip("Untested", Assert.Inconclusive);
        }
    }
}

