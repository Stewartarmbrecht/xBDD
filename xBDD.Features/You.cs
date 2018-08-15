namespace xBDD.Features
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Threading.Tasks;
    using TemplateValidator;
    using xBDD.Model;

    public static class You
    {
        public static Step RunTheMSTestProject(string command, string changeDirectory, Wrapper<string> output)
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
                    using (var fileStream = new FileStream("../../../../Amazon.Features/test-output/testoutput.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (var textReader = new StreamReader(fileStream))
                    {
                        output.Object = textReader.ReadToEnd();
                        s.Output = output.Object;
                        s.OutputFormat = TextFormat.text;
                    }
                },
                command,
                TextFormat.sh);
            return step;
        }

        public static Step WillSeeTheOutputMatches(string templateFilePath, Wrapper<string> output)
        {
            var template = You.LoadFileContent(templateFilePath);
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

        private static string LoadFileContent(string filePath)
        {
            var path = System.IO.Directory.GetCurrentDirectory() + "../../../../" + filePath;
            
            string code = null;
            try {
                code = File.ReadAllText(path);
            } catch(System.Exception ex)
            {
                code = $"Exception encountered getting file content: {ex.Message}";
            }
            //var code = "Need to fix this...";
            return code;
        }

        public static Step CodeTheFollowingMSTestFeatureDefinition(string fileName)
        {
            var code = You.LoadFileContent(fileName);
            var step = xB.CreateStep(
                "you code the following feature definition:",
                (s) => { },
                code,
                TextFormat.cs);
            return step;
        }

        public static Step IsExecuted(Func<Step,Task> code)
        {
            return xB.CreateAsyncStep(
                "the method is executed",
                code);
        }
    }
}
