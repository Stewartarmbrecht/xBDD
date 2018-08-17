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

        internal Step ExecuteATestRunWithAFullTestRunWithAllOutcomes(xBDDMock xBDD)
        {

            var stepName = "you execute a full test run with all outcomes";

            var step = xB.CreateAsyncStep(
                stepName,
                async (s) =>
                {
                    await xBDD.RunATestRunWithAFullTestRunWithAllOutcomes();
                });
            return step;
        }

        internal Step WillSeeTheOutputMatches(string templateFilePath, Wrapper<string> output)
        {
            var path = $"{System.IO.Directory.GetCurrentDirectory()}../../../../{templateFilePath}";
            var template = File.ReadAllText(path);
            var step = xB.CreateStep(
                "you will see the output matches this template (See TemplateValidator project on Nuget):",
                (s) => {
                    try {
                        output.Object.ValidateToTemplate(template);   
                        //s.Output = output.Object;
                        //s.OutputFormat = TextFormat.text;                 
                    } catch(System.Exception)
                    {
                        s.Output = output.Object;
                        s.OutputFormat = TextFormat.text;
                        throw;
                    }
                },
                template,
                TextFormat.text);
            return step;
        }

	}
}