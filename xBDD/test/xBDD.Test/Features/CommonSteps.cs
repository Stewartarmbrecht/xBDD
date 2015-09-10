using System;
using System.Threading.Tasks;
using xBDD.Core;
using xBDD.Test.Sample;

namespace xBDD.Test.Features
{
    public class CommonSteps
    {
        public CommonSteps()
        {
            State = new CommonState();
            Given = new CommonGivenSteps(State);
            When = new CommonWhenSteps(State);
            Then = new CommonThenSteps(State);
        }
        public CommonState State { get; set; }
        public CommonGivenSteps Given { get; set; }
        public CommonWhenSteps When { get; set; }
        public CommonThenSteps Then { get; set; }

    }
    public class CommonState
    {
        public Outcome ExpectedOutcome { get; internal set; }
        public IScenario Scenario { get; set; }
        public IStep Step { get; set; }
        public Exception CaughtException { get; set; }
        public string MultilineParameter { get; internal set; }
        public string MethodCall { get; internal set; }
    }
    [StepLibrary]
    public class CommonGivenSteps
    {
        CommonState state;
        public CommonGivenSteps(CommonState state)
        {
            this.state = state;
        }
        internal void a_scenario(IStep step)
        {
            var factory = new CoreFactory();
            var testRun = new TestRun(factory);
            state.Scenario = testRun.AddScenario();
        }
    }

    [StepLibrary]
    public class CommonWhenSteps
    {
        CommonState state;
        public CommonWhenSteps(CommonState state)
        {
            this.state = state;
        }
        internal void the_scenario_is_run(IStep obj)
        {
            state.Scenario.Run();
        }
    }

    [StepLibrary]
    public class CommonThenSteps
    {
        CommonState state;
        public CommonThenSteps(CommonState state)
        {
            this.state = state;
        }
    }

}
