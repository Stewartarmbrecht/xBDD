using TemplateValidator;

namespace xBDD.Test.Features.SaveResults
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
        public CommonState c;
        public StepsState(CommonState cs)
        {
            c = cs;
        }
        public string ConnectionName = "Data:TestingConnection:ConnectionString";

        public string ExpectedFileText { get; internal set; }
        public string FileName { get; internal set; }
        public string WrittenText { get; internal set; }
    }

    [StepLibrary]
    public class GivenSteps
    {
        StepsState state;
        public GivenSteps(StepsState state)

        {
            this.state = state;
        }
        internal void one_of_the_steps_throws_a_SkipStepException_with_a_reason_of_SkipReason(Step step)
        {
            step.ReplaceNameParameters("SkipReason", state.c.SkipReason);
            state.c.Scenario.Steps[1].Action = st => { throw new SkipStepException(state.c.SkipReason); };
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
        internal void the_WriteToText_method_is_called_on_the_test_run(Step obj)
        {
            state.WrittenText = state.c.TestRun.WriteToText();
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
        internal void the_text_writen_will_match_the_following(Step obj)
        {
            state.WrittenText.ValidateToTemplate(state.ExpectedFileText);
        }
    }

}
