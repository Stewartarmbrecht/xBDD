
namespace xBDD.Features
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
    using xBDD;

    [TestClass]
    public class TestSetupAndBreakdown
    {

        [AssemblyInitialize]
        public static void TestRunStart(TestContext context)
        {
            xB.Initialize();
        }
        [AssemblyCleanup()]
        public static void TestRunComplete()
        {
			xB.Complete("xBDD.Features", new xBDDSorting(), (message) => { Logger.LogMessage(message); });
            xB.CurrentRun.TestRun.WriteToCode("xBDD.Features", "./Code/", "xBDD - Features - ");
        }
    }
}
