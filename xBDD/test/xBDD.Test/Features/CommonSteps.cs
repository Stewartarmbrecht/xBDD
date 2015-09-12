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
        public IScenario Scenario { get; set; }
        public IStep Step { get; set; }
        public Exception CaughtException { get; set; }
        public string MultilineParameter { get; internal set; }
        public string MethodCall { get; internal set; }
        public TestRun TestRun { get; internal set; }
        public string TestRunName { get; internal set; }
        public string ScenarioName { get; internal set; }
        public string StepName { get; internal set; }
        public MockOutputWriter OutputWriter { get; internal set; }
        public string Output { get; internal set; }
        public string FeatureName { get; internal set; }
        public string AreaPath { get; internal set; }
        public string SkipReason { get; internal set; }
        public string ScenarioReason { get; internal set; }
        public int ExceptionStepIndex { get; internal set; }
        public Exception StepException { get; internal set; }
        public string ScenarioExceptionType { get; internal set; }
        public string ScenarioExceptionMessage { get; internal set; }
        public Outcome StepOutcome { get; internal set; }
        public string StepReason { get; internal set; }
        public Outcome ScenarioOutcome { get; internal set; }
        public string StepExceptionMessage { get; internal set; }
    }
    [StepLibrary]
    public class CommonGivenSteps
    {
        CommonState state;
        public CommonGivenSteps(CommonState state)
        {
            this.state = state;
        }
        internal void a_test_run(IStep step)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("var factory = new CoreFactory();");
            sb.AppendLine("var testRun = new TestRun(factory);");
            step.SetMultilineParameter(sb.ToString());
            var factory = new CoreFactory();
            state.TestRun = new TestRun(factory);
        }
        internal void a_test_run_with_name_TestRunName(IStep step)
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
        internal void a_scenario(IStep step)
        {
            if(state.TestRun == null)
            {
                var factory = new CoreFactory();
                state.TestRun = new TestRun(factory);
            }
            state.Scenario = state.TestRun.AddScenario();
        }
        internal void a_scenario_with_the_name_ScenarioName(IStep step)
        {
            step.ReplaceNameParameters("ScenarioName", state.ScenarioName.Quote());
            step.SetMultilineParameter("testRun.AddScenario(\"" + state.ScenarioName + "\");");
            if (state.TestRun == null)
            {
                var factory = new CoreFactory();
                state.TestRun = new TestRun(factory);
            }
            state.Scenario = state.TestRun.AddScenario(state.ScenarioName);
        }
        internal void a_scenario_AreaPath_FeatureName_ScenarioName(IStep step)
        {
            step.ReplaceNameParameters(
                "AreaPath", state.AreaPath, 
                "FeatureName", state.FeatureName,
                "ScenarioName", state.ScenarioName);
            state.Scenario = state.TestRun.AddScenario(state.ScenarioName, state.FeatureName, state.AreaPath);
        }
        internal void a_given_step_with_the_name_StepName(IStep step)
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
        internal void the_scenario_is_set_to_write_its_output(IStep step)
        {
            step.SetMultilineParameter("scenario.SetOutputWriter(outputWriter);");
            state.OutputWriter = new MockOutputWriter();
            state.Scenario.SetOutputWriter(state.OutputWriter);
        }
        internal void the_step_has_a_multiline_parameter_of(IStep step)
        {
            step.SetMultilineParameter(state.MultilineParameter);
            state.Step.SetMultilineParameter(state.MultilineParameter);
        }
        internal void the_scenario_has_three_steps(IStep step)
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
        internal void all_steps_are_set_to_skip(IStep obj)
        {
            foreach(var step in state.Scenario.Steps)
            {
                step.Action = st => {
                    throw new SkipStepException("Not Started");
                };
            }
        }
        internal void the_ExceptionStepIndex_step_throws_a_ExceptionType_exception(IStep step)
        {
            step.ReplaceNameParameters("ExceptionStepIndex", state.ExceptionStepIndex.ToString());
            step.ReplaceNameParameters("ExceptionType", state.StepException.GetType().Name);
            step.ReturnIfPreviousError();
            state.Scenario.Steps[state.ExceptionStepIndex].Action = st => {
                throw state.StepException;
            };
        }
        public void a_when_step_with_the_name_StepName(IStep step)
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
        internal void the_scenario_is_run(IStep step)
        {
            step.ReturnIfPreviousError();
            state.Scenario.Run();
        }
        internal void the_scenario_is_run_and_the_exception_caught(IStep step)
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
        internal async Task the_scenario_is_run_asynchronously(IStep obj)
        {
            await state.Scenario.RunAsync();
        }
        internal void the_scenario_is_skipped_with_reason_of_ScenarioReason(IStep step)
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
        internal async Task the_scenario_is_skipped_asynchronously_with_reason_of_ScenarioReason(IStep step)
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
        internal void the_scenario_should_write_the_following_output(IStep step)
        {
            step.ReturnIfPreviousError();
            Assert.Equal(state.Output, state.OutputWriter.Output);
        }
        internal void the_scenario_reason_should_be_ScenarioReason(IStep step)
        {
            step.ReplaceNameParameters("ScenarioReason", state.ScenarioReason.Quote());
            Assert.Equal(state.ScenarioReason, state.Scenario.Reason);
        }
        internal void the_caught_scenario_exception_should_be_of_type_ScenarioExceptionType(IStep step)
        {
            step.ReplaceNameParameters("ScenarioExceptionType", state.ScenarioExceptionType);
            step.ReturnIfPreviousError();
            Assert.Equal(state.ScenarioExceptionType, state.CaughtException.GetType().Name);
        }
        internal void the_caught_scenario_exception_should_have_a_message_of_ScenarioExceptionMessage(IStep step)
        {
            step.ReplaceNameParameters("ScenarioExceptionMessage", state.ScenarioExceptionMessage);
            step.ReturnIfPreviousError();
            Assert.Equal(state.ScenarioExceptionMessage, state.CaughtException.Message);
        }
        internal void the_step_outcome_should_be_StepOutcome(IStep step)
        {
            step.ReplaceNameParameters("StepOutcome", Enum.GetName(typeof(Outcome), state.StepOutcome));
            Assert.Equal(state.StepOutcome, state.Step.Outcome);
        }
        internal void the_step_reason_should_be_StepReason(IStep step)
        {
            step.ReplaceNameParameters("StepReason", state.StepReason.Quote());
            Assert.Equal(state.StepReason, state.Step.Reason);
        }
        internal void the_step_exception_message_should_be_StepExceptionMessage(IStep step)
        {
            step.ReplaceNameParameters("StepExceptionMessage", state.StepExceptionMessage);
            Assert.Equal(state.StepExceptionMessage, state.Step.Exception.Message);
        }
        internal void the_step_exception_should_be_the_exception_thrown(IStep step)
        {
            Assert.Equal(state.StepException, state.Step.Exception);
        }
    }

}
