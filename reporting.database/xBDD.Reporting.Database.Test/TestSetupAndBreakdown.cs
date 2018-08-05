using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using xBDD;

[assembly: TestRunName("xBDD Reporting Database")]

namespace xBDD.Core.Test
{
    [TestClass]
    public class TestSetupAndBreakdown
    {
        [AssemblyCleanup()]
        public async static Task TestRunComplete()
        {
            await xBDD.Test.TestPublisher.PublishResults("xBDD - Reporting - Database - Test - Features - ");
        }
    }
}
