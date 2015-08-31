using System.Reflection;

namespace xBDD
{
    public interface ITestNameReader
    {
        string ReadTestName(string testName, IMethod method);
    }
}