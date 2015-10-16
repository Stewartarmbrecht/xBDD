namespace xBDD.Core.Test.Features.DefineScenarios.SampleCode
{
    public class AddAGivenStep
    {
        public ScenarioBuilder Add()
        {
            return xB.CurrentRun
                .AddScenario(this)
                .Given(xB.CreateStep("my starting condition", (s) => { /*my action here*/ }));
        }
    }
}
