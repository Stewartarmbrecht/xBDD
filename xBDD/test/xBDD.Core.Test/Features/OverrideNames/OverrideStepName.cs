using xBDD.xUnit;
using Xunit;
using Xunit.Abstractions;

namespace xBDD.Core.Test.Features.OverrideNames
{
    [Collection("xBDDCoreTest")]
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
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void WhenAddingWithGivenStart()
        {
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void WhenAddingWithWhenStart()
        {
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void WhenAddingWithThenStart()
        {
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void WhenAddingWithAndStart()
        {
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void WithAnAttribute()
        {
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void AtRunTime()
        {
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void WithParameterReplacement()
        {
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Re-writing");
            //Steps s = new Steps();
            //s.c.State.StepName = "the user UserName navigates to the last page";
            //s.c.State.MethodCall = "step.ReplaceNameParameters(\"UserName\",\"JohnDoe\")";
            //s.State.NewStepName = "Given the user JohnDoe navigates to the last page";
            //xBDD.CurrentRun
            //    .AddScenario(this)
            //    .SetOutputWriter(outputWriter)
            //    .Given(s.c.Given.a_scenario)
            //    .And(s.c.Given.a_given_step_with_the_name_StepName)
            //    .And(s.Given.the_step_calls_to_replace_one_parameter_in_its_name_with_ParameterReplacementCall)
            //    .When(s.c.When.the_scenario_is_run)
            //    .Then(s.Then.the_step_name_should_be_NewStepName)
            //    .Run();
        }
        [ScenarioFact]
        public void WithMultipleParameterReplacement()
        {
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Re-writing");
            //Steps s = new Steps();
            //s.c.State.StepName = "the user UserName navigates to the PageName page";
            //s.State.PageName = "Home";
            //s.c.State.MethodCall = "step.ReplaceNameParameters(\"UserName\",\"JohnDoe\"\"PageName\",\"Home\")";
            //s.State.NewStepName = "Given the user JohnDoe navigates to the Home page";
            //xBDD.CurrentRun
            //    .AddScenario(this)
            //    .SetOutputWriter(outputWriter)
            //    .Given(s.c.Given.a_scenario)
            //    .And(s.c.Given.a_given_step_with_the_name_StepName)
            //    .And(s.Given.the_step_calls_to_replace_two_parameters_in_its_name_with_ParameterReplacementCall)
            //    .When(s.c.When.the_scenario_is_run)
            //    .Then(s.Then.the_step_name_should_be_NewStepName)
            //    .Run();

        }
        [ScenarioFact]
        public void WithParameterQuotes()
        {
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }

        [ScenarioFact]
        public void WithMultilineParameterSet()
        {
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Re-writing");
            //Steps s = new Steps();
            //s.c.State.StepName = "the following message should be displayed";
            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine("Welcome!");
            //sb.AppendLine("We are happy to have you visit our site.");
            //s.c.State.MultilineParameter = sb.ToString();
            //s.c.State.MethodCall = "step.SetMultilineParameter(parameterValue);";
            //xBDD.CurrentRun
            //    .AddScenario(this)
            //    .SetOutputWriter(outputWriter)
            //    .Given(s.c.Given.a_scenario)
            //    .And(s.c.Given.a_given_step_with_the_name_StepName)
            //    .And(s.Given.the_step_calls_to_set_the_multiline_parameter_with_MethodCall)
            //    .When(s.c.When.the_scenario_is_run)
            //    .Then(s.Then.the_step_multiline_parameter_value_should_be_MultilineParameter)
            //    .Run();

        }
    }
}
