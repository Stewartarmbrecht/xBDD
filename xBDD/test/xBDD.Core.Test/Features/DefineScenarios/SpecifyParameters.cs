using xBDD.xUnit;
using Xunit.Abstractions;

namespace xBDD.Core.Test.Features.DefineScenarios
{
    public class SpecifyParameters
    {
        private readonly OutputWriter outputWriter;

        public SpecifyParameters(ITestOutputHelper output)
        {
            outputWriter = new OutputWriter(output);
        }

        [ScenarioFact]
        public void InlineWithTypedState()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void InlineWithDynamicState()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void MultilineParameter()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void TableParameter()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
    }
}
