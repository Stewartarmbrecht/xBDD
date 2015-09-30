namespace xBDD.Core.Test.Features.DefineScenarios.SampleCode
{
    public class AddAScenarioExplicitNameSample
    {
        public ScenarioBuilder WithExplicitName()
        {
            return xBDD.CurrentRun.AddScenario("My Explicit Scenario Name", this);
        }
    }
}
