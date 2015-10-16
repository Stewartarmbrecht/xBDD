namespace xBDD.Core.Test.Features.DefineScenarios.SampleCode
{
    public class AddAGivenStepWithNoAction
    {
        public ScenarioBuilder Add()
        {
            return xB.CurrentRun
                .AddScenario(this)
                .Given(xB.CreateStep("my starting condition that needs no action"));
        }
    }
}
