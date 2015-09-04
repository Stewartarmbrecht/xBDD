using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Test.Features.RunTests
{
    public class RunAScenario
    {
        [ScenarioFact]
        public void Sync()
        {
            var s = new Steps();
            xBDD.CurrentRun.AddScenario();
            throw new SkipStepException("Not Implemented");
        }
        [ScenarioFact]
        public void Async()
        {
            var s = new Steps();
            xBDD.CurrentRun.AddScenario();
            throw new SkipStepException("Not Implemented");
        }
        [ScenarioFact]
        public void WithAllPassingSteps()
        {
            var s = new Steps();
            xBDD.CurrentRun.AddScenario();
            throw new SkipStepException("Not Implemented");
        }
        [ScenarioFact]
        public void WithAllSkippedSteps()
        {
            var s = new Steps();
            xBDD.CurrentRun.AddScenario();
            throw new SkipStepException("Not Implemented");
        }
        [ScenarioFact]
        public void WithOneSkippedStepAndTheRestPassing()
        {
            var s = new Steps();
            xBDD.CurrentRun.AddScenario();
            throw new SkipStepException("Not Implemented");
        }
        [ScenarioFact]
        public void WithOneNotImplementedStepAndTheRestPassingAndNotLastStep()
        {
            var s = new Steps();
            xBDD.CurrentRun.AddScenario();
            throw new SkipStepException("Not Implemented");
        }
        [ScenarioFact]
        public void WithOneNotImplementedStepAndTheRestPassingAndNotFirstStep()
        {
            var s = new Steps();
            xBDD.CurrentRun.AddScenario();
            throw new SkipStepException("Not Implemented");
        }
        [ScenarioFact]
        public void WithOneFailingStepAndFollowingSteps()
        {
            var s = new Steps();
            xBDD.CurrentRun.AddScenario();
            throw new SkipStepException("Not Implemented");
        }
        [ScenarioFact]
        public void WithOneFailingStepAndPreceedingPassingSteps()
        {
            var s = new Steps();
            xBDD.CurrentRun.AddScenario();
            throw new SkipStepException("Not Implemented");
        }
    }
}
