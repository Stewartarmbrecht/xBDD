using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;

namespace xBDD.Test
{
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
