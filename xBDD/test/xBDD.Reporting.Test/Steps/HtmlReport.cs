using System;
using System.IO;
using Microsoft.Dnx.Runtime;
using Microsoft.Dnx.Runtime.Infrastructure;
using Microsoft.Framework.DependencyInjection;
using xBDD.Model;

namespace xBDD.Reporting.Test.Steps
{
    public static class HtmlReport
    {
        internal static Step OfAFailingStepWithAnException()
        {
            string path = GetReportPath();

            var step = xBDD.CreateStep(
                "the test results with a feiled step with an exception",
                (s) =>
                {
                    var xBDD = new xBDDMock();
                    xBDD.CurrentRun.TestRun.Name = "My Test Run";
                    try
                    {
                        xBDD.CurrentRun.AddScenario("My Scenario 1", "My Feature 1", "My Area 11")
                            .Given("my step 1", (s2) => { })
                            .When("my step 2", (s2) => { throw new Exception("My Error"); })
                            .Then("my step 3", (s2) => { })
                            .Run();
                    }
                    catch { }
                    var htmlReport = xBDD.CurrentRun.TestRun.WriteToHtml();
                    File.WriteAllText(path, htmlReport);
                });
            return step;
        }

        internal static Step OfAPassingFullTestRun()
        {
            string path = GetReportPath();

            var step = xBDD.CreateStep(
                "the test results of a passing full test run",
                (s) =>
                {
                    var xBDD = new xBDDMock();
                    xBDD.CurrentRun.TestRun.Name = "My Test Run";
                    xBDD.CurrentRun.AddScenario("My Scenario 1", "My Feature 1", "My Area 1")
                        .Given("my step 1", (s2) => { })
                        .When("my step 2", (s2) => { })
                        .Then("my step 3", (s2) => { })
                        .Run();
                    xBDD.CurrentRun.AddScenario("My Scenario 2", "My Feature 1", "My Area 1")
                        .Given("my step 4", (s2) => { })
                        .When("my step 5", (s2) => { })
                        .Then("my step 6", (s2) => { })
                        .Run();
                    xBDD.CurrentRun.AddScenario("My Scenario 3", "My Feature 2", "My Area 1")
                        .Given("my step 7", (s2) => { })
                        .When("my step 8", (s2) => { })
                        .Then("my step 9", (s2) => { })
                        .Run();
                    xBDD.CurrentRun.AddScenario("My Scenario 4", "My Feature 2", "My Area 1")
                        .Given("my step 10", (s2) => { })
                        .When("my step 11", (s2) => { })
                        .Then("my step 12", (s2) => { })
                        .Run();
                    xBDD.CurrentRun.AddScenario("My Scenario 5", "My Feature 3", "My Area 2")
                        .Given("my step 13", (s2) => { })
                        .When("my step 14", (s2) => { })
                        .Then("my step 15", (s2) => { })
                        .Run();
                    xBDD.CurrentRun.AddScenario("My Scenario 6", "My Feature 3", "My Area 2")
                        .Given("my step 16", (s2) => { })
                        .When("my step 17", (s2) => { })
                        .Then("my step 18", (s2) => { })
                        .Run();
                    xBDD.CurrentRun.AddScenario("My Scenario 7", "My Feature 4", "My Area 2")
                        .Given("my step 19", (s2) => { })
                        .When("my step 20", (s2) => { })
                        .Then("my step 21", (s2) => { })
                        .Run();
                    xBDD.CurrentRun.AddScenario("My Scenario 8", "My Feature 4", "My Area 2")
                        .Given("my step 22", (s2) => { })
                        .When("my step 23", (s2) => { })
                        .Then("my step 24", (s2) => { })
                        .Run();
                    var htmlReport = xBDD.CurrentRun.TestRun.WriteToHtml();
                    File.WriteAllText(path, htmlReport);
                });
            return step;
        }

        internal static Step OfAFailingStepWithANestedException()
        {
            string path = GetReportPath();

            var step = xBDD.CreateStep(
                "the test results with a feiled step with an exception",
                (s) =>
                {
                    var xBDD = new xBDDMock();
                    xBDD.CurrentRun.TestRun.Name = "My Test Run";
                    try
                    {
                        xBDD.CurrentRun.AddScenario("My Scenario 1", "My Feature 1", "My Area 11")
                            .Given("my step 1", (s2) => { })
                            .When("my step 2", (s2) => {
                                try 
                                {
                                    throw new Exception("My Nested Error");    
                                } 
                                catch(Exception ex)
                                {
                                    throw new Exception("My Error", ex); 
                                }
                            })
                            .Then("my step 3", (s2) => { })
                            .Run();
                    }
                    catch { }
                    var htmlReport = xBDD.CurrentRun.TestRun.WriteToHtml();
                    File.WriteAllText(path, htmlReport);
                });
            return step;
        }

        internal static Step OfAStepWithOutput(string output, TextFormat format)
        {
            string path = GetReportPath();

            var step = xBDD.CreateStep(
                "the test results of a step with a/an " + Enum.GetName(typeof(TextFormat), format) + " output of ",
                (s) =>
                {
                    var xBDD = new xBDDMock();
                    xBDD.CurrentRun.TestRun.Name = "My Test Run";
                    xBDD.CurrentRun.AddScenario("My Scenario 1", "My Feature 1", "My Area 1")
                        .Given("my step 1", (s2) => { 
                            s2.Output = output;
                            s2.OutputFormat = TextFormat.text; 
                        })
                        .When("my step 2", (s2) => {
                            
                         })
                        .Then("my step 3", (s2) => { })
                        .Run();
                    var htmlReport = xBDD.CurrentRun.TestRun.WriteToHtml();
                    File.WriteAllText(path, htmlReport);
                },
                output,
                format);
            return step;
        }

        internal static Step OfASinglePassingScenario()
        {
            string path = GetReportPath();

            var step = xBDD.CreateStep(
                "the test results of a single passing scenario",
                (s) =>
                {
                    var xBDD = new xBDDMock();
                    xBDD.CurrentRun.TestRun.Name = "My Test Run";
                    xBDD.CurrentRun.AddScenario("My Scenario 1", "My Feature 1", "My Area 11")
                        .Given("my step 1", (s2) => { })
                        .When("my step 2", (s2) => { })
                        .Then("my step 3", (s2) => { })
                        .Run();
                    var htmlReport = xBDD.CurrentRun.TestRun.WriteToHtml();
                    File.WriteAllText(path, htmlReport);
                });
            return step;
        }

        internal static Step OfASingleFailedScenario()
        {
            string path = GetReportPath();

            var step = xBDD.CreateStep(
                "the test results of a single feiled scenario",
                (s) =>
                {
                    var xBDD = new xBDDMock();
                    xBDD.CurrentRun.TestRun.Name = "My Test Run";
                    try
                    {
                        xBDD.CurrentRun.AddScenario("My Scenario 1", "My Feature 1", "My Area 11")
                            .Given("my step 1", (s2) => { })
                            .When("my step 2", (s2) => { throw new Exception("My Error"); })
                            .Then("my step 3", (s2) => { })
                            .Run();
                    }
                    catch { }
                    var htmlReport = xBDD.CurrentRun.TestRun.WriteToHtml();
                    File.WriteAllText(path, htmlReport);
                });
            return step;
        }

        internal static Step OfASingleSkippedScenario()
        {
            string path = GetReportPath();

            var step = xBDD.CreateStep(
                "the test results of a single skipped scenario",
                (s) =>
                {
                    var xBDD = new xBDDMock();
                    xBDD.CurrentRun.TestRun.Name = "My Test Run";
                    xBDD.CurrentRun.AddScenario("My Scenario 1", "My Feature 1", "My Area 11")
                        .Given("my step 1", (s2) => { })
                        .When("my step 2", (s2) => { })
                        .Then("my step 3", (s2) => { })
                        .Skip("Not Started");
                    var htmlReport = xBDD.CurrentRun.TestRun.WriteToHtml();
                    File.WriteAllText(path, htmlReport);
                });
            return step;
        }

        internal static Step OfAnEmptyTestRun()
        {
            string path = GetReportPath();

            var step = xBDD.CreateStep(
                "the test results of an empty test run",
                (s) =>
                {
                    var xBDD = new xBDDMock();
                    xBDD.CurrentRun.TestRun.Name = "My Test Run";
                    var htmlReport = xBDD.CurrentRun.TestRun.WriteToHtml();
                    File.WriteAllText(path, htmlReport);
                });
            return step;
        }

        private static string GetReportPath()
        {
            var provider = CallContextServiceLocator.Locator.ServiceProvider;
            var appEnv = provider.GetRequiredService<IApplicationEnvironment>();
            var path = appEnv.ApplicationBasePath + "\\TestHtmlReport.html";
            return path;
        }
    }
}