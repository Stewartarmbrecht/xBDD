using Xunit.Abstractions;

namespace xBDD.xUnit
{
    public class OutputWriter : IOutputWriter
    {
        ITestOutputHelper testOutputHelper;
        public OutputWriter(ITestOutputHelper outputHelper)
        {
            this.testOutputHelper = outputHelper;
        }
        public void WriteLine(string text)
        {
            testOutputHelper.WriteLine(text);
        }
    }
}
