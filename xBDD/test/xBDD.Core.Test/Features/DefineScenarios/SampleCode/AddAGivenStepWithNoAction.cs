namespace xBDD.Core.Test.Features.DefineScenarios.SampleCode
{
    public class AddAGivenStepWithNoAction
    {
        public Scenario Add()
        {
            return xBDD.CurrentRun
                .AddScenario(this)
                .Given(xBDD.CreateStep("my starting condition that needs no action"));
        }
    }
}
