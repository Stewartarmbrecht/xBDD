
namespace xBDD.Features.StreamliningAPITesting.StreamliningAPITesting.ValidatingResponses
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class ProcessA200Response: FeatureTestClass
    {

        [TestMethod]
        public async Task WithAJSONResponse()
        {
            await xB.CurrentRun.AddScenario(this, 27)
                .Skip("Defining", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithAnXMLResponse()
        {
            await xB.CurrentRun.AddScenario(this, 28)
                .Skip("Defining", Assert.Inconclusive);
        }

        [TestMethod]
        public async Task WithATextResponse()
        {
            await xB.CurrentRun.AddScenario(this, 29)
                .Skip("Defining", Assert.Inconclusive);
        }
    }
}

