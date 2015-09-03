﻿using Xunit;

namespace xBDD.Test.Features.OverrideNames
{
    public class OverrideStepName
    {
        [ScenarioFact]
        public void WhenAdding()
        {
            throw new SkipStepException("Not Implemented");
        }
        [ScenarioFact]
        public void WithAnAttribute()
        {
            throw new SkipStepException("Not Implemented");
        }
        [ScenarioFact]
        public void AtRunTime()
        {
            throw new SkipStepException("Not Implemented");
        }
        [ScenarioFact]
        public void WithParameterReplacement()
        {
            throw new SkipStepException("Not Implemented");
        }
        [ScenarioFact]
        public void WithParameterQuotes()
        {
            throw new SkipStepException("Not Implemented");
        }

        //[ScenarioFact]
        //public void WhenAddingStep()
        //{
        //    var stepName = "My Step";
        //    var scenario = xBDD.CurrentRun.AddScenario();
        //    scenario.Given(stepName, step => { });
        //    Assert.Equal("Given My Step", scenario.Steps[0].Name);
        //}
        //[ScenarioFact]
        //public void InsideStepMethod()
        //{
        //    var stepName = "My Step";
        //    var scenario = xBDD.CurrentRun.AddScenario();
        //    scenario.Given(step => { step.SetName(stepName); });
        //    scenario.Run();
        //    Assert.Equal("Given My Step", scenario.Steps[0].Name);
        //}
        //[ScenarioFact]
        //public void WithAttributeOnStepMethod()
        //{
        //    var scenario = xBDD.CurrentRun.AddScenario();
        //    scenario.Given(MyStep);
        //    Assert.Equal("Given My Overridden Step Name", scenario.Steps[0].Name);
        //}

        //[StepName("My Overridden Step Name")]
        //private void MyStep(IStep step)
        //{
        //    return;
        //}
    }
}