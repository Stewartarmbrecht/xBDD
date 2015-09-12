using System;
using xBDD.Test.Helpers;
using Xunit;

namespace xBDD.Test.Features.Helpers
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

    public class StepsState
    {
        public bool Match { get; internal set; }
        public string Template { get; internal set; }
        public string Target { get; internal set; }
        public bool Result { get; internal set; }
        public string ExceptionMessage { get; internal set; }
        public Exception Exception { get; internal set; }
    }

    [StepLibrary]
    public class GivenSteps
    {
        StepsState state;
        public GivenSteps(StepsState state)
        {
            this.state = state;
        }

        internal void a_matching_pattern_of(IStep step)
        {
            step.SetMultilineParameter(state.Target);
        }

        internal void a_target_of(IStep step)
        {
            step.SetMultilineParameter(state.Template);
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

        internal void the_target_is_compared_to_the_matching_pattern(IStep step)
        {
            try
            {
                state.Target.ValidateToTemplate(state.Template);
            }
            catch(Exception ex)
            {
                state.Exception = ex;
            }
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

        internal void the_result_should_be_match(IStep step)
        {
            Assert.Null(state.Exception);
        }

        internal void an_exception_should_be_thrown(IStep step)
        {
            Assert.NotNull(state.Exception);
            Assert.Equal(state.ExceptionMessage, state.Exception.Message);
        }
        internal void the_exception_message_should_be(IStep step)
        {
            step.SetMultilineParameter(state.ExceptionMessage);
            Assert.Equal(state.ExceptionMessage, state.Exception.Message);
        }
    }
}
