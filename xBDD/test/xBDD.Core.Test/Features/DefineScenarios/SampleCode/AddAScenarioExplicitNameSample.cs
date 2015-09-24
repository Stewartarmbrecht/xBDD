namespace xBDD.Core.Test.Features.DefineScenarios.SampleCode
{
    public class AddAScenarioExplicitNameSample
    {
        public Scenario WithExplicitName()
        {
            return xBDD.CurrentRun.AddScenario("My Explicit Scenario Name", this);
        }
    }
}
