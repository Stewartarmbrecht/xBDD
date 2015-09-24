using Microsoft.Dnx.Runtime;
using Microsoft.Dnx.Runtime.Infrastructure;
using Microsoft.Framework.DependencyInjection;
using System.IO;
using xBDD.xUnit;
using Xunit;
using Xunit.Abstractions;
using System;

namespace xBDD.Test.Features.SaveResults
{
    [Collection("TestRunCollection")]
    public class WriteToText
    {
        private readonly OutputWriter outputWriter;

        public WriteToText(ITestOutputHelper output)
        {
            outputWriter = new OutputWriter(output);
        }

        [ScenarioFact]
        public void WriteEmtpyTestRun()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Re-writing");
            //var s = new Steps();
            //s.c.State.TestRunName = "My Test Run";
            //s.State.FileName = "EmptyTestRun.txt";
            //var provider = CallContextServiceLocator.Locator.ServiceProvider;
            //var appEnv = provider.GetRequiredService<IApplicationEnvironment>();

            //s.State.ExpectedFileText = File.ReadAllText(appEnv.ApplicationBasePath + "\\Features\\WriteResults\\TextFiles\\EmptyTestRun.txt");
            //xBDD.CurrentRun
            //    .AddScenario(this)
            //    .SetOutputWriter(outputWriter)
            //    .Given(s.c.Given.a_test_run_with_name_TestRunName)
            //    .And("the xBDD.Reporting package is referenced", step => { })
            //    .When(s.When.the_WriteToText_method_is_called_on_the_test_run)
            //    .Then(s.Then.the_text_writen_will_match_the_following)
            //    .Run();
        }
        [ScenarioFact]
        public void WriteSkippedEmptyScenario()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Re-writing");
            //var s = new Steps();
            //s.c.State.TestRunName = "My Test Run";
            //s.c.State.FeatureName = "My Feature";
            //s.c.State.AreaPath = "My.Area.Path";
            //s.c.State.ScenarioName = "My Scenario";
            //s.State.FileName = "MyTestRun.txt";
            //s.c.State.ScenarioReason = "Deferred";
            //var provider = CallContextServiceLocator.Locator.ServiceProvider;
            //var appEnv = provider.GetRequiredService<IApplicationEnvironment>();

            //s.State.ExpectedFileText = File.ReadAllText(appEnv.ApplicationBasePath + "\\Features\\WriteResults\\TextFiles\\SkippedEmptyScenario.txt");
            //xBDD.CurrentRun
            //    .AddScenario(this)
            //    .SetOutputWriter(outputWriter)
            //    .Given(s.c.Given.a_test_run_with_name_TestRunName)
            //    .And("the xBDD.Reporting package is referenced", step => { })
            //    .And(s.c.Given.a_scenario_AreaPath_FeatureName_ScenarioName)
            //    .When(s.c.When.the_scenario_is_skipped_with_reason_of_ScenarioReason)
            //    .And(s.When.the_WriteToText_method_is_called_on_the_test_run)
            //    .Then(s.Then.the_text_writen_will_match_the_following)
            //    .Run();
        }
        [ScenarioFact]
        public void WriteRunEmptyScenario()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Re-writing");
            //var s = new Steps();
            //s.c.State.TestRunName = "My Test Run";
            //s.c.State.FeatureName = "My Feature";
            //s.c.State.AreaPath = "My.Area.Path";
            //s.c.State.ScenarioName = "My Scenario";
            //s.State.FileName = "MyTestRun.txt";
            //var provider = CallContextServiceLocator.Locator.ServiceProvider;
            //var appEnv = provider.GetRequiredService<IApplicationEnvironment>();

            //s.State.ExpectedFileText = File.ReadAllText(appEnv.ApplicationBasePath + "\\Features\\WriteResults\\TextFiles\\RunEmptyScenario.txt");
            //xBDD.CurrentRun
            //    .AddScenario(this)
            //    .SetOutputWriter(outputWriter)
            //    .Given(s.c.Given.a_test_run_with_name_TestRunName)
            //    .And("the xBDD.Reporting package is referenced", step => { })
            //    .And(s.c.Given.a_scenario_AreaPath_FeatureName_ScenarioName)
            //    .When(s.c.When.the_scenario_is_run)
            //    .And(s.When.the_WriteToText_method_is_called_on_the_test_run)
            //    .Then(s.Then.the_text_writen_will_match_the_following)
            //    .Run();
        }
        [ScenarioFact]
        public void WriteSkippedScenarioWithSteps()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Re-writing");
            //var s = new Steps();
            //s.c.State.TestRunName = "My Test Run";
            //s.c.State.FeatureName = "My Feature";
            //s.c.State.AreaPath = "My.Area.Path";
            //s.c.State.ScenarioName = "My Scenario";
            //s.State.FileName = "MyTestRun.txt";
            //s.c.State.ScenarioReason = "Deferred";
            //var provider = CallContextServiceLocator.Locator.ServiceProvider;
            //var appEnv = provider.GetRequiredService<IApplicationEnvironment>();

            //s.State.ExpectedFileText = File.ReadAllText(appEnv.ApplicationBasePath + "\\Features\\WriteResults\\TextFiles\\SkippedScenarioWithSteps.txt");
            //xBDD.CurrentRun
            //    .AddScenario(this)
            //    .SetOutputWriter(outputWriter)
            //    .Given(s.c.Given.a_test_run_with_name_TestRunName)
            //    .And("the xBDD.Reporting package is referenced", step => { })
            //    .And(s.c.Given.a_scenario_AreaPath_FeatureName_ScenarioName)
            //    .And(s.c.Given.the_scenario_has_three_steps)
            //    .When(s.c.When.the_scenario_is_skipped_with_reason_of_ScenarioReason)
            //    .And(s.When.the_WriteToText_method_is_called_on_the_test_run)
            //    .Then(s.Then.the_text_writen_will_match_the_following)
            //    .Run();
        }
        [ScenarioFact]
        public void WriteRunScenarioWithSteps()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Re-writing");
            //var s = new Steps();
            //s.c.State.TestRunName = "My Test Run";
            //s.c.State.FeatureName = "My Feature";
            //s.c.State.AreaPath = "My.Area.Path";
            //s.c.State.ScenarioName = "My Scenario";
            //s.State.FileName = "MyTestRun.txt";
            //var provider = CallContextServiceLocator.Locator.ServiceProvider;
            //var appEnv = provider.GetRequiredService<IApplicationEnvironment>();

            //s.State.ExpectedFileText = File.ReadAllText(appEnv.ApplicationBasePath + "\\Features\\WriteResults\\TextFiles\\RunScenarioWithSteps.txt");
            //xBDD.CurrentRun
            //    .AddScenario(this)
            //    .SetOutputWriter(outputWriter)
            //    .Given(s.c.Given.a_test_run_with_name_TestRunName)
            //    .And("the xBDD.Reporting package is referenced", step => { })
            //    .And(s.c.Given.a_scenario_AreaPath_FeatureName_ScenarioName)
            //    .And(s.c.Given.the_scenario_has_three_steps)
            //    .When(s.c.When.the_scenario_is_run)
            //    .And(s.When.the_WriteToText_method_is_called_on_the_test_run)
            //    .Then(s.Then.the_text_writen_will_match_the_following)
            //    .Run();
        }
        [ScenarioFact]
        public void WriteRunScenarioWithSkippedStep()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Re-writing");
            //var s = new Steps();
            //s.c.State.TestRunName = "My Test Run";
            //s.c.State.FeatureName = "My Feature";
            //s.c.State.AreaPath = "My.Area.Path";
            //s.c.State.ScenarioName = "My Scenario";
            //s.State.FileName = "MyTestRun.txt";
            //s.c.State.SkipReason = "Deferred";
            //var provider = CallContextServiceLocator.Locator.ServiceProvider;
            //var appEnv = provider.GetRequiredService<IApplicationEnvironment>();

            //s.State.ExpectedFileText = File.ReadAllText(appEnv.ApplicationBasePath + "\\Features\\WriteResults\\TextFiles\\RunScenarioWithSkippedStep.txt");
            //xBDD.CurrentRun
            //    .AddScenario(this)
            //    .SetOutputWriter(outputWriter)
            //    .Given(s.c.Given.a_test_run_with_name_TestRunName)
            //    .And("the xBDD.Reporting package is referenced", step => { })
            //    .And(s.c.Given.a_scenario_AreaPath_FeatureName_ScenarioName)
            //    .And(s.c.Given.the_scenario_has_three_steps)
            //    .And(s.Given.one_of_the_steps_throws_a_SkipStepException_with_a_reason_of_SkipReason)
            //    .When(s.c.When.the_scenario_is_run_and_the_exception_caught)
            //    .And(s.When.the_WriteToText_method_is_called_on_the_test_run)
            //    .Then(s.Then.the_text_writen_will_match_the_following)
            //    .Run();
        }
        [ScenarioFact]
        public void WriteRunScenarioWithNotImplementedStep()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Re-writing");
            //var s = new Steps();
            //s.c.State.TestRunName = "My Test Run";
            //s.c.State.FeatureName = "My Feature";
            //s.c.State.AreaPath = "My.Area.Path";
            //s.c.State.ScenarioName = "My Scenario";
            //s.State.FileName = "MyTestRun.txt";
            //s.c.State.SkipReason = "Deferred";
            //s.c.State.ExceptionStepIndex = 1;
            //s.c.State.StepException = new NotImplementedException();
            //var provider = CallContextServiceLocator.Locator.ServiceProvider;
            //var appEnv = provider.GetRequiredService<IApplicationEnvironment>();

            //s.State.ExpectedFileText = File.ReadAllText(appEnv.ApplicationBasePath + "\\Features\\WriteResults\\TextFiles\\RunScenarioWithNotImplementedStep.txt");
            //xBDD.CurrentRun
            //    .AddScenario(this)
            //    .SetOutputWriter(outputWriter)
            //    .Given(s.c.Given.a_test_run_with_name_TestRunName)
            //    .And("the xBDD.Reporting package is referenced", step => { })
            //    .And(s.c.Given.a_scenario_AreaPath_FeatureName_ScenarioName)
            //    .And(s.c.Given.the_scenario_has_three_steps)
            //    .And(s.c.Given.the_ExceptionStepIndex_step_throws_a_ExceptionType_exception)
            //    .When(s.c.When.the_scenario_is_run_and_the_exception_caught)
            //    .And(s.When.the_WriteToText_method_is_called_on_the_test_run)
            //    .Then(s.Then.the_text_writen_will_match_the_following)
            //    .Run();
        }
        [ScenarioFact]
        public void WriteRunScenarioWithFailedStep()
        {
            xBDD.CurrentRun
                .AddScenario(this)
                .SetOutputWriter(outputWriter)
                .Skip("Re-writing");
            //var s = new Steps();
            //s.c.State.TestRunName = "My Test Run";
            //s.c.State.FeatureName = "My Feature";
            //s.c.State.AreaPath = "My.Area.Path";
            //s.c.State.ScenarioName = "My Scenario";
            //s.State.FileName = "MyTestRun.txt";
            //s.c.State.SkipReason = "Deferred";
            //s.c.State.ExceptionStepIndex = 1;
            //s.c.State.StepException = new Exception("My Error");
            //var provider = CallContextServiceLocator.Locator.ServiceProvider;
            //var appEnv = provider.GetRequiredService<IApplicationEnvironment>();

            //s.State.ExpectedFileText = File.ReadAllText(appEnv.ApplicationBasePath + "\\Features\\WriteResults\\TextFiles\\RunScenarioWithFailedStep.txt");
            //xBDD.CurrentRun
            //    .AddScenario(this)
            //    .SetOutputWriter(outputWriter)
            //    .Given(s.c.Given.a_test_run_with_name_TestRunName)
            //    .And("the xBDD.Reporting package is referenced", step => { })
            //    .And(s.c.Given.a_scenario_AreaPath_FeatureName_ScenarioName)
            //    .And(s.c.Given.the_scenario_has_three_steps)
            //    .And(s.c.Given.the_ExceptionStepIndex_step_throws_a_ExceptionType_exception)
            //    .When(s.c.When.the_scenario_is_run_and_the_exception_caught)
            //    .And(s.When.the_WriteToText_method_is_called_on_the_test_run)
            //    .Then(s.Then.the_text_writen_will_match_the_following)
            //    .Run();
        }
    }
}
