using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Test.Features.DefineScenarios
{
    public class OrganizeSteps
    {
        [ScenarioFact]
        public void InAStepLibrary()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void InAStepLibrarySharedAcrossAreas()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
    }
}
