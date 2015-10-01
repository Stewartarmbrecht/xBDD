namespace xBDD.Core.Test.Features.DefineScenarios.SampleCode
{
    public class AddAnAndStep
    {
        public ScenarioBuilder Add()
        {
            return xBDD.CurrentRun
                .AddScenario(this)
                .Given(xBDD.CreateStep("my starting condition", (s) => { /*my action here*/ }))
                .When(xBDD.CreateStep("my action", (s) => { /*my action here*/ }))
                .Then(xBDD.CreateStep("my ending condition", (s) => { /*my validation here*/ }))
                .And(xBDD.CreateStep("my extra ending condition", (s) => { /*my extra validation here*/ }));
        }
    }
}
