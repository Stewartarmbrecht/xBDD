
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
    public class ProcessA500Response: FeatureTestClass
    {

        [TestMethod]
        public async Task Placeholder()
        {
            await xB.CurrentRun.AddScenario(this, 23)
                .Skip("Defining", Assert.Inconclusive);
        }
    }
}

