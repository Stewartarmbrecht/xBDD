using System.Threading.Tasks;

namespace xBDD.Core.Test.Features.DefineScenarios.SampleCode
{
    public class AddAnAsyncStep
    {
        public ScenarioBuilder Add()
        {
            return xB.CurrentRun
                .AddScenario(this)
                .Given(xB.CreateAsyncStep("my async starting condition", (s) => { return Task.Run(() => { }); }));
        }
    }
}
