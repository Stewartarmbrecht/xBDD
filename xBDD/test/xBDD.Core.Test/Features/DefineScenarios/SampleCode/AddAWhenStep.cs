namespace xBDD.Core.Test.Features.DefineScenarios.SampleCode
{
    public class AddAWhenStep
    {
        public ScenarioBuilder Add()
        {
            return xB.CurrentRun
                .AddScenario(this)
                .Given(xB.CreateStep("my starting condition", (s) => { /*my setup here*/ }))
                .When(xB.CreateStep("my action", (s) => { /*my action here*/ }));
        }
    }
}
