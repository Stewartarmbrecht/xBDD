using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace xBDD.Test
{
    using xBDD.Importing.Text;
    using TemplateValidator;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [TestClass]
    public class TextImporterTest
    {
        
        [TestMethod]
        public async Task AllPassing()
        {
            TextImporter sut = new TextImporter();
            var tr = await TestRunSetup.BuildTestRun();
            tr.Name = "Sample Test Run";
            var textReport = tr.WriteToText(false);
            var generatedTestRun = sut.ImportText(textReport);
            var newTextReport = generatedTestRun.WriteToText(false);
            System.IO.File.WriteAllText("textReport.txt", textReport);
            System.IO.File.WriteAllText("newTextReport.txt", newTextReport);
            newTextReport.ValidateToTemplate(textReport);
        }
    }
}

