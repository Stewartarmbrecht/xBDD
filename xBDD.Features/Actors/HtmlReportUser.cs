﻿using System;
using System.IO;
using System.Linq;
using xBDD.Model;
using xBDD.Browser;

namespace xBDD.Features.Actors
{
    public class HtmlReportUser: User
    {
        internal Step GenerateAReportWithAFailingStepWithAnException()
        {
            string path = this.GetReportPath("WithAFailingStepWithAnException");

            var step = xB.CreateAsyncStep(
                "you generate an html report from test results with a failed step with an exception",
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

        internal Step GenerateAReportWithAPassingFullTestRun()
        {
            string path = this.GetReportPath("WithAPassingFullTestRun");

            var step = xB.CreateAsyncStep(
                "you generate an html report from test results of a passing full test run",
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

        internal Step GenerateAReportWithAFullTestRunWithAllOutcomes(bool failuresOnly = false)
        {
            string path = this.GetReportPath("WithAFullTestRunWithAllOutcomes");

            var stepName = "you generate an html report from test results of a full test run with all outcomes";
            if(failuresOnly)
            {
                stepName = stepName + " set to only report on failures";
            }

            var step = xB.CreateAsyncStep(
                stepName,
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
                                        await scenario.Skip("Deferred", reason => { } );
                                    else
                                        await scenario.Run();
                                }
                                catch { }
                            }                            
                        }
                    }
                    var htmlReport = await xBDD.CurrentRun.TestRun.WriteToHtml(null, failuresOnly);
                    File.WriteAllText(path, htmlReport);
                });
            return step;
        }

        internal Step GenerateAReportWithAFailingStepWithANestedException()
        {
            string path = this.GetReportPath("WithAFailingStepWithANestedException");

            var step = xB.CreateAsyncStep(
                "you generate an html report from test results with a failed step with an exception",
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

        internal Step GenerateAReportWithAStepWithOutput(string output, TextFormat format)
        {
            string path = this.GetReportPath("WithAStepWithOutput");

            var step = xB.CreateAsyncStep(
                "you generate an html report from test results of a step with a/an " + Enum.GetName(typeof(TextFormat), format) + " output of ",
                async (s) =>
                {
                    var xBDD = new xBDDMock();
                    xBDD.CurrentRun.TestRun.Name = "My Test Run";
                    await xBDD.CurrentRun.AddScenario("My Scenario 1", "My Feature 1", "My Area 1")
                        .Given("my step 1", (s2) => { 
                            s2.Output = output;
                            s2.OutputFormat = format; 
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

        internal Step GenerateAReportWithAStepWithAMultilineParameter(string input, TextFormat format)
        {
            string path = this.GetReportPath("WithAStepWithAMultilineParameter");

            var step = xB.CreateAsyncStep(
                $"you generate an html report from test results of a step with a {Enum.GetName(typeof(TextFormat), format)} formated multiline parameter of",
                async (s) =>
                {
                    var xBDD = new xBDDMock();
                    xBDD.CurrentRun.TestRun.Name = "My Test Run";
                    await xBDD.CurrentRun.AddScenario("My Scenario 1", "My Feature 1", "My Area 1")
                        .Given("my step 1", (s2) => { 
                        }, input, format)
                        .When("my step 2", (s2) => {
                            
                         })
                        .Then("my step 3", (s2) => { })
                        .Run();
                    var htmlReport = await xBDD.CurrentRun.TestRun.WriteToHtml();
                    File.WriteAllText(path, htmlReport);
                },
                input,
                format);
            return step;
        }

        internal Step GenerateAReportWithASinglePassingScenario(
            string value = null, string actor = null, string capability = null, 
            string areaNameSkip = null, bool failuresOnly = false)
        {
            string path = this.GetReportPath("WithASinglePassingScenario");

            var stepName = "you generate an html report from test results of a single passing scenario";
            if(areaNameSkip != null)
            {
                stepName = stepName + $" set to skip the string '{areaNameSkip}' in the area name";
            }

            if(failuresOnly)
            {
                stepName = stepName + " set to report only failures";
            }

            var step = xB.CreateAsyncStep(
                stepName,
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
                    var htmlReport = await xBDD.CurrentRun.TestRun.WriteToHtml(areaNameSkip, failuresOnly);
                    File.WriteAllText(path, htmlReport);
                });
            return step;
        }

        internal Step GenerateAReportWithASingleFailedScenario()
        {
            string path = this.GetReportPath("WithASingleFailedScenario");

            var step = xB.CreateAsyncStep(
                "you generate an html report from test results of a single failed scenario",
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

        internal Step GenerateAReportWithASingleSkippedScenario(bool failuresOnly = false)
        {
            string path = this.GetReportPath("WithASingleSkippedScenario");

            var stepName = "you generate an html report from test results of a single skipped scenario";
            if(failuresOnly)
            {
                stepName = stepName + " set to only report on failures";
            }

            var step = xB.CreateAsyncStep(
                stepName,
                async (s) =>
                {
                    var xBDD = new xBDDMock();
                    xBDD.CurrentRun.TestRun.Name = "My Test Run";
                    await xBDD.CurrentRun.AddScenario("My Scenario 1", "My Feature 1", "My Area 1")
                        .Given("my step 1", (s2) => { })
                        .When("my step 2", (s2) => { })
                        .Then("my step 3", (s2) => { })
                        .Skip("Not Started", reason => { } );
                    var htmlReport = await xBDD.CurrentRun.TestRun.WriteToHtml(null, failuresOnly);
                    File.WriteAllText(path, htmlReport);
                });
            return step;
        }

        internal Step GenerateAReportWithAnEmptyTestRun()
        {
            string path = this.GetReportPath("WithAnEmptyTestRun");

            var step = xB.CreateAsyncStep(
                "you generate an html report from test results of an empty test run",
                async (s) =>
                {
                    var xBDD = new xBDDMock();
                    xBDD.CurrentRun.TestRun.Name = "My Test Run";
                    var htmlReport = await xBDD.CurrentRun.TestRun.WriteToHtml();
                    File.WriteAllText(path, htmlReport);
                });
            return step;
        }

        internal Step GenerateAnHtmlReportUsingATestRunThatIsNotSorted()
        {
            string path = this.GetReportPath("ThatIsNotSorted");

            var step = xB.CreateAsyncStep(
                "you generate an html report from a test run that is not sorted",
                async (s) =>
                {
                    var sampleTestRun = await SampleApp.Features.SampleTestRun.RunTests();
                    var htmlReport = await sampleTestRun.CurrentRun.TestRun.WriteToHtml();
                    File.WriteAllText(path, htmlReport);
                });
            return step;
        }

        internal Step GenerateAnHtmlReportUsingATestRunThatIsSorted()
        {
            string path = this.GetReportPath("ThatIsSorted");

            var step = xB.CreateAsyncStep(
                "you generate an html report from a test run that is sorted",
                async (s) =>
                {
                    var sampleTestRun = await SampleApp.Features.SampleTestRun.RunTests();
                    sampleTestRun.CurrentRun.SortTestRunResults(SampleApp.Features.SampleFeatureSort.SortedFeatureNames);
                    var htmlReport = await sampleTestRun.CurrentRun.TestRun.WriteToHtml();
                    File.WriteAllText(path, htmlReport);
                });
            return step;
        }
        private string GetReportPath(string reportName)
        {
            var location = System.Reflection.Assembly.GetEntryAssembly().Location;
            var directory = System.IO.Path.GetDirectoryName(location);
            var path = directory + $"{System.IO.Path.DirectorySeparatorChar}TestResults{reportName}.html";
            return path;
        }
    }
}