using System.Diagnostics;
using System.Threading.Tasks;
using Xunit;

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
            s.Scenario = xBDD.CurrentRun.AddScenario()
                .Given(s.a_method_with_the_xBDD_ScenarioFact_attribute_named_MethodName)
                .When(s.a_call_is_made_to_MethodCall)
                .Then(s.a_scenario_will_be_created)
                .And(s.the_scenario_name_will_match_the_method_name_with_the_underscores_replaced_with_spaces_like_ExpectedScenarioName)
                .And(s.the_feature_name_will_match_the_class_name_with_spaces_added_where_there_are_capital_letters_like_ExpectedFeatureName)
                .And(s.the_area_path_will_match_the_namespace_like_ExpectedAreaPath);
            s.Scenario.Run();
        }
        [ScenarioFact]
        public async Task InAnAsyncScenarioFact()
        {
            var s = new Steps();
            s.MethodName = new StackFrame().GetMethod().Name;
            s.ExpectedAreaPath = new StackFrame().GetMethod().DeclaringType.Namespace;
            s.ExpectedScenarioName = "In An Async Scenario Fact";
            s.ExpectedFeatureName = "Add A Scenario";
            s.ExpectedAreaPath = "xBDD.Test.Features.DefineScenarios";
            s.MethodCall = "xBDD.CurrentRun.AddScenario();";
            s.Scenario = xBDD.CurrentRun.AddScenario()
                .Given(s.a_method_with_the_xBDD_ScenarioFact_attribute_named_MethodName)
                .When(s.a_call_is_made_to_MethodCall)
                .Then(s.a_scenario_will_be_created)
                .And(s.the_scenario_name_will_match_the_method_name_with_the_underscores_replaced_with_spaces_like_ExpectedScenarioName)
                .And(s.the_feature_name_will_match_the_class_name_with_spaces_added_where_there_are_capital_letters_like_ExpectedFeatureName)
                .And(s.the_area_path_will_match_the_namespace_like_ExpectedAreaPath);
            await s.Scenario.RunAsync();
        }
        [ScenarioTheory]
        [InlineData(1,2)]
        [InlineData(3,4)]
        public void InAScenarioTheroyWithParameters(int x, int y)
        {
            var s = new Steps();
            s.MethodName = new StackFrame().GetMethod().Name;
            s.ExpectedAreaPath = new StackFrame().GetMethod().DeclaringType.Namespace;
            s.ExpectedScenarioName = "In A Scenario Theory With Parameter X As " + x + " And Y As " + y;
            s.ExpectedFeatureName = "Add A Scenario";
            s.ExpectedAreaPath = "xBDD.Test.Features.DefineScenarios";
            s.MethodCall = "xBDD.CurrentRun.AddScenario();";
            s.X = x;
            s.Y = y;
            s.Scenario = xBDD.CurrentRun.AddScenario("In A Scenario Theory With Parameter X As " + x.ToString() + " And Y As " + y.ToString())
                .Given(s.a_method_with_the_xBDD_ScenarioTheory_attribute_named_MethodName)
                .When(s.a_call_is_made_to_MethodCall)
                .Then(s.a_scenario_will_be_created)
                .And(s.the_scenario_name_will_match_the_method_name_with_the_underscores_replaced_with_spaces_like_ExpectedScenarioName)
                .And(s.the_feature_name_will_match_the_class_name_with_spaces_added_where_there_are_capital_letters_like_ExpectedFeatureName)
                .And(s.the_area_path_will_match_the_namespace_like_ExpectedAreaPath);
            s.Scenario.Run();
        }
        [ScenarioFact]
        public void InAnAsyncScenarioTheory()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void InARegularMethodNoScenarioFactOrTheory()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
    }
}
