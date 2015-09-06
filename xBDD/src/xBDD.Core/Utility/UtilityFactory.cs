using System.Reflection;

namespace xBDD.Utility
{
    public class UtilityFactory : IUtilityFactory
    {
        public IScenarioNameReader GetScenarioNameReader()
        {
            return new ScenarioNameReader();
        }

        public IStepNameReader GetStepNameReader()
        {
            return new StepNameReader();
        }

        public IMethodRetriever GetMethodRetriever()
        {
            return new MethodRetriever(this);
        }

        public IMethod CreateMethod(MethodBase methodBase)
        {
            return new Method(methodBase, this);
        }

        public IAttributeWrapper CreateAttribute(CustomAttributeData data)
        {
            return new AttributeWrapper(data);
        }

        public IFeatureNameReader GetFeatureNameReader()
        {
            return new FeatureNameReader();
        }

        public IAreaPathReader GetAreaPathReader()
        {
            return new AreaPathReader();
        }

        public IOutcomeAggregator CreateOutcomeAggregator()
        {
            return new OutcomeAggregator();
        }
    }
}
