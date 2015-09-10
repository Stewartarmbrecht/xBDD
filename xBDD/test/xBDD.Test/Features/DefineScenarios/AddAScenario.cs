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
            s.State.MethodName = new StackFrame().GetMethod().Name;
            s.State.ExpectedAreaPath = new StackFrame().GetMethod().DeclaringType.Namespace;
            s.State.ExpectedScenarioName = "In A Scenario Fact";
            s.State.ExpectedFeatureName = "Add A Scenario";
            s.State.ExpectedAreaPath = "xBDD.Test.Features.DefineScenarios";
            s.State.MethodCall = "xBDD.CurrentRun.AddScenario();";
            s.State.Scenario = xBDD.CurrentRun.AddScenario()
                .Given(s.Given.a_method_with_the_xBDD_ScenarioFact_attribute_named_MethodName)
                .When(s.When.the_first_call_is_made_to_MethodCall)
                .Then(s.Then.a_scenario_will_be_created)
                .And(s.Then.the_scenario_name_will_match_the_method_name_with_the_underscores_replaced_with_spaces_like_ExpectedScenarioName)
                .And(s.Then.the_feature_name_will_match_the_class_name_with_spaces_added_where_there_are_capital_letters_like_ExpectedFeatureName)
                .And(s.Then.the_area_path_will_match_the_namespace_like_ExpectedAreaPath);
            s.State.Scenario.Run();
        }
        [ScenarioFact]
        public async Task InAnAsyncScenarioFact()
        {
            var s = new Steps();
            s.State.MethodName = new StackFrame().GetMethod().Name;
            s.State.ExpectedAreaPath = new StackFrame().GetMethod().DeclaringType.Namespace;
            s.State.ExpectedScenarioName = "In An Async Scenario Fact";
            s.State.ExpectedFeatureName = "Add A Scenario";
            s.State.ExpectedAreaPath = "xBDD.Test.Features.DefineScenarios";
            s.State.MethodCall = "xBDD.CurrentRun.AddScenario();";
            s.State.Scenario = xBDD.CurrentRun.AddScenario()
                .Given(s.Given.a_method_with_the_xBDD_ScenarioFact_attribute_named_MethodName)
                .When(s.When.the_first_call_is_made_to_MethodCall)
                .Then(s.Then.a_scenario_will_be_created)
                .And(s.Then.the_scenario_name_will_match_the_method_name_with_the_underscores_replaced_with_spaces_like_ExpectedScenarioName)
                .And(s.Then.the_feature_name_will_match_the_class_name_with_spaces_added_where_there_are_capital_letters_like_ExpectedFeatureName)
                .And(s.Then.the_area_path_will_match_the_namespace_like_ExpectedAreaPath);
            await s.State.Scenario.RunAsync();
        }
        [ScenarioTheory]
        [InlineData(1,2)]
        [InlineData(3,4)]
        public void InAScenarioTheroyWithParameters(int x, int y)
        {
            var s = new Steps();
            s.State.MethodName = new StackFrame().GetMethod().Name;
            s.State.ExpectedAreaPath = new StackFrame().GetMethod().DeclaringType.Namespace;
            s.State.ExpectedScenarioName = "In A Scenario Theory With Parameter X As " + x + " And Y As " + y;
            s.State.ExpectedFeatureName = "Add A Scenario";
            s.State.ExpectedAreaPath = "xBDD.Test.Features.DefineScenarios";
            s.State.MethodCall = "xBDD.CurrentRun.AddScenario();";
            s.State.X = x;
            s.State.Y = y;
            s.State.Scenario = xBDD.CurrentRun.AddScenario("In A Scenario Theory With Parameter X As " + x.ToString() + " And Y As " + y.ToString())
                .Given(s.Given.a_method_with_the_xBDD_ScenarioTheory_attribute_named_MethodName)
                .When(s.When.the_first_call_is_made_to_MethodCall)
                .Then(s.Then.a_scenario_will_be_created)
                .And(s.Then.the_scenario_name_will_match_the_method_name_with_the_underscores_replaced_with_spaces_like_ExpectedScenarioName)
                .And(s.Then.the_feature_name_will_match_the_class_name_with_spaces_added_where_there_are_capital_letters_like_ExpectedFeatureName)
                .And(s.Then.the_area_path_will_match_the_namespace_like_ExpectedAreaPath);
            s.State.Scenario.Run();
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
