using Xunit.Abstractions;

namespace xBDD.Test.Features.ShareState
{
    public class UseTypedState : Feature
    {
        public UseTypedState(ITestOutputHelper outputWriter)
            : base(outputWriter)
        {

        }
        [ScenarioFact]
        public void Sync()
        {
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void Async()
        {
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
    }
}
