
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
    public class FollowA300Response: FeatureTestClass
    {

        [TestMethod]
        public async Task Placeholder()
        {
            await xB.CurrentRun.AddScenario(this, 21)
                .Skip("Defining", Assert.Inconclusive);
        }
    }
}

