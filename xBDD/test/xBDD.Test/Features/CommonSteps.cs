using System;
using System.Text;
using System.Threading.Tasks;
using xBDD.Core;
using xBDD.Test.Mocks;
using xBDD.Test.Sample;
using Xunit;

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
        public TestRun TestRun { get; internal set; }
        public string ScenarioName { get; internal set; }
        public string StepName { get; internal set; }
        public MockOutputWriter OutputWriter { get; internal set; }
        public string Output { get; internal set; }
    }
    [StepLibrary]
    public class CommonGivenSteps
    {
        CommonState state;
        public CommonGivenSteps(CommonState state)
        {
            this.state = state;
        }
        internal void a_test_run(IStep step)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("var factory = new CoreFactory();");
            sb.AppendLine("var testRun = new TestRun(factory);");
            step.SetMultilineParameter(sb.ToString());
            var factory = new CoreFactory();
            state.TestRun = new TestRun(factory);
        }
        internal void a_scenario(IStep step)
        {
            if(state.TestRun == null)
            {
                var factory = new CoreFactory();
                state.TestRun = new TestRun(factory);
            }
            state.Scenario = state.TestRun.AddScenario();
        }
        internal void a_scenario_with_the_name_ScenarioName(IStep step)
        {
            step.ReplaceNameParameters("ScenarioName", state.ScenarioName.Quote());
            step.SetMultilineParameter("testRun.AddScenario(\"" + state.ScenarioName + "\");");
            if (state.TestRun == null)
            {
                var factory = new CoreFactory();
                state.TestRun = new TestRun(factory);
            }
            state.Scenario = state.TestRun.AddScenario(state.ScenarioName);
        }
        internal void a_given_step_with_the_name_StepName(IStep step)
        {
            step.ReplaceNameParameters("StepName", state.StepName.Quote());
            step.SetMultilineParameter("scenario.Given(\""+state.StepName+"\", step => {});");
            if (state.TestRun == null)
            {
                var factory = new CoreFactory();
                state.TestRun = new TestRun(factory);
            }
            state.Scenario.Given(state.StepName, stepTarget => { });
            state.Step = state.Scenario.Steps[state.Scenario.Steps.Count -1];
        }
        internal void the_scenario_is_set_to_write_its_output(IStep step)
        {
            step.SetMultilineParameter("scenario.SetOutputWriter(outputWriter);");
            state.OutputWriter = new MockOutputWriter();
            state.Scenario.SetOutputWriter(state.OutputWriter);
        }
        internal void the_step_has_a_multiline_parameter_of(IStep step)
        {
            step.SetMultilineParameter(state.MultilineParameter);
            state.Step.SetMultilineParameter(state.MultilineParameter);
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
        internal void the_scenario_is_run_and_the_exception_caught(IStep step)
        {
            try
            {
                state.Scenario.Run();
            }
            catch (Exception ex)
            {
                state.CaughtException = ex;
            }
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
        internal void the_scenario_should_write_the_following_output(IStep obj)
        {
            Assert.Equal(state.Output, state.OutputWriter.Output);
        }
    }

}
