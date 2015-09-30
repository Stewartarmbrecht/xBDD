namespace xBDD.Core.Test.Features.DefineScenarios.SampleCode
{
    public class AddAGivenStepWithNoAction
    {
        public ScenarioBuilder Add()
        {
            return xBDD.CurrentRun
                .AddScenario(this)
                .Given(xBDD.CreateStep("my starting condition that needs no action"));
        }
    }
}
