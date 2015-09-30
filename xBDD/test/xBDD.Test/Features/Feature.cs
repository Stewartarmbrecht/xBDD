using Xunit.Abstractions;
using xBDD.xUnit;

namespace xBDD.Test.Features
{
    public class Feature
    {
        public readonly OutputWriter outputWriter;

        public Feature(ITestOutputHelper output)
        {
            outputWriter = new OutputWriter(output);
        }

    }
}
