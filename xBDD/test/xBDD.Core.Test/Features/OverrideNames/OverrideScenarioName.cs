using xBDD.xUnit;
using Xunit.Abstractions;

namespace xBDD.Core.Test.Features.OverrideNames
{
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
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void WithAnAttribute()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
    }
}
