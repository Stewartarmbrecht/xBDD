using xBDD.Model;

namespace xBDD.Core.Test.Features.DefineScenarios.SampleCode
{
    public class AddAGivenStep
    {
        public Scenario Add()
        {
            return xBDD.CurrentRun
                .AddScenario(this)
                .Given(xBDD.CreateStep("my starting condition", () => { /*my action here*/ }));
        }
    }
}
