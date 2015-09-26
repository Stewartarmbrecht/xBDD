using Microsoft.Dnx.Runtime;
using Microsoft.Dnx.Runtime.Infrastructure;
using Microsoft.Framework.DependencyInjection;
using System;
using System.IO;
using TemplateValidator;
using xBDD.Test;

namespace xBDD.Reporting.Test.Steps
{
    public static class TestResults
    {
        internal static Step ShouldMatch(string templateFile, 
            Wrapper<string> testResults, bool writeActual = false, 
            string extension = "txt", MultilineParameterFormat format = MultilineParameterFormat.literal)
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

            var step = xBDD.CreateStep(
                "the test results written to text should match the template:",
                () => {
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
    }
}