using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Test.Features.CompileStats
{
    public class CompileTestRunResults
    {
        [ScenarioFact]
        public void CompletedTestRun()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void WithAreaPathSpecified()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void EmptyTestRun()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }

    }
}
