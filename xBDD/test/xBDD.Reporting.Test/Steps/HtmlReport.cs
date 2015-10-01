using System;
using System.IO;
using Microsoft.Dnx.Runtime;
using Microsoft.Dnx.Runtime.Infrastructure;
using Microsoft.Framework.DependencyInjection;
using TemplateValidator;
using xBDD.Model;

namespace xBDD.Reporting.Test.Steps
{
    public static class HtmlReport
    {
        internal static Step ShouldMatch(string templateFile, 
            Wrapper<string> testResults, bool writeActual = false, 
            string extension = "txt", TextFormat format = TextFormat.text)
        {
            var provider = CallContextServiceLocator.Locator.ServiceProvider;
            var appEnv = provider.GetRequiredService<IApplicationEnvironment>();
            var templateFilePath = appEnv.ApplicationBasePath + templateFile;

            bool createTemplate = false;
            var template = "";

            if (!File.Exists(templateFilePath))
                createTemplate = true;
            else
                template = File.ReadAllText(templateFilePath);
            if(format == TextFormat.htmlpreview)
            {
                var directory = templateFilePath.Substring(0, templateFilePath.LastIndexOf('\\') + 1);
                var htmlOpen = File.ReadAllText(directory + "HtmlOpen.html");
                var htmlClose = File.ReadAllText(directory + "HtmlClose.html");
                template = htmlOpen + template + htmlClose;
            }

            var step = xBDD.CreateStep(
                "the test results written should match the template:",
                (s) => {
                    if (writeActual)
                    {
                        File.WriteAllText(templateFilePath + ".actual." + extension, testResults.Object);
                    }

                    if (createTemplate)
                    {
                        File.WriteAllText(templateFilePath, testResults.Object);
                        throw new Exception("Template file did not exist but it was created.  Please modify the template to execute the test properly.");
                    }
                    else
                        testResults.Object.ValidateToTemplate(template);
                },
                template,
                format);
            return step;
        }

        internal static Step OfAStepWithOutput(string output, TextFormat format)
        {
            string path = GetReportPath();

            var step = xBDD.CreateStep(
                "the test results of a passing test run",
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
                });
            return step;
        }

        internal static Step OfASinglePassingScenario()
        {
            string path = GetReportPath();

            var step = xBDD.CreateStep(
                "the test results of a passing test run",
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
                "the test results of a passing test run",
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
                "the test results of a skipped test run",
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