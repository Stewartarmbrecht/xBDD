using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;

namespace xBDD.Test
{
    public class TestContextWriter : IOutputWriter
    {
        public void WriteLine(string text)
        {
            Logger.LogMessage(text);
        }
    }
}
