using xBDD.Reporting.Database.Core;
using Xunit;

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
        public int SaveChangesCount { get; set; }
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
        internal void a_completed_test_run(Step step)
        {
            Core.CoreFactory factory = new Core.CoreFactory();
            state.c.TestRun = new TestRun(factory);
            state.c.TestRun
                .AddScenario("My Scenario", "My Feature", "My.Area.Path", this)
                .Given("my given condition", st => { })
                .When("my when step", st => { })
                .Then("my then validation", st => { })
                .Run();

        }
        internal void an_empty_test_results_database(Step step)
        {
            DatabaseContext context = new DatabaseContext(state.ConnectionName);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
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
        internal void SaveChanges_is_called_on_the_test_run(Step step)
        {
            state.SaveChangesCount = state.c.TestRun.SaveToDatabase(state.ConnectionName);
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
        internal void all_test_run_results_should_be_saved_to_a_new_database(Step step)
        {
            Assert.Equal(5, state.SaveChangesCount);
        }
    }

}
