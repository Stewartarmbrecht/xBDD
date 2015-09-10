using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace xBDD.Test.Features.ShareState
{
    public class UseDynamicState : Feature
    {
        public UseDynamicState(ITestOutputHelper outputWriter)
            : base(outputWriter)
        {
        }

        [ScenarioFact]
        public void Sync()
        {
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Skip();
        }
        [ScenarioFact]
        public void Async()
        {
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Skip();
        }
    }
}
