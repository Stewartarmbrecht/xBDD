namespace xBDD.Core.Test.Features.DefineScenarios.SampleCode
{
    public class AddAnAndStep
    {
        public ScenarioBuilder Add()
        {
            return xB.CurrentRun
                .AddScenario(this)
                .Given(xB.CreateStep("my starting condition", (s) => { /*my action here*/ }))
                .When(xB.CreateStep("my action", (s) => { /*my action here*/ }))
                .Then(xB.CreateStep("my ending condition", (s) => { /*my validation here*/ }))
                .And(xB.CreateStep("my extra ending condition", (s) => { /*my extra validation here*/ }));
        }
    }
}
