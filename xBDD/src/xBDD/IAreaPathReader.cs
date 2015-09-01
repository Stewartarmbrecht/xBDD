using System.Reflection;

namespace xBDD
{
    public interface IAreaPathReader
    {
        string ReadAreaPath(string featureName, IMethod method);
    }
}