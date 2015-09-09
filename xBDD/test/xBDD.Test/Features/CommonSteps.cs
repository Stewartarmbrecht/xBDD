using System;
using System.Threading.Tasks;
using xBDD.Core;
using xBDD.Test.Sample;

namespace xBDD.Test.Features
{
    public class CommonSteps
    {
        public Outcome ExpectedOutcome { get; internal set; }
        public IScenario Scenario { get; set; }
        public IStep Step { get; set; }
        public Exception CaughtException { get; set; }

        internal void a_scenario(IStep step)
        {
            var factory = new CoreFactory();
            var testRun = new TestRun(factory);
            Scenario = testRun.AddScenario();
        }

    }
}
