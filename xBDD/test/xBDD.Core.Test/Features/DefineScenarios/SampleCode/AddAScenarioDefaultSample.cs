namespace xBDD.Core.Test.Features.DefineScenarios.SampleCode
{
    public class AddAScenarioDefaultSample
    {
        public Scenario DefaultScenarioAdd()
        {
            return xBDD.CurrentRun.AddScenario(this);
        }
    }
}
