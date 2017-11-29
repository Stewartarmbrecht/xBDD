using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Threading.Tasks;

namespace xBDD.Test
{
    [TestClass]
    public class TestContextWriter : IOutputWriter
    {
        public TestContextWriter()
        {
        }

        public void WriteLine(string text)
        {
            text = text.Replace("{","{{").Replace("}","}}");
            Logger.LogMessage(text);
        }

        [AssemblyCleanup()]
        public async static Task WriteHtmlResults() 
        {
            var directory = System.IO.Directory.GetCurrentDirectory();
            var path = directory + $"{System.IO.Path.DirectorySeparatorChar}xBDD.Test.Results.html";
            var htmlReport = await xB.CurrentRun.TestRun.WriteToHtml();
            Logger.LogMessage("Writing Html Report to " + path);
            File.WriteAllText(path, htmlReport);
        }
    }
}
