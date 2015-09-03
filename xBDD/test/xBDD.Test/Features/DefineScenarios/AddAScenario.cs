using System.Diagnostics;

namespace xBDD.Test.Features.DefineScenarios
{
    public class AddAScenario
    {
        [ScenarioFact]
        public void InAScenarioFact()
        {
            var s = new Steps();
            s.MethodName = new StackFrame().GetMethod().Name;
            s.ExpectedAreaPath = new StackFrame().GetMethod().DeclaringType.Namespace;
            s.ExpectedScenarioName = "In A Scenario Fact";
            s.ExpectedFeatureName = "Add A Scenario";
            s.ExpectedAreaPath = "xBDD.Test.Features.DefineScenarios";
            s.MethodCall = "xBDD.CurrentRun.AddScenario();";
            s.CurrentScenario = xBDD.CurrentRun.AddScenario()
                .Given(s.a_method_with_the_xBDD_ScenarioFact_attribute_named_MethodName)
                .When(s.a_call_is_made_to_MethodCall)
                .Then(s.a_scenario_will_be_created)
                .And(s.the_scenario_name_will_match_the_method_name_with_the_underscores_replaced_with_spaces_like_ExpectedScenarioName)
                .And(s.the_feature_name_will_match_the_class_name_with_spaces_added_where_there_are_capital_letters_like_ExpectedFeatureName)
                .And(s.the_area_path_will_match_the_namespace_like_ExpectedAreaPath);
            s.CurrentScenario.Run();
        }
        [ScenarioFact]
        public void InAnAsyncScenarioFact()
        {
            throw new SkipStepException("Not Implemented");
        }
        [ScenarioFact]
        public void InAScenarioTheroy()
        {
            throw new SkipStepException("Not Implemented");
        }
        [ScenarioFact]
        public void InAnAsyncScenarioTheory()
        {
            throw new SkipStepException("Not Implemented");
        }
        [ScenarioFact]
        public void InARegularMethodNoScenarioFactOrTheory()
        {
            throw new SkipStepException("Not Implemented");
        }
    }
}
