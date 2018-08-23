
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
    public class IssueAPost: FeatureTestClass
    {

        [TestMethod]
        public async Task Placeholder()
        {
            await xB.CurrentRun.AddScenario(this, 6)
                .Skip("Defining", Assert.Inconclusive);
        }
    }
}

