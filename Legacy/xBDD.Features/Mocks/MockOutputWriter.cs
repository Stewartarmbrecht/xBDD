using System.Text;

namespace xBDD.Features.Mocks
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
