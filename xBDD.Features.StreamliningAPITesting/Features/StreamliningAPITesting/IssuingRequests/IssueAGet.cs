
namespace xBDD.Features.StreamliningAPITesting.StreamliningAPITesting.IssuingRequests
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
	using System.Threading.Tasks;
	using xBDD;

    [TestClass]
    [AsA("")]
    [YouCan("")]
    [By("")]
    public class IssueAGet: FeatureTestClass
    {

        [TestMethod]
        public async Task Placeholder()
        {
            await xB.CurrentRun.AddScenario(this, 4)
                .Skip("Defining", Assert.Inconclusive);
        }
    }
}

