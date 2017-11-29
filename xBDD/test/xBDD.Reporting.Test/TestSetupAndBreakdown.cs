using Microsoft.VisualStudio.TestTools.UnitTesting;
using xBDD;
using xBDD.Browser;

namespace xBDD.Reporting.Test
{
    [TestClass]
    public class TestSetupAndBreakdown
    {
        [AssemblyCleanup()]
        public static void TestRunComplete()
        {
            //xB.CurrentRun.SaveToDatabase();
            WebDriver.Close();
        }
    }
}
