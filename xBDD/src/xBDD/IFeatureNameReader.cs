using System.Reflection;

namespace xBDD
{
    public interface IFeatureNameReader
    {
        string ReadFeatureName(IMethod method);
    }
}