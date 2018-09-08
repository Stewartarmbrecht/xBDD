using System;
using System.IO;
using System.Linq;
using xBDD.Model;
using xBDD.Browser;
using System.Threading.Tasks;

namespace xBDD.Features.Actors
{
    public class HtmlReportUser: BrowserUser
    {
        public Step WillSeeTheHtmlReportIsNotCreated(string reportName)
        {
            var step = xB.CreateStep(
                $"you will see the html report is not created",
                (s) => {
                    var sep = System.IO.Path.DirectorySeparatorChar;
                    if(System.IO.File.Exists($"{sep}..{sep}..{sep}..{sep}..{sep}MySample.Feature{sep}test-results{sep}{reportName}")) {
                        throw new Exception("The report exists.");
                    }
                    return;
                });
            return step;
        }

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
                    var htmlReport = xBDD.CurrentRun.TestRun.WriteToHtmlTestRunReport();
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
                    var htmlReport = xBDD.CurrentRun.TestRun.WriteToHtmlTestRunReport();
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
                    var xBDD = new xBDDMock();
                    await xBDD.RunATestRunWithAFullTestRunWithAllOutcomes();
                    var htmlReport = xBDD.CurrentRun.TestRun.WriteToHtmlTestRunReport(null, failuresOnly);
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
                    var htmlReport = xBDD.CurrentRun.TestRun.WriteToHtmlTestRunReport();
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
                    var htmlReport = xBDD.CurrentRun.TestRun.WriteToHtmlTestRunReport();
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
                    var htmlReport = xBDD.CurrentRun.TestRun.WriteToHtmlTestRunReport();
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
                    var htmlReport = xBDD.CurrentRun.TestRun.WriteToHtmlTestRunReport(areaNameSkip, failuresOnly);
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
                    var htmlReport = xBDD.CurrentRun.TestRun.WriteToHtmlTestRunReport();
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
                        .Skip("Defining", reason => { } );
                    var htmlReport = xBDD.CurrentRun.TestRun.WriteToHtmlTestRunReport(null, failuresOnly);
                    File.WriteAllText(path, htmlReport);
                });
            return step;
        }

        internal Step GenerateAReportWithAnEmptyTestRun()
        {
            string path = this.GetReportPath("WithAnEmptyTestRun");

            var step = xB.CreateStep(
                "you generate an html report from test results of an empty test run",
                (s) =>
                {
                    var xBDD = new xBDDMock();
                    xBDD.CurrentRun.TestRun.Name = "My Test Run";
                    var htmlReport = xBDD.CurrentRun.TestRun.WriteToHtmlTestRunReport();
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
                    var htmlReport = sampleTestRun.CurrentRun.TestRun.WriteToHtmlTestRunReport();
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
                    sampleTestRun.CurrentRun.TestRun.SortTestRunResults(new System.Collections.Generic.List<string>(SampleApp.Features.SampleFeatureSort.SortedFeatureNames));
                    var htmlReport = sampleTestRun.CurrentRun.TestRun.WriteToHtmlTestRunReport();
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