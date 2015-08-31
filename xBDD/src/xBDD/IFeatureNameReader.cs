using System.Reflection;

namespace xBDD
{
    public interface IFeatureNameReader
    {
        string ReadFeatureName(string featureName, IMethod method);
    }
}