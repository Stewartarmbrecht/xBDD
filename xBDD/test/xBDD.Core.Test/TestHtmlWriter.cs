using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Threading.Tasks;

namespace xBDD.Core.Test
{
    [TestClass]
    public class TestHtmlWriter
    {
        public TestHtmlWriter()
        {
        }

        [AssemblyCleanup()]
        public async static Task WriteHtmlResults() 
        {
            var directory = System.IO.Directory.GetCurrentDirectory();
            var path = directory + $"{System.IO.Path.DirectorySeparatorChar}xBDD.Core.Test.Results.html";
            var htmlReport = await xB.CurrentRun.TestRun.WriteToHtml();
            Logger.LogMessage("Writing Html Report to " + path);
            File.WriteAllText(path, htmlReport);
        }
    }
}
