using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using xBDD.Reporting.Database;
using xBDD.Reporting.Database.Core;
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

        public string ExpectedFileText { get; internal set; }
        public string FileName { get; internal set; }
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
        internal void one_of_the_steps_throws_a_SkipStepException_with_a_reason_of_SkipReason(IStep step)
        {
            step.ReplaceNameParameters("SkipReason", state.SkipReason);
            state.Scenario.Steps[1].Action = st => { throw new SkipStepException(state.SkipReason); };
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

        internal void the_WriteToFile_method_is_called_on_the_test_run(IStep obj)
        {
            state.TestRun.WriteToFile(state.FileName);
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

        internal void the_file_writen_will_match_the_following(IStep obj)
        {
            var textFile = File.ReadAllText(state.FileName);
            Assert.True(Regex.Match(textFile, state.ExpectedFileText).Success);
        }
    }

}
