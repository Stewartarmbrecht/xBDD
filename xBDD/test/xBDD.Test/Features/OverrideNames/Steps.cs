using System;
using xBDD.Test.Sample;
using Xunit;

namespace xBDD.Test.Features.OverrideNames
{
    public class Steps
    {
        public CommonSteps c { get; set; }
        public StepsState State { get; set; }
        public GivenSteps Given { get; set; }
        public WhenSteps When { get; set; }
        public ThenSteps Then { get; set; }
        public Steps()
        {
            c = new CommonSteps();
            State = new StepsState(c.State);
            Given = new GivenSteps(State);
            When = new WhenSteps(State);
            Then = new ThenSteps(State);
        }
    }

    public class StepsState
    {
        public CommonState c { get; set; }
        public StepsState(CommonState cs)
        {
            c = cs;
        }
        public string ExpectedAreaPath { get; internal set; }
        public string ExpectedFeatureName { get; internal set; }
        public string ExpectedScenarioName { get; internal set; }
        public string PageName { get; internal set; }
        public string NewStepName { get; internal set; }
    }

    [StepLibrary]
    public class GivenSteps
    {
        StepsState state;
        public GivenSteps(StepsState state)

        {
            this.state = state;
        }
        internal void the_step_calls_to_replace_two_parameters_in_its_name_with_ParameterReplacementCall(Step step)
        {
            step.ReplaceNameParameters("ParameterReplacementCall", state.c.MethodCall.Quote());
            state.c.Step.Action = stepTarget => { stepTarget.ReplaceNameParameters("UserName", "JohnDoe", "PageName", "Home"); };
        }

        internal void the_step_calls_to_set_the_multiline_parameter_with_MethodCall(Step step)
        {
            step.ReplaceNameParameters("MethodCall", state.c.MethodCall.Quote());
            state.c.Step.Action = stepTarget => { stepTarget.SetMultilineParameter(state.c.MultilineParameter); };
        }

        internal void the_step_calls_to_replace_one_parameter_in_its_name_with_ParameterReplacementCall(Step step)
        {
            step.ReplaceNameParameters("ParameterReplacementCall", state.c.MethodCall.Quote());
            state.c.Step.Action = stepTarget => { stepTarget.ReplaceNameParameters("UserName", "JohnDoe"); };
        }
    }
    [StepLibrary]
    public class WhenSteps
    {
        StepsState state;
        public WhenSteps(StepsState state)

        {
            this.state = state;
        }
    }
    [StepLibrary]
    public class ThenSteps
    {
        StepsState state;
        public ThenSteps(StepsState state)

        {
            this.state = state;
        }
        internal void the_step_name_should_be_NewStepName(Step step)
        {
            Assert.Equal(state.NewStepName, state.c.Step.Name);
        }

        internal void the_step_multiline_parameter_value_should_be_MultilineParameter(Step step)
        {
            Assert.Equal(state.c.MultilineParameter, state.c.Step.MultilineParameter);
        }
    }

}
