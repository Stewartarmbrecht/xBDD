//using System;
//using Xunit;

//namespace xBDD.Test.Features.RunningScenarios
//{
//    [StepLibrary]
//    public class RunningScenariosSteps : CommonSteps
//    {
//        public string ExpectedScenarioName { get; set; }
//        public string ExpectedFeatureName { get; set; }
//        public string ExpectedAreaPath { get; set; }

//        public string ExpectedStep1Name { get; set; }
//        public string ExpectedStep2Name { get; set; }
//        public string ExpectedStep3Name { get; set; }
//        public string ExpectedExceptionMessage { get; set; }
//        public string ExpectedReason { get; set; }

//        public void the_scenario_name_should_come_from_the_fact_method_name(IStep step)
//        {
//            Assert.Equal(ExpectedScenarioName, SimpleTestRun.Scenario.Name);
//        }

//        public void the_feature_name_should_come_from_the_class_name(IStep step)
//        {
//            Assert.Equal(ExpectedFeatureName, SimpleTestRun.Scenario.FeatureName);
//        }

//        public void the_step_name_should_come_from_the_method_name(IStep step)
//        {
//            Assert.Equal(ExpectedStep1Name, SimpleTestRun.Scenario.Steps[0].Name);
//            Assert.Equal(ExpectedStep2Name, SimpleTestRun.Scenario.Steps[1].Name);
//            Assert.Equal(ExpectedStep3Name, SimpleTestRun.Scenario.Steps[2].Name);
//        }

//        internal void the_step_reason_should_be_ExpectedReason(IStep step)
//        {
//            step.SetNameWithReplacement("ExpectedReason", ExpectedReason.Quote());
//            Assert.Equal(ExpectedReason, SimpleTestRun.Scenario.Steps[1].Reason);
//        }

//        internal void the_step_outcome_should_show_skipped(IStep step)
//        {
//            Assert.Equal(Outcome.Skipped, SimpleTestRun.Scenario.Steps[1].Outcome);
//        }

//        public void the_step_exception_shoul_have_a_message_of_ExpectedExceptionMessage(IStep step)
//        {
//            step.SetNameWithReplacement("ExpectedExceptionMessage", ExpectedExceptionMessage);
//            Assert.Equal(ExpectedExceptionMessage, CaughtException.Message);
//        }

//        public void the_area_path_should_come_from_the_namespace(IStep step)
//        {
//            Assert.Equal(ExpectedAreaPath, SimpleTestRun.Scenario.AreaPath);
//        }

//        public void the_step_outcome_should_show_failed(IStep step)
//        {
//            Assert.Equal(Outcome.Failed, SimpleTestRun.Scenario.Steps[1].Outcome);
//        }

//        public void the_step_outcome_should_show_passed(IStep step)
//        {
//            Assert.Equal(Outcome.Passed, SimpleTestRun.Scenario.Steps[0].Outcome);
//        }

//        public void the_step_start_date_should_be_before_the_step_captured_time(IStep step)
//        {
//            Assert.True(SimpleTestRun.Scenario.State.CapturedTime > SimpleTestRun.Scenario.Steps[2].StartTime);
//        }

//        public void the_step_end_date_should_be_after_the_step_captured_time(IStep step)
//        {
//            Assert.True(SimpleTestRun.Scenario.State.CapturedTime < SimpleTestRun.Scenario.Steps[2].EndTime);
//        }

//    }
//}
