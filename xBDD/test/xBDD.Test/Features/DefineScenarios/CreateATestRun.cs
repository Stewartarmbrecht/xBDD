using System.Text;
using xBDD.xUnit;
using Xunit.Abstractions;

namespace xBDD.Test.Features.DefineScenarios
{
    public class CreateATestRun
    {
        private readonly IOutputWriter outputWriter;

        public CreateATestRun(ITestOutputHelper output)
        {
            outputWriter = new OutputWriter(output);
        }

        Steps s = new Steps();
        [ScenarioFact]
        public void ThroughxBDDCurrentTestRun()
        {
            s.State.MethodCall = "xBDD.CurrentRun";
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .When(s.When.the_first_call_is_made_to_MethodCall)
                .Then(s.Then.the_system_should_create_a_new_test_run)
                .Run();
        }
        [ScenarioFact]
        public void ThroughxBDDCurrentTestRun2Times()
        {
            s.State.MethodCall = "xBDD.CurrentRun";
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .When(s.When.the_first_call_is_made_to_MethodCall)
                .And(s.When.a_second_call_is_made_to_MethodCall)
                .And(s.Then.the_system_should_return_the_same_test_run_from_the_first_call_as_the_second_call)
                .Run();
        }
        [ScenarioFact]
        public void Manually()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("var factory = new CoreFactory();");
            sb.AppendLine("var testRun = new TestRun(factory);");
            s.State.MethodCall = sb.ToString();
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .When(s.When.the_following_code_is_executed)
                .And(s.Then.the_system_should_set_the_testRun_variable_with_a_new_test_run)
                .Run();
        }
    }
}
