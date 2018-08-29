namespace xBDD.Features.Actors
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using TemplateValidator;
    using xBDD;
	using xBDD.Model;
    using xBDD.Browser;

	public class Developer: User
	{
		internal const string Name = "developer";
		internal Step HaveTheFollowingClass(string description, string pathToFile)
		{
            var step = xB.CreateStep(
                $"you have a similar class in your test project {description}:",
                (s) => { 
                    var path = $"{System.IO.Directory.GetCurrentDirectory()}../../../../{pathToFile}";
                    
                    string code = null;
                    try {
                        code = File.ReadAllText(path);
                        s.Output = code;
                        s.OutputFormat = TextFormat.cs;
                    } catch(System.Exception ex)
                    {
                        code = $"Exception encountered getting file content: {ex.Message}";
                        s.Output = code;
                        s.OutputFormat = TextFormat.cs;
                        throw;
                    }
                });
            return step;

		}
		internal Step RunTheTests(List<Func<Task>> scenarios, xBDDMock xBMock)
		{
            var step = xB.CreateAsyncStep(
                $"run the tests",
                async (s) => { 
                    var currentTestRun = xB.CurrentRun;
                    Exception exception = null;
                    xB.CurrentRun = xBMock.CurrentRun;
                    await scenarios.ForEachAsync(async scenario => {
                        if(exception == null) {
                            try {
                                await scenario();
                            } catch(Exception ex) {
                                exception = ex;
                            }
                        }
                    });
                    xB.CurrentRun = currentTestRun;
                }, "dotnet test", TextFormat.sh);
            return step;

		}
        internal Step RunTheMSTestProject(string command, string changeDirectory, Wrapper<string> output)
        {
            var fullCommand = $"{command} --no-build | Out-File ./test-output/testoutput.txt";
            var step = xB.CreateStep(
                "you run the MS Test Project with the following command:",
                (s) => { 
                    Process cmd = new Process();
                    cmd.StartInfo.FileName = "pwsh";
                    cmd.StartInfo.RedirectStandardInput = true;
                    cmd.StartInfo.RedirectStandardOutput = true;
                    cmd.StartInfo.CreateNoWindow = true;
                    cmd.StartInfo.UseShellExecute = false;
                    cmd.Start();

                    cmd.StandardInput.WriteLine($"Set-Location {changeDirectory}");
                    cmd.StandardInput.Flush();
                    cmd.StandardInput.WriteLine(fullCommand);
                    cmd.StandardInput.Flush();
                    cmd.StandardInput.Close();
                    cmd.WaitForExit(60000);
                    cmd.Close();
                    cmd.Dispose();
                    using (var fileStream = new FileStream($"{changeDirectory}test-output/testoutput.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        using (var textReader = new StreamReader(fileStream))
                        {
                            output.Object = textReader.ReadToEnd();
                            s.Output = output.Object;
                            s.OutputFormat = TextFormat.text;
                        }
                    }
                },
                command,
                TextFormat.sh);
            return step;
        }

        internal Step HaveATestProjectThatProducesAllOutcomes()
        {

            var stepName = "you have a test project that produces all outcomes";

            var step = xB.CreateStep(
                stepName,
                (s) =>
                {
                });
            return step;
        }

        internal Step HaveTheFollowingTestSetupAndBreakdownClass(string focus)
        {
            return this.HaveTheFollowingClass(
                $"for setting up and breaking down the test run {focus}", 
                "../MySample.Features/TestSetupAndBreakdown.cs");

        }

        internal Step ExecuteTheTestRun()
        {

            var stepName = "you execute the tests in the test project";

            var step = xB.CreateStep(
                stepName,
                (s) =>
                {
                });
            return step;
        }

        internal Step WillSeeTheOutputMatches(string templateFilePath, string outputFilePath, string description = null)
        {
            if(description == null)
            {
                description = "you will see the output matches this template (See TemplateValidator project on Nuget):";
            }
            var step = xB.CreateStep(
                description,
                (s) => {
                    var output = "";
                    try {
                        var outputPath = $"{System.IO.Directory.GetCurrentDirectory()}../../../../{outputFilePath}";
                        output = File.ReadAllText(outputPath);

                        var templatePath = $"{System.IO.Directory.GetCurrentDirectory()}../../../../{templateFilePath}";
                        var template = "";
                        if(!System.IO.File.Exists(templatePath)) {
                            File.WriteAllText(templatePath, output);
                            throw new System.Exception("Template file did not exist but it was created by using a copy of the target.");
                        } else {
                            template = File.ReadAllText(templatePath);
                        }
                        s.InputParameter = template;
                        s.MultilineParameterFormat = TextFormat.text;                 
                        output.ValidateToTemplate(template);   
                    } catch(System.Exception)
                    {
                        s.Output = output;
                        s.OutputFormat = TextFormat.text;
                        throw;
                    }
                });
            return step;
        }
        internal Step WillSeeTheTextReportMatches(string templateFilePath, Wrapper<string> textReportOutput, string description = null)
        {
            if(description == null)
            {
                description = "you will see the text report matches this template (See TemplateValidator project on Nuget):";
            }
            var step = xB.CreateStep(
                description,
                (s) => {
                    try {
                        var templatePath = $"{System.IO.Directory.GetCurrentDirectory()}../../../../{templateFilePath}";
                        var template = File.ReadAllText(templatePath);
                        s.InputParameter = template;
                        s.MultilineParameterFormat = TextFormat.text;    
                        s.Output = textReportOutput.Object;
                        s.OutputFormat = TextFormat.text;             
                        textReportOutput.Object.ValidateToTemplate(template);   
                    } catch(System.Exception)
                    {
                        s.Output = textReportOutput.Object;
                        s.OutputFormat = TextFormat.text;
                        throw;
                    }
                });
            return step;
        }
	}
}