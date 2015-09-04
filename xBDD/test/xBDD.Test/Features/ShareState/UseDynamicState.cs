using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Test.Features.ShareState
{
    public class UseDynamicState
    {
        [ScenarioFact]
        public void Sync()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void Async()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
    }
}
