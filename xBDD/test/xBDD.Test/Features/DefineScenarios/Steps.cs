using Xunit;

namespace xBDD.Test.Features.DefineScenarios
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
        public string MethodName { get; set; }
        public string ExpectedScenarioName { get; set; }
        public string ExpectedAreaPath { get; set; }
        public string ExpectedFeatureName { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string StepType { get; set; }
        public string AddedStepName { get; set; }
        public TestRun CurrentTestRun { get; internal set; }
        public TestRun NextCurrentTestRun { get; internal set; }
    }

    [StepLibrary]
    public class GivenSteps
    {
        StepsState state;
        public GivenSteps(StepsState state)

        {
            this.state = state;
        }

        internal void a_method_with_the_xBDD_ScenarioFact_attribute_named_MethodName(Step step)
        {
            step.ReplaceNameParameters("MethodName", state.MethodName.Quote());
        }
        internal void a_method_with_the_xBDD_ScenarioTheory_attribute_named_MethodName(Step step)
        {
            step.ReplaceNameParameters("MethodName", state.MethodName.Quote());
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

        internal void a_StepType_step_is_added_to_a_scenario_with_a_name_of_StepName(Step step)
        {
            step.ReplaceNameParameters("StepType", state.StepType, "StepName", state.c.StepName);
            state.c.Scenario
                .Given(state.c.StepName, stepTarget => { });
        }
        internal void the_first_call_is_made_to_MethodCall(Step step)
        {
            step.ReplaceNameParameters("MethodCall", state.c.MethodCall.Quote());
            state.CurrentTestRun = xBDD.CurrentRun;
        }
        internal void a_second_call_is_made_to_MethodCall(Step step)
        {
            step.ReplaceNameParameters("MethodCall", state.c.MethodCall.Quote());
            state.NextCurrentTestRun = xBDD.CurrentRun;
        }
        internal void the_following_code_is_executed(Step step)
        {
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

        internal void the_added_step_name_should_be_AddedStepName(Step step)
        {
            Assert.Equal(state.AddedStepName, state.c.Scenario.Steps[0].Name);
        }
        internal void a_scenario_will_be_created(Step step)
        {
            Assert.NotNull(state.c.Scenario);
        }
        internal void the_scenario_name_will_match_the_method_name_with_the_underscores_replaced_with_spaces_like_ExpectedScenarioName(Step step)
        {
            step.ReplaceNameParameters("ExpectedScenarioName", state.ExpectedScenarioName.Quote());
            Assert.Equal(state.ExpectedScenarioName, state.c.Scenario.Name);
        }
        internal void the_area_path_will_match_the_namespace_like_ExpectedAreaPath(Step step)
        {
            step.ReplaceNameParameters("ExpectedAreaPath", state.ExpectedAreaPath.Quote());
            Assert.Equal(state.ExpectedAreaPath, state.c.Scenario.AreaPath);
        }
        internal void the_feature_name_will_match_the_class_name_with_spaces_added_where_there_are_capital_letters_like_ExpectedFeatureName(Step step)
        {
            step.ReplaceNameParameters("ExpectedFeatureName", state.ExpectedFeatureName.Quote());
            Assert.Equal(state.ExpectedFeatureName, state.c.Scenario.FeatureName);
        }
        internal void the_system_should_create_a_new_test_run(Step obj)
        {
            Assert.NotNull(state.CurrentTestRun);
        }
        internal void the_system_should_return_the_same_test_run_from_the_first_call_as_the_second_call(Step obj)
        {
            Assert.Equal(state.CurrentTestRun, state.NextCurrentTestRun);
        }
        internal void the_system_should_set_the_testRun_variable_with_a_new_test_run(Step obj)
        {
        }
    }
}
