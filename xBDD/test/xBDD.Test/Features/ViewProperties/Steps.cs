using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xBDD.Core;

namespace xBDD.Test.Features.ViewProperties
{
    public class Steps
    {
        public StepsState State { get; set; }
        public GivenSteps Given { get; set; }
        public WhenSteps When { get; set; }
        public ThenSteps Then { get; set; }
        public Steps()
        {
            State = new StepsState();
            Given = new GivenSteps(State);
            When = new WhenSteps(State);
            Then = new ThenSteps(State);
        }
    }
    public class StepsState : CommonState
    {
    }

    [StepLibrary]
    public class GivenSteps : CommonGivenSteps
    {
        StepsState state;
        public GivenSteps(StepsState state)
            : base(state)
        {
            this.state = state;
        }
    }
    [StepLibrary]
    public class WhenSteps : CommonWhenSteps
    {
        StepsState state;
        public WhenSteps(StepsState state)
            : base(state)
        {
            this.state = state;
        }
        internal void a_scenario_is_added_to_a_test_run(IStep obj)
        {
            var factory = new CoreFactory();
            var testRun = new TestRun(factory);
            state.Scenario = testRun.AddScenario("Test Scenario");
        }
    }
    [StepLibrary]
    public class ThenSteps : CommonThenSteps
    {
        StepsState state;
        public ThenSteps(StepsState state)
            : base(state)
        {
            this.state = state;
        }
        internal void you_can_get_not_set_the_TotalTime_property(IStep obj)
        {
            TimeSpan dateTime = state.Scenario.Time;
        }
        internal void you_can_get_not_set_the_EndTime_property(IStep obj)
        {
            DateTime dateTime = state.Scenario.EndTime;
        }
        internal void you_can_get_not_set_the_StartTime_property(IStep obj)
        {
            DateTime dateTime = state.Scenario.StartTime;
        }
        internal void you_can_get_not_set_the_Outcome_property(IStep obj)
        {
            Outcome outcome = state.Scenario.Outcome;
        }

    }

}
