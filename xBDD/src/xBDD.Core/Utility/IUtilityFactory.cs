using System.Reflection;

namespace xBDD.Utility
{
    public interface IUtilityFactory
    {
        IAreaPathReader GetAreaPathReader();
        IFeatureNameReader GetFeatureNameReader();
        IScenarioNameReader GetScenarioNameReader();
        IStepNameReader GetStepNameReader();
        IOutcomeAggregator CreateOutcomeAggregator();
        IMethod CreateMethod(MethodBase methodBase);
        IMethodRetriever GetMethodRetriever();
        IAttributeWrapper CreateAttribute(CustomAttributeData data);
    }
}
