namespace xBDD.Core.Test.Features.DefineScenarios.SampleCode
{
    public class AddAnAndStep
    {
        public Scenario Add()
        {
            return xBDD.CurrentRun
                .AddScenario(this)
                .Given(xBDD.CreateStep("my starting condition", () => { /*my action here*/ }))
                .When(xBDD.CreateStep("my action", () => { /*my action here*/ }))
                .Then(xBDD.CreateStep("my ending condition", () => { /*my validation here*/ }))
                .And(xBDD.CreateStep("my extra ending condition", () => { /*my extra validation here*/ }));
        }
    }
}
