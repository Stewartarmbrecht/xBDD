namespace MySample.Features
{
    using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
    using xBDD;

    public class TestContextWriter : IOutputWriter
    {
        public void WriteLine(string text)
        {
            text = text.Replace("{", "{{").Replace("}","}}");
            Logger.LogMessage(text);
        }
    }
}