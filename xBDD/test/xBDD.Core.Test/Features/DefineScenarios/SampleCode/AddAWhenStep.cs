namespace xBDD.Core.Test.Features.DefineScenarios.SampleCode
{
    public class AddAWhenStep
    {
        public ScenarioBuilder Add()
        {
            return xBDD.CurrentRun
                .AddScenario(this)
                .Given(xBDD.CreateStep("my starting condition", (s) => { /*my setup here*/ }))
                .When(xBDD.CreateStep("my action", (s) => { /*my action here*/ }));
        }
    }
}
