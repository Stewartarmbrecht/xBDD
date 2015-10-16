using xBDD.xUnit;
using Xunit;
using Xunit.Abstractions;

namespace xBDD.Core.Test.Features.OverrideNames
{
    [Collection("xBDDCoreTest")]
    public class OverrideScenarioName
    {
        private readonly OutputWriter outputWriter;

        public OverrideScenarioName(ITestOutputHelper output)
        {
            outputWriter = new OutputWriter(output);
        }

        [ScenarioFact]
        public void WhenAdding()
        {
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void WithAnAttribute()
        {
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
    }
}
