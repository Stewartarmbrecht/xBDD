using System;
using System.IO;
using System.Linq;
using xBDD.Model;

namespace xBDD.Reporting.Test.Steps
{
    public static class HtmlReport
    {
        internal static Step OfAFailingStepWithAnException()
        {
            string path = GetReportPath();

            var step = xB.CreateAsyncStep(
                "the test results with a failed step with an exception",
                async (s) =>
                {
                    var xBDD = new xBDDMock();
                    xBDD.CurrentRun.TestRun.Name = "My Test Run";
                    try
                    {
                        await xBDD.CurrentRun.AddScenario("My Scenario 1", "My Feature 1", "My Area 11")
                            .Given("my step 1", (s2) => { })
                            .When("my step 2", (s2) => { throw new Exception("My Error"); })
                            .Then("my step 3", (s2) => { })
                            .Run();
                    }
                    catch { }
                    var htmlReport = await xBDD.CurrentRun.TestRun.WriteToHtml();
                    File.WriteAllText(path, htmlReport);
                });
            return step;
        }

        internal static Step OfAPassingFullTestRun()
        {
            string path = GetReportPath();

            var step = xB.CreateAsyncStep(
                "the test results of a passing full test run",
                async (s) =>
                {
                    var xBDD = new xBDDMock();
                    xBDD.CurrentRun.TestRun.Name = "My Test Run";
                    await xBDD.CurrentRun.AddScenario("My Scenario 1", "My Feature 1", "My Area 1")
                        .Given("my step 1", (s2) => { })
                        .When("my step 2", (s2) => { })
                        .Then("my step 3", (s2) => { })
                        .Run();
                    await xBDD.CurrentRun.AddScenario("My Scenario 2", "My Feature 1", "My Area 1")
                        .Given("my step 4", (s2) => { })
                        .When("my step 5", (s2) => { })
                        .Then("my step 6", (s2) => { })
                        .Run();
                    await xBDD.CurrentRun.AddScenario("My Scenario 3", "My Feature 2", "My Area 1")
                        .Given("my step 7", (s2) => { })
                        .When("my step 8", (s2) => { })
                        .Then("my step 9", (s2) => { })
                        .Run();
                    await xBDD.CurrentRun.AddScenario("My Scenario 4", "My Feature 2", "My Area 1")
                        .Given("my step 10", (s2) => { })
                        .When("my step 11", (s2) => { })
                        .Then("my step 12", (s2) => { })
                        .Run();
                    await xBDD.CurrentRun.AddScenario("My Scenario 5", "My Feature 3", "My Area 2")
                        .Given("my step 13", (s2) => { })
                        .When("my step 14", (s2) => { })
                        .Then("my step 15", (s2) => { })
                        .Run();
                    await xBDD.CurrentRun.AddScenario("My Scenario 6", "My Feature 3", "My Area 2")
                        .Given("my step 16", (s2) => { })
                        .When("my step 17", (s2) => { })
                        .Then("my step 18", (s2) => { })
                        .Run();
                    await xBDD.CurrentRun.AddScenario("My Scenario 7", "My Feature 4", "My Area 2")
                        .Given("my step 19", (s2) => { })
                        .When("my step 20", (s2) => { })
                        .Then("my step 21", (s2) => { })
                        .Run();
                    await xBDD.CurrentRun.AddScenario("My Scenario 8", "My Feature 4", "My Area 2")
                        .Given("my step 22", (s2) => { })
                        .When("my step 23", (s2) => { })
                        .Then("my step 24", (s2) => { })
                        .Run();
                    var htmlReport = await xBDD.CurrentRun.TestRun.WriteToHtml();
                    File.WriteAllText(path, htmlReport);
                });
            return step;
        }

        internal static Step OfAFullTestRunWithAllOutcomes()
        {
            string path = GetReportPath();

            var step = xB.CreateAsyncStep(
                "the test results of a full test run with all outcomes",
                async (s) =>
                {
                    int stepCounter = 0;
                    int scenarioCounter = 0;
                    int featureCounter = 0;
                    int[] skippedScenarios = new int[] { 10, 11, 13, 14, 20, 22, 23 };
                    int failedSetp = 56;
                    var xBDD = new xBDDMock();
                    xBDD.CurrentRun.TestRun.Name = "My Test Run";
                    for(int ia = 0; ia < 3; ia++)
                    {
                        var areaName = "My Area " + (ia + 1);
                        for(int ife = 0; ife < 3; ife++ )
                        {
                            featureCounter++;
                            var featureName = "My Feature " + featureCounter;
                            for(int isc = 0; isc < 3; isc++ )
                            {
                                scenarioCounter++;
                                var scenarioName = "My Scenario " + scenarioCounter;
                                var scenario = xBDD.CurrentRun.AddScenario(scenarioName, featureName, areaName);
                                stepCounter++;
                                scenario.Given("my step " + stepCounter, (s2) => { });
                                stepCounter++;
                                if(stepCounter == failedSetp)
                                    scenario.When("my failed step " + stepCounter, (s2) => { throw new Exception("My Error"); });
                                else
                                    scenario.When("my step 2", (s2) => { });
                                stepCounter++;
                                scenario.Then("my step 3", (s2) => { });
                                try
                                {
                                    if(skippedScenarios.Contains(scenarioCounter))
                                        await scenario.Skip("Deferred");
                                    else
                                        await scenario.Run();
                                }
                                catch { }
                            }                            
                        }
                    }
                    var htmlReport = await xBDD.CurrentRun.TestRun.WriteToHtml();
                    File.WriteAllText(path, htmlReport);
                });
            return step;
        }

        internal static Step OfAFailingStepWithANestedException()
        {
            string path = GetReportPath();

            var step = xB.CreateAsyncStep(
                "the test results with a failed step with an exception",
                async (s) =>
                {
                    var xBDD = new xBDDMock();
                    xBDD.CurrentRun.TestRun.Name = "My Test Run";
                    try
                    {
                        await xBDD.CurrentRun.AddScenario("My Scenario 1", "My Feature 1", "My Area 11")
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
                    var htmlReport = await xBDD.CurrentRun.TestRun.WriteToHtml();
                    File.WriteAllText(path, htmlReport);
                });
            return step;
        }

        internal static Step OfAStepWithOutput(string output, TextFormat format)
        {
            string path = GetReportPath();

            var step = xB.CreateAsyncStep(
                "the test results of a step with a/an " + Enum.GetName(typeof(TextFormat), format) + " output of ",
                async (s) =>
                {
                    var xBDD = new xBDDMock();
                    xBDD.CurrentRun.TestRun.Name = "My Test Run";
                    await xBDD.CurrentRun.AddScenario("My Scenario 1", "My Feature 1", "My Area 1")
                        .Given("my step 1", (s2) => { 
                            s2.Output = output;
                            s2.OutputFormat = TextFormat.text; 
                        })
                        .When("my step 2", (s2) => {
                            
                         })
                        .Then("my step 3", (s2) => { })
                        .Run();
                    var htmlReport = await xBDD.CurrentRun.TestRun.WriteToHtml();
                    File.WriteAllText(path, htmlReport);
                },
                output,
                format);
            return step;
        }

        internal static Step OfASinglePassingScenario(string value = null, string actor = null, string capability = null)
        {
            System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + "OfASinglePassingScenario Start");
            string path = GetReportPath();

            var step = xB.CreateAsyncStep(
                "the test results of a single passing scenario",
                async (s) =>
                {
                    var xBDD = new xBDDMock();
                    xBDD.CurrentRun.TestRun.Name = "My Test Run";
                    await xBDD.CurrentRun.AddScenario("My Scenario 1", "My Feature 1", "My Area 1")
                        .Given("my step 1", (s2) => { })
                        .When("my step 2", (s2) => { })
                        .Then("my step 3", (s2) => { })
                        .Run();
                    xBDD.CurrentRun.TestRun.Areas[0].Features[0].Actor = actor;
                    xBDD.CurrentRun.TestRun.Areas[0].Features[0].Value = value;
                    xBDD.CurrentRun.TestRun.Areas[0].Features[0].Capability = capability;
                    var htmlReport = await xBDD.CurrentRun.TestRun.WriteToHtml();
                    File.WriteAllText(path, htmlReport);
                });
            System.Diagnostics.Trace.TraceInformation(DateTime.Now.ToString("HH:mm:ss.fff") + "OfASinglePassingScenario End");
            return step;
        }

        internal static Step OfASingleFailedScenario()
        {
            string path = GetReportPath();

            var step = xB.CreateAsyncStep(
                "the test results of a single failed scenario",
                async (s) =>
                {
                    var xBDD = new xBDDMock();
                    xBDD.CurrentRun.TestRun.Name = "My Test Run";
                    try
                    {
                        await xBDD.CurrentRun.AddScenario("My Scenario 1", "My Feature 1", "My Area 1")
                            .Given("my step 1", (s2) => { })
                            .When("my step 2", (s2) => { throw new Exception("My Error"); })
                            .Then("my step 3", (s2) => { })
                            .Run();
                    }
                    catch { }
                    var htmlReport = await xBDD.CurrentRun.TestRun.WriteToHtml();
                    File.WriteAllText(path, htmlReport);
                });
            return step;
        }

        internal static Step OfASingleSkippedScenario()
        {
            string path = GetReportPath();

            var step = xB.CreateAsyncStep(
                "the test results of a single skipped scenario",
                async (s) =>
                {
                    var xBDD = new xBDDMock();
                    xBDD.CurrentRun.TestRun.Name = "My Test Run";
                    await xBDD.CurrentRun.AddScenario("My Scenario 1", "My Feature 1", "My Area 1")
                        .Given("my step 1", (s2) => { })
                        .When("my step 2", (s2) => { })
                        .Then("my step 3", (s2) => { })
                        .Skip("Not Started");
                    var htmlReport = await xBDD.CurrentRun.TestRun.WriteToHtml();
                    File.WriteAllText(path, htmlReport);
                });
            return step;
        }

        internal static Step OfAnEmptyTestRun()
        {
            string path = GetReportPath();

            var step = xB.CreateAsyncStep(
                "the test results of an empty test run",
                async (s) =>
                {
                    var xBDD = new xBDDMock();
                    xBDD.CurrentRun.TestRun.Name = "My Test Run";
                    var htmlReport = await xBDD.CurrentRun.TestRun.WriteToHtml();
                    File.WriteAllText(path, htmlReport);
                });
            return step;
        }

        private static string GetReportPath()
        {
            var location = System.Reflection.Assembly.GetEntryAssembly().Location;
            var directory = System.IO.Path.GetDirectoryName(location);
            var path = directory + "\\TestHtmlReport.html";
            return path;
        }
    }
}