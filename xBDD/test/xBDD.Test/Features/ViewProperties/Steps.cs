using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xBDD.Core;

namespace xBDD.Test.Features.ViewProperties
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
    }

    [StepLibrary]
    public class GivenSteps
    {
        StepsState state;
        public GivenSteps(StepsState state)

        {
            this.state = state;
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
        internal void a_scenario_is_added_to_a_test_run(Step obj)
        {
            var factory = new CoreFactory();
            var testRun = new TestRun(factory);
            state.c.Scenario = testRun.AddScenario("Test Scenario", this);
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
        internal void you_can_get_not_set_the_TotalTime_property(Step obj)
        {
            TimeSpan dateTime = state.c.Scenario.Time;
        }
        internal void you_can_get_not_set_the_EndTime_property(Step obj)
        {
            DateTime dateTime = state.c.Scenario.EndTime;
        }
        internal void you_can_get_not_set_the_StartTime_property(Step obj)
        {
            DateTime dateTime = state.c.Scenario.StartTime;
        }
        internal void you_can_get_not_set_the_Outcome_property(Step obj)
        {
            Outcome outcome = state.c.Scenario.Outcome;
        }

    }

}
