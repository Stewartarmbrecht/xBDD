namespace xBDD.Core.Test.Features.DefineScenarios.SampleCode
{
    public class AddAScenarioExplicitNameSample
    {
        public ScenarioBuilder WithExplicitName()
        {
            return xB.CurrentRun.AddScenario("My Explicit Scenario Name", this);
        }
    }
}
