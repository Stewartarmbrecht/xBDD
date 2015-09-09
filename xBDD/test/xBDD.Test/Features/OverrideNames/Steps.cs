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
        public string StepName { get; internal set; }
        public string PageName { get; internal set; }
        public string ParameterReplacementCall { get; internal set; }
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
        internal void the_scenario_has_a_step_with_the_name_StepName(IStep obj)
        {
            state.Scenario.Given(state.StepName, st => { });
            state.Step = state.Scenario.Steps[0];
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
        internal void the_step_calls_to_replace_the_parameters_in_its_name_with_ParameterReplacementCall(IStep obj)
        {
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
        internal void the_step_name_should_be_NewStepName(IStep obj)
        {
            throw new NotImplementedException();
        }

    }

}
