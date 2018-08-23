
namespace xBDD.Features.ImportingScenarios.ImportingScenariosImportingFromATextOutline
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class FromATextOutlineWithGeneralScenarios: FeatureTestClass
    {

        [TestMethod]
        public async Task WithSimpleOutline()
        {
            await xB.CurrentRun.AddScenario(this, 4)
                .Skip("With Simple Outline", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAnEmptyFile()
        {
            await xB.CurrentRun.AddScenario(this, 5)
                .Skip("With an Empty File", Assert.Inconclusive);
        }
    }
}

