namespace MySample.Features.TestRun1Passing
{
    using xBDD;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;


    public class FeatureTestClass: IFeature, IOutputWriter
    {
        public IOutputWriter OutputWriter { get { return this; } }

        public void WriteLine(string text) {
            text = text.Replace("{", "{{").Replace("}","}}");
            Logger.LogMessage(text);
        }
    }
}
