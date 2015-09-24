using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using xBDD.Core;
using xBDD.Test.Mocks;
using xBDD.Test.Sample;
using Xunit;

namespace xBDD.Test.Features
{
    public class CommonSteps
    {
        public CommonSteps()
        {
            State = new CommonState();
            Given = new CommonGivenSteps(State);
            When = new CommonWhenSteps(State);
            Then = new CommonThenSteps(State);
        }
        public CommonState State { get; set; }
        public CommonGivenSteps Given { get; set; }
        public CommonWhenSteps When { get; set; }
        public CommonThenSteps Then { get; set; }

    }
    public class CommonState
    {
        public Scenario Scenario { get; set; }
        public Step Step { get; set; }
        public Exception CaughtException { get; set; }
        public string MultilineParameter { get; set; }
        public string MethodCall { get; set; }
        public TestRun TestRun { get; set; }
        public string TestRunName { get; set; }
        public string ScenarioName { get; set; }
        public string StepName { get; set; }
        public MockOutputWriter OutputWriter { get; set; }
        public string Output { get; set; }
        public string FeatureName { get; set; }
        public string AreaPath { get; set; }
        public string SkipReason { get; set; }
        public string ScenarioReason { get; set; }
        public int ExceptionStepIndex { get; set; }
        public Exception StepException { get; set; }
        public string ScenarioExceptionType { get; set; }
        public string ScenarioExceptionMessage { get; set; }
        public Outcome StepOutcome { get; set; }
        public string StepReason { get; set; }
        public Outcome ScenarioOutcome { get; set; }
        public string StepExceptionMessage { get; set; }
    }
    [StepLibrary]
    public class CommonGivenSteps
    {
        CommonState state;
        public CommonGivenSteps(CommonState state)
        {
            this.state = state;
        }
        public void a_test_run(Step step)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("var factory = new CoreFactory();");
            sb.AppendLine("var testRun = new TestRun(factory);");
            step.SetMultilineParameter(sb.ToString());
            var factory = new CoreFactory();
            state.TestRun = new TestRun(factory);
        }
        public void a_test_run_with_name_TestRunName(Step step)
        {
            step.ReplaceNameParameters("TestRunName", state.TestRunName.Quote());
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("var factory = new CoreFactory();");
            sb.AppendLine("var testRun = new TestRun(factory);");
            sb.AppendLine("var testRun.Name = name;");
            step.SetMultilineParameter(sb.ToString());
            var factory = new CoreFactory();
            state.TestRun = new TestRun(factory);
            state.TestRun.Name = state.TestRunName;
        }
        public void a_scenario(Step step)
        {
            if(state.TestRun == null)
            {
                var factory = new CoreFactory();
                state.TestRun = new TestRun(factory);
            }
            state.Scenario = state.TestRun.AddScenario(this);
        }
        public void a_scenario_with_the_name_ScenarioName(Step step)
        {
            step.ReplaceNameParameters("ScenarioName", state.ScenarioName.Quote());
            step.SetMultilineParameter("testRun.AddScenario(\"" + state.ScenarioName + "\");");
            if (state.TestRun == null)
            {
                var factory = new CoreFactory();
                state.TestRun = new TestRun(factory);
            }
            state.Scenario = state.TestRun.AddScenario(state.ScenarioName, this);
        }
        public void a_scenario_AreaPath_FeatureName_ScenarioName(Step step)
        {
            step.ReplaceNameParameters(
                "AreaPath", state.AreaPath, 
                "FeatureName", state.FeatureName,
                "ScenarioName", state.ScenarioName);
            state.Scenario = state.TestRun.AddScenario(state.ScenarioName, state.FeatureName, state.AreaPath, this);
        }
        public void a_given_step_with_the_name_StepName(Step step)
        {
            step.ReplaceNameParameters("StepName", state.StepName.Quote());
            step.SetMultilineParameter("scenario.Given(\""+state.StepName+"\", step => {});");
            if (state.TestRun == null)
            {
                var factory = new CoreFactory();
                state.TestRun = new TestRun(factory);
            }
            state.Scenario.Given(state.StepName, stepTarget => { });
            state.Step = state.Scenario.Steps[state.Scenario.Steps.Count -1];
        }
        public void the_scenario_is_set_to_write_its_output(Step step)
        {
            step.SetMultilineParameter("scenario.SetOutputWriter(outputWriter);");
            state.OutputWriter = new MockOutputWriter();
            state.Scenario.SetOutputWriter(state.OutputWriter);
        }
        public void the_step_has_a_multiline_parameter_of(Step step)
        {
            step.SetMultilineParameter(state.MultilineParameter);
            state.Step.SetMultilineParameter(state.MultilineParameter);
        }
        public void the_scenario_has_three_steps(Step step)
        {
            state.Scenario.Given("my starting condition", st => {
                st.ReturnIfPreviousError();
            });
            state.Scenario.When("my action", st => {
                st.ReturnIfPreviousError();
            });
            state.Scenario.Then("my ending condition", st => {
                st.ReturnIfPreviousError();
            });
        }
        public void all_steps_are_set_to_skip(Step obj)
        {
            foreach(var step in state.Scenario.Steps)
            {
                step.Action = st => {
                    throw new SkipStepException("Not Started");
                };
            }
        }
        public void the_ExceptionStepIndex_step_throws_a_ExceptionType_exception(Step step)
        {
            step.ReplaceNameParameters("ExceptionStepIndex", state.ExceptionStepIndex.ToString());
            step.ReplaceNameParameters("ExceptionType", state.StepException.GetType().Name);
            step.ReturnIfPreviousError();
            state.Scenario.Steps[state.ExceptionStepIndex].Action = st => {
                throw state.StepException;
            };
        }
        public void a_when_step_with_the_name_StepName(Step step)
        {
            step.ReplaceNameParameters("StepName", state.StepName);
            step.SetMultilineParameter("scenario.When(stepName, st => { step.ReturnIfPreviousError(); });");
            state.Scenario.When(state.StepName, stepTarget => { step.ReturnIfPreviousError(); });
            state.Step = state.Scenario.Steps[state.Scenario.Steps.Count - 1];
        }
    }

    [StepLibrary]
    public class CommonWhenSteps
    {
        CommonState state;
        public CommonWhenSteps(CommonState state)
        {
            this.state = state;
        }
        public void the_scenario_is_run(Step step)
        {
            step.ReturnIfPreviousError();
            state.Scenario.Run();
        }
        public void the_scenario_is_run_and_the_exception_caught(Step step)
        {
            step.ReturnIfPreviousError();
            try
            {
                state.Scenario.Run();
            }
            catch (Exception ex)
            {
                state.CaughtException = ex;
            }
        }
        public async Task the_scenario_is_run_asynchronously(Step obj)
        {
            await state.Scenario.RunAsync();
        }
        public void the_scenario_is_skipped_with_reason_of_ScenarioReason(Step step)
        {
            step.ReplaceNameParameters("ScenarioReason", state.ScenarioReason.Quote());
            step.ReturnIfPreviousError();
            try
            {
                state.Scenario.Skip(state.ScenarioReason);
            }
            catch (Exception ex)
            {
                state.CaughtException = ex;
            }
        }
        public async Task the_scenario_is_skipped_asynchronously_with_reason_of_ScenarioReason(Step step)
        {
            step.ReplaceNameParameters("ScenarioReason", state.ScenarioReason);
            step.ReturnIfPreviousError();
            try
            {
                await state.Scenario.SkipAsync(state.ScenarioReason);
            }
            catch (Exception ex)
            {
                state.CaughtException = ex;
            }
        }
    }

    [StepLibrary]
    public class CommonThenSteps
    {
        CommonState state;
        public CommonThenSteps(CommonState state)
        {
            this.state = state;
        }
        public void the_scenario_should_write_the_following_output(Step step)
        {
            step.ReturnIfPreviousError();
            Assert.Equal(state.Output, state.OutputWriter.Output);
        }
        public void the_scenario_reason_should_be_ScenarioReason(Step step)
        {
            step.ReplaceNameParameters("ScenarioReason", state.ScenarioReason.Quote());
            Assert.Equal(state.ScenarioReason, state.Scenario.Reason);
        }
        public void the_caught_scenario_exception_should_be_of_type_ScenarioExceptionType(Step step)
        {
            step.ReplaceNameParameters("ScenarioExceptionType", state.ScenarioExceptionType);
            step.ReturnIfPreviousError();
            Assert.Equal(state.ScenarioExceptionType, state.CaughtException.GetType().Name);
        }
        public void the_caught_scenario_exception_should_have_a_message_of_ScenarioExceptionMessage(Step step)
        {
            step.ReplaceNameParameters("ScenarioExceptionMessage", state.ScenarioExceptionMessage);
            step.ReturnIfPreviousError();
            Assert.Equal(state.ScenarioExceptionMessage, state.CaughtException.Message);
        }
        public void the_step_outcome_should_be_StepOutcome(Step step)
        {
            step.ReplaceNameParameters("StepOutcome", Enum.GetName(typeof(Outcome), state.StepOutcome));
            Assert.Equal(state.StepOutcome, state.Step.Outcome);
        }
        public void the_step_reason_should_be_StepReason(Step step)
        {
            step.ReplaceNameParameters("StepReason", state.StepReason.Quote());
            Assert.Equal(state.StepReason, state.Step.Reason);
        }
        public void the_step_exception_message_should_be_StepExceptionMessage(Step step)
        {
            step.ReplaceNameParameters("StepExceptionMessage", state.StepExceptionMessage);
            Assert.Equal(state.StepExceptionMessage, state.Step.Exception.Message);
        }
        public void the_step_exception_should_be_the_exception_thrown(Step step)
        {
            Assert.Equal(state.StepException, state.Step.Exception);
        }
    }

}
