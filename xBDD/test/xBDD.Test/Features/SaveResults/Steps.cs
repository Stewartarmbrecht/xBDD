using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xBDD.Database;
using xBDD.Database.Core;
using xBDD.Test.Sample;
using Xunit;

namespace xBDD.Test.Features.SaveResults
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
        public string ConnectionName = "Data:TestingConnection:ConnectionString";
        public int SaveChangesCount { get; set; }
        public ISimpleTestRun SimpleTestRun { get; set; }
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
        internal void a_completed_test_run(IStep step)
        {
            state.SimpleTestRun = new SimpleTestRunUsingTypedState();
            state.SimpleTestRun.PassingScenario();
        }
        internal void an_empty_test_results_database(IStep step)
        {
            DatabaseContext context = new DatabaseContext(state.ConnectionName);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
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
        internal void SaveChanges_is_called_on_the_test_run(IStep step)
        {
            state.SaveChangesCount = state.SimpleTestRun.SaveToDatabase(state.ConnectionName);
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
        internal void all_test_run_results_should_be_saved_to_a_new_database(IStep step)
        {
            Assert.Equal(5, state.SaveChangesCount);
        }
    }

}
