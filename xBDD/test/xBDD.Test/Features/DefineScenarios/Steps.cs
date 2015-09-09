using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xBDD.Core;
using Xunit;

namespace xBDD.Test.Features.DefineScenarios
{
    [StepLibrary]
    public class Steps : CommonSteps
    {
        public string MethodName { get; set; }
        public string ExpectedScenarioName { get; set; }
        public string ExpectedAreaPath { get; set; }
        public string ExpectedFeatureName { get; set; }
        public string MethodCall { get; set; }
        public int X { get; internal set; }
        public int Y { get; internal set; }
        public string StepType { get; internal set; }
        public string StepName { get; internal set; }
        public string AddedStepName { get; internal set; }

        #region Given
        internal void a_method_with_the_xBDD_ScenarioFact_attribute_named_MethodName(IStep step)
        {
            step.SetNameWithReplacement("MethodName", MethodName.Quote());
        }
        #endregion Given
        #region When
        internal void a_StepType_step_is_added_to_a_scenario_with_a_name_of_StepName(IStep step)
        {
            step.SetNameWithReplacement("StepType", StepType, "StepName", StepName);
            Scenario
                .Given(StepName, stepTarget => { });
        }
        internal void a_call_is_made_to_MethodCall(IStep step)
        {
            step.SetNameWithReplacement("MethodCall", MethodCall.Quote());
        }
        internal void a_method_with_the_xBDD_ScenarioTheory_attribute_named_MethodName(IStep step)
        {
            step.SetNameWithReplacement("MethodName", MethodName.Quote());
        }
        #endregion When
        #region Then
        internal void the_added_step_name_should_be_AddedStepName(IStep step)
        {
            Assert.Equal(AddedStepName, Scenario.Steps[0].Name);
        }
        internal void a_scenario_will_be_created(IStep step)
        {
            Assert.NotNull(Scenario);
        }
        internal void the_scenario_name_will_match_the_method_name_with_the_underscores_replaced_with_spaces_like_ExpectedScenarioName(IStep step)
        {
            step.SetNameWithReplacement("ExpectedScenarioName", ExpectedScenarioName.Quote());
            Assert.Equal(ExpectedScenarioName, Scenario.Name);
        }
        internal void the_area_path_will_match_the_namespace_like_ExpectedAreaPath(IStep step)
        {
            step.SetNameWithReplacement("ExpectedAreaPath", ExpectedAreaPath.Quote());
            Assert.Equal(ExpectedAreaPath, Scenario.AreaPath);
        }
        internal void the_feature_name_will_match_the_class_name_with_spaces_added_where_there_are_capital_letters_like_ExpectedFeatureName(IStep step)
        {
            step.SetNameWithReplacement("ExpectedFeatureName", ExpectedFeatureName.Quote());
            Assert.Equal(ExpectedFeatureName, Scenario.FeatureName);
        }
        #endregion Then

    }
}
