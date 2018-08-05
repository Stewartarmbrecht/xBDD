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
    }
}
