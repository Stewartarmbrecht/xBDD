using System;
using System.IO;
//using Microsoft.Dnx.Runtime;
//using Microsoft.Dnx.Runtime.Infrastructure;
//using Microsoft.Framework.DependencyInjection;
using TemplateValidator;
using xBDD.Model;

namespace xBDD.Reporting.Features.Steps
{
    public static class TextReport
    {
        internal static Step ShouldMatch(string templateFile, 
            Wrapper<string> testResults, bool writeActual = false, 
            string extension = "txt", TextFormat format = TextFormat.text)
        {
            var directory = System.AppContext.BaseDirectory;
            // directory = directory.Substring(0, directory.LastIndexOf(System.IO.Path.DirectorySeparatorChar));
            // directory = directory.Substring(0, directory.LastIndexOf(System.IO.Path.DirectorySeparatorChar));
            // directory = directory.Substring(0, directory.LastIndexOf(System.IO.Path.DirectorySeparatorChar));
            var templateFilePath = directory + templateFile;

            bool createTemplate = false;
            var template = "";

            if (!File.Exists(templateFilePath))
                createTemplate = true;
            else
                template = File.ReadAllText(templateFilePath);
            if(format == TextFormat.htmlpreview)
            {
                var htmlOpen = File.ReadAllText(directory + "HtmlOpen.html");
                var htmlClose = File.ReadAllText(directory + "HtmlClose.html");
                template = htmlOpen + template + htmlClose;
            }

            var step = xB.CreateStep(
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
    }
}