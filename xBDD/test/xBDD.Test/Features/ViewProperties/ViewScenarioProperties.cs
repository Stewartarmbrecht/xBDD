using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Test.Features.ViewProperties
{
    public class ViewScenarioProperties
    {
        [ScenarioFact]
        public void Name()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void Outcome()
        {
            var s = new Steps();
            xBDD.CurrentRun.AddScenario()
                .When(s.a_step_is_added_to_a_scenario)
                .Then(s.you_can_get_not_set_the_Outcome_property)
                .Run();
        }
        [ScenarioFact]
        public void StartTime()
        {
            var s = new Steps();
            xBDD.CurrentRun.AddScenario()
                .When(s.a_step_is_added_to_a_scenario)
                .Then(s.you_can_get_not_set_the_StartTime_property)
                .Run();
        }
        [ScenarioFact]
        public void EndTime()
        {
            var s = new Steps();
            xBDD.CurrentRun.AddScenario()
                .When(s.a_step_is_added_to_a_scenario)
                .Then(s.you_can_get_not_set_the_EndTime_property)
                .Run();
        }
        [ScenarioFact]
        public void TotalTime()
        {
            var s = new Steps();
            xBDD.CurrentRun.AddScenario()
                .When(s.a_step_is_added_to_a_scenario)
                .Then(s.you_can_get_not_set_the_TotalTime_property)
                .Run();
        }
        [ScenarioFact]
        public void FeatureName()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void AreaPath()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void State()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
        [ScenarioFact]
        public void Steps()
        {
            xBDD.CurrentRun.AddScenario().Skip();
        }
    }
}
