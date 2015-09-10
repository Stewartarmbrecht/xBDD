using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xBDD.Test.Mocks
{
    public class MockOutputWriter : IOutputWriter
    {
        StringBuilder buffer = new StringBuilder();

        public string Output { get { return buffer.ToString(); } }

        public void WriteLine(string text)
        {
            buffer.AppendLine(text);
        }
    }
}
