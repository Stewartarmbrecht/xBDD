using xBDD.Core;

namespace xBDD.Utility
{
    public interface IAreaPathReader
    {
        string ReadAreaPath(string featureName, IMethod method);
    }
}