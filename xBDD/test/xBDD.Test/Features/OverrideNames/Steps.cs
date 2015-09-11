using System;
using xBDD.Test.Sample;
using Xunit;

namespace xBDD.Test.Features.OverrideNames
{
    public class Steps
    {
        public StepsState State { get; set; }
        public GivenSteps Given { get; set; }
        public WhenSteps When { get; set; }
        public ThenSteps Then { get; set; }
        public Steps()
        {
            State = new StepsState();
            Given = new GivenSteps(State);
            When = new WhenSteps(State);
            Then = new ThenSteps(State);
        }
    }

    public class StepsState : CommonState
    {
        public string ExpectedAreaPath { get; internal set; }
        public string ExpectedFeatureName { get; internal set; }
        public string ExpectedScenarioName { get; internal set; }
        public string PageName { get; internal set; }
        public string NewStepName { get; internal set; }
    }

    [StepLibrary]
    public class GivenSteps : CommonGivenSteps
    {
        StepsState state;
        public GivenSteps(StepsState state)
            : base(state)
        {
            this.state = state;
        }
        internal void the_step_calls_to_replace_two_parameters_in_its_name_with_ParameterReplacementCall(IStep step)
        {
            step.ReplaceNameParameters("ParameterReplacementCall", state.MethodCall.Quote());
            state.Step.Action = stepTarget => { stepTarget.ReplaceNameParameters("UserName", "JohnDoe", "PageName", "Home"); };
        }

        internal void the_step_calls_to_set_the_multiline_parameter_with_MethodCall(IStep step)
        {
            step.ReplaceNameParameters("MethodCall", state.MethodCall.Quote());
            state.Step.Action = stepTarget => { stepTarget.SetMultilineParameter(state.MultilineParameter); };
        }

        internal void the_step_calls_to_replace_one_parameter_in_its_name_with_ParameterReplacementCall(IStep step)
        {
            step.ReplaceNameParameters("ParameterReplacementCall", state.MethodCall.Quote());
            state.Step.Action = stepTarget => { stepTarget.ReplaceNameParameters("UserName", "JohnDoe"); };
        }
    }
    [StepLibrary]
    public class WhenSteps : CommonWhenSteps
    {
        StepsState state;
        public WhenSteps(StepsState state)
            : base(state)
        {
            this.state = state;
        }
    }
    [StepLibrary]
    public class ThenSteps : CommonThenSteps
    {
        StepsState state;
        public ThenSteps(StepsState state)
            : base(state)
        {
            this.state = state;
        }
        internal void the_step_name_should_be_NewStepName(IStep step)
        {
            Assert.Equal(state.NewStepName, state.Step.Name);
        }

        internal void the_step_multiline_parameter_value_should_be_MultilineParameter(IStep step)
        {
            Assert.Equal(state.MultilineParameter, state.Step.MultilineParameter);
        }
    }

}
