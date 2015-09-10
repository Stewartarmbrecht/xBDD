using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace xBDD.Core
{
    public class OutputWriter : IOutputWriter
    {
        ITestOutputHelper testOutputHelper;
        public OutputWriter(ITestOutputHelper outputHelper)
        {
            this.testOutputHelper = outputHelper;
        }
        public void WriteLine(string text)
        {
            testOutputHelper.WriteLine(text);
        }
    }
}
