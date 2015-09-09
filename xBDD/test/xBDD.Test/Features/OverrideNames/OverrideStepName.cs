using Xunit;

namespace xBDD.Test.Features.OverrideNames
{
    public class OverrideStepName
    {
        [ScenarioFact]
        public void WhenAdding()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void WithAnAttribute()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void AtRunTime()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void WithParameterReplacement()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void WithMultipleParameterReplacement()
        {
            Steps s = new Steps();
            s.State.StepName = "the user UserName navigates to the PageName page";
            s.State.PageName = "Home";
            s.State.ParameterReplacementCall = "step.SetNameWithReplacement(\"UserName\",\"JohnDoe\"\"PageName\",\"Home\")";
            s.State.NewStepName = "the user JohnDoe navigates to the Home page";
            xBDD.CurrentRun.AddScenario()
                .Given(s.Given.a_scenario)
                .And(s.Given.the_scenario_has_a_step_with_the_name_StepName)
                .When(s.When.the_step_calls_to_replace_the_parameters_in_its_name_with_ParameterReplacementCall)
                .Then(s.Then.the_step_name_should_be_NewStepName)
                .Run();

        }
        [ScenarioFact]
        public void WithParameterQuotes()
        {
            xBDD.CurrentRun.AddScenario().Skip();
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
