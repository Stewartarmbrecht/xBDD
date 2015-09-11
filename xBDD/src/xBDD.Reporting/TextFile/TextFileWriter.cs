using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xBDD.Reporting.TextFile
{
    public class TextFileWriter : ITextFileWriter
    {
        StringBuilder sb = new StringBuilder();
        public void WriteToFile(ITestRun testRun, string fileName)
        {
            sb.AppendLine(testRun.Name);
            File.WriteAllText(fileName, sb.ToString());
        }
    }
}
