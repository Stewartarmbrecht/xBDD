
namespace xBDD.Features
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using xBDD;
    using xBDD.Browser;

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
			xB.Complete(new xBDDSorting(), (message) => { Logger.LogMessage(message); });
            xB.CurrentRun.TestRun.WriteToCode("xBDD.Features", "./Code/", "xBDD - Features - ");
        }
    }
}
