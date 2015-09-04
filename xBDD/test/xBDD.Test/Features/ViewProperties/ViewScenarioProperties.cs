using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Test.Features.ViewProperties
{
    public class ViewScenarioProperties
    {
        [ScenarioFact]
        public void Name()
        {
            xBDD.CurrentRun.AddScenario();
            throw new SkipStepException("Not Implemented");
        }
        [ScenarioFact]
        public void FeatureName()
        {
            xBDD.CurrentRun.AddScenario();
            throw new SkipStepException("Not Implemented");
        }
        [ScenarioFact]
        public void AreaPath()
        {
            xBDD.CurrentRun.AddScenario();
            throw new SkipStepException("Not Implemented");
        }
        [ScenarioFact]
        public void State()
        {
            xBDD.CurrentRun.AddScenario();
            throw new SkipStepException("Not Implemented");
        }
        [ScenarioFact]
        public void Steps()
        {
            xBDD.CurrentRun.AddScenario();
            throw new SkipStepException("Not Implemented");
        }
    }
}
