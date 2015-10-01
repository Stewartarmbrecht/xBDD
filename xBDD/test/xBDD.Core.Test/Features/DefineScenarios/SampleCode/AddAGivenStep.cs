namespace xBDD.Core.Test.Features.DefineScenarios.SampleCode
{
    public class AddAGivenStep
    {
        public ScenarioBuilder Add()
        {
            return xBDD.CurrentRun
                .AddScenario(this)
                .Given(xBDD.CreateStep("my starting condition", (s) => { /*my action here*/ }));
        }
    }
}
