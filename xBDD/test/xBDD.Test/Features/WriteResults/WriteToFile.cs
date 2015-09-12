using Microsoft.Framework.Runtime;
using Microsoft.Framework.Runtime.Infrastructure;
using Microsoft.Framework.DependencyInjection;
using System.IO;
using xBDD.xUnit;
using Xunit;
using Xunit.Abstractions;
using System;

namespace xBDD.Test.Features.SaveResults
{
    [Collection("TestRunCollection")]
    public class WriteToFile
    {
        private readonly IOutputWriter outputWriter;

        public WriteToFile(ITestOutputHelper output)
        {
            outputWriter = new OutputWriter(output);
        }

        [ScenarioFact]
        public void WriteEmtpyTestRun()
        {
            var s = new Steps();
            s.State.TestRunName = "My Test Run";
            s.State.FileName = "EmptyTestRun.xml";
            var provider = CallContextServiceLocator.Locator.ServiceProvider;
            var appEnv = provider.GetRequiredService<IApplicationEnvironment>();

            s.State.ExpectedFileText = File.ReadAllText(appEnv.ApplicationBasePath + "\\Features\\WriteResults\\TextFiles\\EmptyTestRun.txt");
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Given(s.Given.a_test_run_with_name_TestRunName)
                .And("the xBDD.Reporting package is referenced", step => { })
                .When(s.When.the_WriteToFile_method_is_called_on_the_test_run)
                .Then(s.Then.the_file_writen_will_match_the_following)
                .Run();
        }
        [ScenarioFact]
        public void WriteSkippedEmptyScenario()
        {
            var s = new Steps();
            s.State.TestRunName = "My Test Run";
            s.State.FeatureName = "My Feature";
            s.State.AreaPath = "My.Area.Path";
            s.State.ScenarioName = "My Scenario";
            s.State.FileName = "MyTestRun.xml";
            s.State.ScenarioReason = "Deferred";
            var provider = CallContextServiceLocator.Locator.ServiceProvider;
            var appEnv = provider.GetRequiredService<IApplicationEnvironment>();

            s.State.ExpectedFileText = File.ReadAllText(appEnv.ApplicationBasePath + "\\Features\\WriteResults\\TextFiles\\SkippedEmptyScenario.txt");
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Given(s.Given.a_test_run_with_name_TestRunName)
                .And("the xBDD.Reporting package is referenced", step => { })
                .And(s.Given.a_scenario_AreaPath_FeatureName_ScenarioName)
                .When(s.When.the_scenario_is_skipped_with_reason_of_ScenarioReason)
                .And(s.When.the_WriteToFile_method_is_called_on_the_test_run)
                .Then(s.Then.the_file_writen_will_match_the_following)
                .Run();
        }
        [ScenarioFact]
        public void WriteRunEmptyScenario()
        {
            var s = new Steps();
            s.State.TestRunName = "My Test Run";
            s.State.FeatureName = "My Feature";
            s.State.AreaPath = "My.Area.Path";
            s.State.ScenarioName = "My Scenario";
            s.State.FileName = "MyTestRun.xml";
            var provider = CallContextServiceLocator.Locator.ServiceProvider;
            var appEnv = provider.GetRequiredService<IApplicationEnvironment>();

            s.State.ExpectedFileText = File.ReadAllText(appEnv.ApplicationBasePath + "\\Features\\WriteResults\\TextFiles\\RunEmptyScenario.txt");
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Given(s.Given.a_test_run_with_name_TestRunName)
                .And("the xBDD.Reporting package is referenced", step => { })
                .And(s.Given.a_scenario_AreaPath_FeatureName_ScenarioName)
                .When(s.When.the_scenario_is_run)
                .And(s.When.the_WriteToFile_method_is_called_on_the_test_run)
                .Then(s.Then.the_file_writen_will_match_the_following)
                .Run();
        }
        [ScenarioFact]
        public void WriteSkippedScenarioWithSteps()
        {
            var s = new Steps();
            s.State.TestRunName = "My Test Run";
            s.State.FeatureName = "My Feature";
            s.State.AreaPath = "My.Area.Path";
            s.State.ScenarioName = "My Scenario";
            s.State.FileName = "MyTestRun.xml";
            s.State.ScenarioReason = "Deferred";
            var provider = CallContextServiceLocator.Locator.ServiceProvider;
            var appEnv = provider.GetRequiredService<IApplicationEnvironment>();

            s.State.ExpectedFileText = File.ReadAllText(appEnv.ApplicationBasePath + "\\Features\\WriteResults\\TextFiles\\SkippedScenarioWithSteps.txt");
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Given(s.Given.a_test_run_with_name_TestRunName)
                .And("the xBDD.Reporting package is referenced", step => { })
                .And(s.Given.a_scenario_AreaPath_FeatureName_ScenarioName)
                .And(s.Given.the_scenario_has_three_steps)
                .When(s.When.the_scenario_is_skipped_with_reason_of_ScenarioReason)
                .And(s.When.the_WriteToFile_method_is_called_on_the_test_run)
                .Then(s.Then.the_file_writen_will_match_the_following)
                .Run();
        }
        [ScenarioFact]
        public void WriteRunScenarioWithSteps()
        {
            var s = new Steps();
            s.State.TestRunName = "My Test Run";
            s.State.FeatureName = "My Feature";
            s.State.AreaPath = "My.Area.Path";
            s.State.ScenarioName = "My Scenario";
            s.State.FileName = "MyTestRun.xml";
            var provider = CallContextServiceLocator.Locator.ServiceProvider;
            var appEnv = provider.GetRequiredService<IApplicationEnvironment>();

            s.State.ExpectedFileText = File.ReadAllText(appEnv.ApplicationBasePath + "\\Features\\WriteResults\\TextFiles\\RunScenarioWithSteps.txt");
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Given(s.Given.a_test_run_with_name_TestRunName)
                .And("the xBDD.Reporting package is referenced", step => { })
                .And(s.Given.a_scenario_AreaPath_FeatureName_ScenarioName)
                .And(s.Given.the_scenario_has_three_steps)
                .When(s.When.the_scenario_is_run)
                .And(s.When.the_WriteToFile_method_is_called_on_the_test_run)
                .Then(s.Then.the_file_writen_will_match_the_following)
                .Run();
        }
        [ScenarioFact]
        public void WriteRunScenarioWithSkippedStep()
        {
            var s = new Steps();
            s.State.TestRunName = "My Test Run";
            s.State.FeatureName = "My Feature";
            s.State.AreaPath = "My.Area.Path";
            s.State.ScenarioName = "My Scenario";
            s.State.FileName = "MyTestRun.xml";
            s.State.SkipReason = "Deferred";
            var provider = CallContextServiceLocator.Locator.ServiceProvider;
            var appEnv = provider.GetRequiredService<IApplicationEnvironment>();

            s.State.ExpectedFileText = File.ReadAllText(appEnv.ApplicationBasePath + "\\Features\\WriteResults\\TextFiles\\RunScenarioWithSkippedStep.txt");
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Given(s.Given.a_test_run_with_name_TestRunName)
                .And("the xBDD.Reporting package is referenced", step => { })
                .And(s.Given.a_scenario_AreaPath_FeatureName_ScenarioName)
                .And(s.Given.the_scenario_has_three_steps)
                .And(s.Given.one_of_the_steps_throws_a_SkipStepException_with_a_reason_of_SkipReason)
                .When(s.When.the_scenario_is_run_and_the_exception_caught)
                .And(s.When.the_WriteToFile_method_is_called_on_the_test_run)
                .Then(s.Then.the_file_writen_will_match_the_following)
                .Run();
        }
        [ScenarioFact]
        public void WriteRunScenarioWithNotImplementedStep()
        {
            var s = new Steps();
            s.State.TestRunName = "My Test Run";
            s.State.FeatureName = "My Feature";
            s.State.AreaPath = "My.Area.Path";
            s.State.ScenarioName = "My Scenario";
            s.State.FileName = "MyTestRun.xml";
            s.State.SkipReason = "Deferred";
            s.State.ExceptionStepIndex = 1;
            s.State.StepException = new NotImplementedException();
            var provider = CallContextServiceLocator.Locator.ServiceProvider;
            var appEnv = provider.GetRequiredService<IApplicationEnvironment>();

            s.State.ExpectedFileText = File.ReadAllText(appEnv.ApplicationBasePath + "\\Features\\WriteResults\\TextFiles\\RunScenarioWithNotImplementedStep.txt");
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Given(s.Given.a_test_run_with_name_TestRunName)
                .And("the xBDD.Reporting package is referenced", step => { })
                .And(s.Given.a_scenario_AreaPath_FeatureName_ScenarioName)
                .And(s.Given.the_scenario_has_three_steps)
                .And(s.Given.the_ExceptionStepIndex_step_throws_a_ExceptionType_exception)
                .When(s.When.the_scenario_is_run_and_the_exception_caught)
                .And(s.When.the_WriteToFile_method_is_called_on_the_test_run)
                .Then(s.Then.the_file_writen_will_match_the_following)
                .Run();
        }
        [ScenarioFact]
        public void WriteRunScenarioWithFailedStep()
        {
            var s = new Steps();
            s.State.TestRunName = "My Test Run";
            s.State.FeatureName = "My Feature";
            s.State.AreaPath = "My.Area.Path";
            s.State.ScenarioName = "My Scenario";
            s.State.FileName = "MyTestRun.xml";
            s.State.SkipReason = "Deferred";
            s.State.ExceptionStepIndex = 1;
            s.State.StepException = new Exception("My Error");
            var provider = CallContextServiceLocator.Locator.ServiceProvider;
            var appEnv = provider.GetRequiredService<IApplicationEnvironment>();

            s.State.ExpectedFileText = File.ReadAllText(appEnv.ApplicationBasePath + "\\Features\\WriteResults\\TextFiles\\RunScenarioWithFailedStep.txt");
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Given(s.Given.a_test_run_with_name_TestRunName)
                .And("the xBDD.Reporting package is referenced", step => { })
                .And(s.Given.a_scenario_AreaPath_FeatureName_ScenarioName)
                .And(s.Given.the_scenario_has_three_steps)
                .And(s.Given.the_ExceptionStepIndex_step_throws_a_ExceptionType_exception)
                .When(s.When.the_scenario_is_run_and_the_exception_caught)
                .And(s.When.the_WriteToFile_method_is_called_on_the_test_run)
                .Then(s.Then.the_file_writen_will_match_the_following)
                .Run();
        }
    }
}
