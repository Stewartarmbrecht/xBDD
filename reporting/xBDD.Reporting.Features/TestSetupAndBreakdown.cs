using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using xBDD;

[assembly: TestRunName("xBDD Reporting")]

namespace xBDD.Reporting.Features
{
    [TestClass]
    public class TestSetupAndBreakdown
    {

        [AssemblyInitialize]
        public static void TestRunStart(TestContext context)
        {
            //System.Environment.SetEnvironmentVariable("xBDD:Browser:Watch","true");
            System.Environment.SetEnvironmentVariable("xBDD:Browser:Watch","false");
        }
        [AssemblyCleanup()]
        public async static Task TestRunComplete()
        {
            await xBDD.Test.TestPublisher.PublishResults("xBDD - Reporting - Features - ");
        }
    }
}
