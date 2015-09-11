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
        public int X { get; set; }
        public int Y { get; set; }
        public string StepType { get; set; }
        public string AddedStepName { get; set; }
        public ITestRun CurrentTestRun { get; internal set; }
        public ITestRun NextCurrentTestRun { get; internal set; }
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
            step.ReplaceNameParameters("MethodName", state.MethodName.Quote());
        }
        internal void a_method_with_the_xBDD_ScenarioTheory_attribute_named_MethodName(IStep step)
        {
            step.ReplaceNameParameters("MethodName", state.MethodName.Quote());
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
            step.ReplaceNameParameters("StepType", state.StepType, "StepName", state.StepName);
            state.Scenario
                .Given(state.StepName, stepTarget => { });
        }
        internal void the_first_call_is_made_to_MethodCall(IStep step)
        {
            step.ReplaceNameParameters("MethodCall", state.MethodCall.Quote());
            state.CurrentTestRun = xBDD.CurrentRun;
        }
        internal void a_second_call_is_made_to_MethodCall(IStep step)
        {
            step.ReplaceNameParameters("MethodCall", state.MethodCall.Quote());
            state.NextCurrentTestRun = xBDD.CurrentRun;
        }

        internal void the_following_code_is_executed(IStep step)
        {
            //step.SetMultilineParameter(state.MethodCall);
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
            step.ReplaceNameParameters("ExpectedScenarioName", state.ExpectedScenarioName.Quote());
            Assert.Equal(state.ExpectedScenarioName, state.Scenario.Name);
        }
        internal void the_area_path_will_match_the_namespace_like_ExpectedAreaPath(IStep step)
        {
            step.ReplaceNameParameters("ExpectedAreaPath", state.ExpectedAreaPath.Quote());
            Assert.Equal(state.ExpectedAreaPath, state.Scenario.AreaPath);
        }
        internal void the_feature_name_will_match_the_class_name_with_spaces_added_where_there_are_capital_letters_like_ExpectedFeatureName(IStep step)
        {
            step.ReplaceNameParameters("ExpectedFeatureName", state.ExpectedFeatureName.Quote());
            Assert.Equal(state.ExpectedFeatureName, state.Scenario.FeatureName);
        }

        internal void the_system_should_create_a_new_test_run(IStep obj)
        {
            Assert.NotNull(state.CurrentTestRun);
        }

        internal void the_system_should_return_the_same_test_run_from_the_first_call_as_the_second_call(IStep obj)
        {
            Assert.Equal(state.CurrentTestRun, state.NextCurrentTestRun);
        }

        internal void the_system_should_set_the_testRun_variable_with_a_new_test_run(IStep obj)
        {
            throw new NotImplementedException();
        }
    }
}
