using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;

namespace xBDD.Features
{
    public class TestContextWriter : IOutputWriter
    {
        public void WriteLine(string text)
        {
            text = text.Replace("{", "{{").Replace("}","}}");
            Logger.LogMessage(text);
        }
    }
}
