using xBDD.xUnit;
using Xunit;
using Xunit.Abstractions;

namespace xBDD.Core.Test.Features.DefineScenarios
{
    [Collection("xBDDCoreTest")]
    public class OrganizeSteps
    {
        private readonly OutputWriter outputWriter;

        public OrganizeSteps(ITestOutputHelper output)
        {
            outputWriter = new OutputWriter(output);
        }

        [ScenarioFact]
        public void InAStepLibrary()
        {
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void InAStepLibrarySharedAcrossAreas()
        {
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
    }
}
