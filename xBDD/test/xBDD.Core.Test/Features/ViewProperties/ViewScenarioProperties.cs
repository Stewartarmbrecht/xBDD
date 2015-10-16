using xBDD.Test.Features;
using Xunit;
using Xunit.Abstractions;

namespace xBDD.Core.Test.Features.ViewProperties
{
    [Collection("xBDDCoreTest")]
    public class ViewScenarioProperties : Feature
    {
        public ViewScenarioProperties(ITestOutputHelper outputWriter)
            : base(outputWriter)
        {

        }
        [ScenarioFact]
        public void Name()
        {
            xB.CurrentRun.AddScenario(this).Skip("Not Started");
        }
        [ScenarioFact]
        public void Outcome()
        {
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Re-writing");
            //var s = new Steps();
            //xBDD.CurrentRun
            //    .AddScenario(this)
            //    .SetOutputWriter(outputWriter)
            //    .When(s.When.a_scenario_is_added_to_a_test_run)
            //    .Then(s.Then.you_can_get_not_set_the_Outcome_property)
            //    .Run();
        }
        [ScenarioFact]
        public void StartTime()
        {
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Re-writing");
            //var s = new Steps();
            //xBDD.CurrentRun
            //    .AddScenario(this)
            //    .SetOutputWriter(outputWriter)
            //    .When(s.When.a_scenario_is_added_to_a_test_run)
            //    .Then(s.Then.you_can_get_not_set_the_StartTime_property)
            //    .Run();
        }
        [ScenarioFact]
        public void EndTime()
        {
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Re-writing");
            //var s = new Steps();
            //xBDD.CurrentRun
            //    .AddScenario(this)
            //    .SetOutputWriter(outputWriter)
            //    .When(s.When.a_scenario_is_added_to_a_test_run)
            //    .Then(s.Then.you_can_get_not_set_the_EndTime_property)
            //    .Run();
        }
        [ScenarioFact]
        public void TotalTime()
        {
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Re-writing");
            //var s = new Steps();
            //xBDD.CurrentRun
            //    .AddScenario(this)
            //    .SetOutputWriter(outputWriter)
            //    .When(s.When.a_scenario_is_added_to_a_test_run)
            //    .Then(s.Then.you_can_get_not_set_the_TotalTime_property)
            //    .Run();
        }
        [ScenarioFact]
        public void FeatureName()
        {
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void AreaPath()
        {
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void State()
        {
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
        [ScenarioFact]
        public void Steps()
        {
            xB.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Not Started");
        }
    }
}
