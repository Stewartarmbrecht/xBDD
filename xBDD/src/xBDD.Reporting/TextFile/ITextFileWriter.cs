using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Reporting.TextFile
{
    public interface ITextFileWriter
    {
        void WriteToFile(ITestRun testRun, string fileName);
    }
}
