using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.Tracing;

namespace xBDD
{
    public class OutputWriter : IOutputWriter
    {
        public void WriteLine(string text)
        {
            System.Diagnostics.Debug.WriteLine(text);
        }
    }
}
