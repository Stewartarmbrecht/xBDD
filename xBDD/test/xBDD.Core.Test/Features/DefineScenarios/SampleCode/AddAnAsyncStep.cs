using System.Threading.Tasks;

namespace xBDD.Core.Test.Features.DefineScenarios.SampleCode
{
    public class AddAnAsyncStep
    {
        public ScenarioBuilder Add()
        {
            return xBDD.CurrentRun
                .AddScenario(this)
                .Given(xBDD.CreateAsyncStep("my async starting condition", () => { return Task.Run(() => { }); }));
        }
    }
}
