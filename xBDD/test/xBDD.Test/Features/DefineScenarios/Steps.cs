using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xBDD.Core;
using Xunit;

namespace xBDD.Test.Features.DefineScenarios
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
        public string MethodName { get; set; }
        public string ExpectedScenarioName { get; set; }
        public string ExpectedAreaPath { get; set; }
        public string ExpectedFeatureName { get; set; }
        public string MethodCall { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string StepType { get; set; }
        public string StepName { get; set; }
        public string AddedStepName { get; set; }

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

        internal void a_method_with_the_xBDD_ScenarioFact_attribute_named_MethodName(IStep step)
        {
            step.SetNameWithReplacement("MethodName", state.MethodName.Quote());
        }
        internal void a_method_with_the_xBDD_ScenarioTheory_attribute_named_MethodName(IStep step)
        {
            step.SetNameWithReplacement("MethodName", state.MethodName.Quote());
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

        internal void a_StepType_step_is_added_to_a_scenario_with_a_name_of_StepName(IStep step)
        {
            step.SetNameWithReplacement("StepType", state.StepType, "StepName", state.StepName);
            state.Scenario
                .Given(state.StepName, stepTarget => { });
        }
        internal void a_call_is_made_to_MethodCall(IStep step)
        {
            step.SetNameWithReplacement("MethodCall", state.MethodCall.Quote());
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

        internal void the_added_step_name_should_be_AddedStepName(IStep step)
        {
            Assert.Equal(state.AddedStepName, state.Scenario.Steps[0].Name);
        }
        internal void a_scenario_will_be_created(IStep step)
        {
            Assert.NotNull(state.Scenario);
        }
        internal void the_scenario_name_will_match_the_method_name_with_the_underscores_replaced_with_spaces_like_ExpectedScenarioName(IStep step)
        {
            step.SetNameWithReplacement("ExpectedScenarioName", state.ExpectedScenarioName.Quote());
            Assert.Equal(state.ExpectedScenarioName, state.Scenario.Name);
        }
        internal void the_area_path_will_match_the_namespace_like_ExpectedAreaPath(IStep step)
        {
            step.SetNameWithReplacement("ExpectedAreaPath", state.ExpectedAreaPath.Quote());
            Assert.Equal(state.ExpectedAreaPath, state.Scenario.AreaPath);
        }
        internal void the_feature_name_will_match_the_class_name_with_spaces_added_where_there_are_capital_letters_like_ExpectedFeatureName(IStep step)
        {
            step.SetNameWithReplacement("ExpectedFeatureName", state.ExpectedFeatureName.Quote());
            Assert.Equal(state.ExpectedFeatureName, state.Scenario.FeatureName);
        }
    }
}
