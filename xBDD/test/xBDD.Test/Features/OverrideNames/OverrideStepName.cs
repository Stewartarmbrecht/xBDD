using System.Text;
using xBDD.xUnit;
using Xunit;
using Xunit.Abstractions;

namespace xBDD.Test.Features.OverrideNames
{
    public class OverrideStepName
    {
        private readonly OutputWriter outputWriter;

        public OverrideStepName(ITestOutputHelper output)
        {
            outputWriter = new OutputWriter(output);
        }

        [ScenarioFact]
        public void WhenAdding()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void WhenAddingWithGivenStart()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void WhenAddingWithWhenStart()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void WhenAddingWithThenStart()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void WhenAddingWithAndStart()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void WithAnAttribute()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void AtRunTime()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void WithParameterReplacement()
        {
            Steps s = new Steps();
            s.c.State.StepName = "the user UserName navigates to the last page";
            s.c.State.MethodCall = "step.ReplaceNameParameters(\"UserName\",\"JohnDoe\")";
            s.State.NewStepName = "Given the user JohnDoe navigates to the last page";
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Given(s.c.Given.a_scenario)
                .And(s.c.Given.a_given_step_with_the_name_StepName)
                .And(s.Given.the_step_calls_to_replace_one_parameter_in_its_name_with_ParameterReplacementCall)
                .When(s.c.When.the_scenario_is_run)
                .Then(s.Then.the_step_name_should_be_NewStepName)
                .Run();
        }
        [ScenarioFact]
        public void WithMultipleParameterReplacement()
        {
            Steps s = new Steps();
            s.c.State.StepName = "the user UserName navigates to the PageName page";
            s.State.PageName = "Home";
            s.c.State.MethodCall = "step.ReplaceNameParameters(\"UserName\",\"JohnDoe\"\"PageName\",\"Home\")";
            s.State.NewStepName = "Given the user JohnDoe navigates to the Home page";
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Given(s.c.Given.a_scenario)
                .And(s.c.Given.a_given_step_with_the_name_StepName)
                .And(s.Given.the_step_calls_to_replace_two_parameters_in_its_name_with_ParameterReplacementCall)
                .When(s.c.When.the_scenario_is_run)
                .Then(s.Then.the_step_name_should_be_NewStepName)
                .Run();

        }
        [ScenarioFact]
        public void WithParameterQuotes()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }

        [ScenarioFact]
        public void WithMultilineParameterSet()
        {
            Steps s = new Steps();
            s.c.State.StepName = "the following message should be displayed";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Welcome!");
            sb.AppendLine("We are happy to have you visit our site.");
            s.c.State.MultilineParameter = sb.ToString();
            s.c.State.MethodCall = "step.SetMultilineParameter(parameterValue);";
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Given(s.c.Given.a_scenario)
                .And(s.c.Given.a_given_step_with_the_name_StepName)
                .And(s.Given.the_step_calls_to_set_the_multiline_parameter_with_MethodCall)
                .When(s.c.When.the_scenario_is_run)
                .Then(s.Then.the_step_multiline_parameter_value_should_be_MultilineParameter)
                .Run();

        }

        //[ScenarioFact]
        //public void WhenAddingStep()
        //{
        //    var stepName = "My Step";
        //    var scenario = xBDD.CurrentRun.AddScenario(this);
        //    scenario.Given(stepName, step => { });
        //    Assert.Equal("Given My Step", scenario.Steps[0].Name);
        //}
        //[ScenarioFact]
        //public void InsideStepMethod()
        //{
        //    var stepName = "My Step";
        //    var scenario = xBDD.CurrentRun.AddScenario(this);
        //    scenario.Given(step => { step.SetName(stepName); });
        //    scenario.Run();
        //    Assert.Equal("Given My Step", scenario.Steps[0].Name);
        //}
        //[ScenarioFact]
        //public void WithAttributeOnStepMethod()
        //{
        //    var scenario = xBDD.CurrentRun.AddScenario(this);
        //    scenario.Given(MyStep);
        //    Assert.Equal("Given My Overridden Step Name", scenario.Steps[0].Name);
        //}

        //[StepName("My Overridden Step Name")]
        //private void MyStep(Step step)
        //{
        //    return;
        //}
    }
}
