using System.Reflection;
using xBDD.Utility;

namespace xBDD.Core
{
    public interface IFactory
    {
        IScenarioNameReader GetScenarioNameReader();
        IStepNameReader GetStepNameReader();
        IMethodRetriever GetMethodRetriever();
        IScenario CreateFeature();
        IStep CreateStep();

        IMethod CreateMethod(MethodBase methodBase);
        IAttribute CreateAttribute(CustomAttributeData data);
        IFeatureNameReader GetFeatureNameReader();
        IAreaPathReader GetAreaPathReader();
    }
}
