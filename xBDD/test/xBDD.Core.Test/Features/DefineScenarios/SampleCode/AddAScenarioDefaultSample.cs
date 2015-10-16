namespace xBDD.Core.Test.Features.DefineScenarios.SampleCode
{
    public class AddAScenarioDefaultSample
    {
        public ScenarioBuilder DefaultScenarioAdd()
        {
            return xB.CurrentRun.AddScenario(this);
        }
    }
}
