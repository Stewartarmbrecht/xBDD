using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace xBDD.Test.Features.Environment
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
        internal void the_solution_is_set_to_the_Publish_configuration(IStep obj) { }
        internal void there_is_a_valid_connection_string_set_for_the_ConfigurationSetting_setting(IStep obj)
        {
            obj.SetNameWithReplacement("ConfigurationSetting", "Data:DefaultConnection:ConnectionString".Quote());
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
        internal void a_developer_pushes_a_commit_to_the_GitHub_repository(IStep obj) { }

        internal void the_tests_are_run(IStep obj) { }
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
        internal void a_visual_studio_online_build_should_trigger(IStep obj) { }
        internal void it_should_publish_the_test_results_to_that_database(IStep obj) { }
        internal void publish_the_xBDD_test_restults_to_an_azure_database(IStep obj) { }
        internal void publish_the_xUnit_test_restults_to_visual_studio_online(IStep obj) { }
        internal void run_the_tests(IStep obj) { }
        internal void build_the_projects(IStep obj) { }
    }

}
