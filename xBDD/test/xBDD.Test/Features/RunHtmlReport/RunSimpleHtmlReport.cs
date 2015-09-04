using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Test.Features.RunHtmlReport
{
    public class RunSimpleHtmlReport
    {
        [ScenarioFact]
        public void RunReport()
        {
            xBDD.CurrentRun.AddScenario();
            throw new SkipStepException("Not Implemented");
        }

    }
}
