using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace xBDD.Test.Features.DefineScenarios
{
    [StepLibrary]
    public class Steps : CommonSteps
    {
        public IScenario CurrentScenario { get; internal set; }
        public string MethodName { get; set; }
        public string ExpectedScenarioName { get; set; }
        public string ExpectedAreaPath { get; set; }
        public string ExpectedFeatureName { get; set; }
        public string MethodCall { get; set; }

        internal void a_method_with_the_xBDD_ScenarioFact_attribute_named_MethodName(IStep step)
        {
            step.SetNameWithReplacement("MethodName", MethodName.Quote());
        }

        internal void a_scenario_will_be_created(IStep obj)
        {
            Assert.NotNull(CurrentScenario);
        }

        internal void the_scenario_name_will_match_the_method_name_with_the_underscores_replaced_with_spaces_like_ExpectedScenarioName(IStep obj)
        {
            obj.SetNameWithReplacement("ExpectedScenarioName", ExpectedScenarioName.Quote());
            Assert.Equal(ExpectedScenarioName, CurrentScenario.Name);
        }

        internal void the_area_path_will_match_the_namespace_like_ExpectedAreaPath(IStep obj)
        {
            obj.SetNameWithReplacement("ExpectedAreaPath", ExpectedAreaPath.Quote());
            Assert.Equal(ExpectedAreaPath, CurrentScenario.AreaPath);
        }

        internal void the_feature_name_will_match_the_class_name_with_spaces_added_where_there_are_capital_letters_like_ExpectedFeatureName(IStep obj)
        {
            obj.SetNameWithReplacement("ExpectedFeatureName", ExpectedFeatureName.Quote());
            Assert.Equal(ExpectedFeatureName, CurrentScenario.FeatureName);
        }

        internal void a_call_is_made_to_MethodCall(IStep obj)
        {
            obj.SetNameWithReplacement("MethodCall", MethodCall.Quote());
        }
    }
}
