namespace xBDD.Core.Test.Features.DefineScenarios.SampleCode
{
    public class AddAWhenStep
    {
        public Scenario Add()
        {
            return xBDD.CurrentRun
                .AddScenario(this)
                .Given(xBDD.CreateStep("my starting condition", () => { /*my setup here*/ }))
                .When(xBDD.CreateStep("my action", () => { /*my action here*/ }));
        }
    }
}
