using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Test.Features.DefineScenarios
{
    public class CreateATestRun
    {
        Steps s = new Steps();
        [ScenarioFact]
        public void ThroughxBDDCurrentTestRun()
        {
            s.State.MethodCall = "xBDD.CurrentRun";
            xBDD.CurrentRun.AddScenario()
                .When(s.When.the_first_call_is_made_to_MethodCall)
                .Then(s.Then.the_system_should_create_a_new_test_run)
                .Run();

        }
        [ScenarioFact]
        public void ThroughxBDDCurrentTestRun2Times()
        {
            s.State.MethodCall = "xBDD.CurrentRun";
            xBDD.CurrentRun.AddScenario()
                .When(s.When.the_first_call_is_made_to_MethodCall)
                .And(s.When.a_second_call_is_made_to_MethodCall)
                .And(s.Then.the_system_should_return_the_same_test_run_from_the_first_call_as_the_second_call)
                .Run();

        }
        [ScenarioFact]
        public void Manually()
        {
            s.State.MethodCall = "var factory = new CoreFactory();\nvar testRun = new TestRun(factory);";
            xBDD.CurrentRun.AddScenario()
                .When(s.When.the_following_code_is_executed)
                .And(s.Then.the_system_should_set_the_testRun_variable_with_a_new_test_run)
                .Run();

        }
    }
}
