namespace xBDD.Features
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using TemplateValidator;
    using xBDD.Model;

    public static class You
    {
        public static Step RunTheMSTestProject()
        {
            var step = xB.CreateStep(
                "you run the MS Test Project",
                (s) => { });
            return step;
        }

        public static Step WillSeeTheOutputMatches(string templateFilePath, string outputFilePath)
        {
            var template = You.LoadFileContent(templateFilePath);
            var output = You.LoadFileContent(outputFilePath);
            var step = xB.CreateStep(
                "you will see the output matches this template (See TemplateValidator project on Nuget):",
                (s) => {
                    try {
                        output.ValidateToTemplate(template);   
                        s.Output = output;
                        s.OutputFormat = TextFormat.sh;                 
                    } catch(System.Exception)
                    {
                        s.Output = output;
                        s.OutputFormat = TextFormat.sh;
                        throw;
                    }
                },
                template,
                TextFormat.sh);
            return step;
        }

        private static string LoadFileContent(string filePath)
        {
            var path = System.IO.Directory.GetCurrentDirectory() + "..\\..\\..\\" + filePath;
			if(System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.OSX))
			{
                path = System.IO.Directory.GetCurrentDirectory() + "//..//..//..//..//" + filePath;
            }
            
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
