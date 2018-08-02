using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.Tracing;

namespace xBDD
{
    /// <summary>
    /// Used by xBDD to write output while running.
    /// </summary>
    public class OutputWriter : IOutputWriter
    {
        /// <summary>
        /// Writes a line of output.
        /// </summary>
        /// <param name="text">The text to write.</param>
        public void WriteLine(string text)
        {
            System.Diagnostics.Trace.WriteLine(text);
        }
    }
}
