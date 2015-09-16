using System;
using System.Reflection;

namespace xBDD.Utility
{
    internal class UtilityFactory
    {
        internal ScenarioNameReader GetScenarioNameReader()
        {
            return new ScenarioNameReader();
        }

        internal StepNameReader GetStepNameReader()
        {
            return new StepNameReader();
        }

        internal MethodRetriever GetMethodRetriever()
        {
            return new MethodRetriever(this);
        }

        internal Method CreateMethod(MethodBase methodBase)
        {
            return new Method(methodBase, this);
        }

        internal AttributeWrapper CreateAttribute(Attribute attr)
        {
            return new AttributeWrapper(attr);
        }

        internal FeatureNameReader GetFeatureNameReader()
        {
            return new FeatureNameReader();
        }

        internal AreaPathReader GetAreaPathReader()
        {
            return new AreaPathReader();
        }

        internal OutcomeAggregator CreateOutcomeAggregator()
        {
            return new OutcomeAggregator();
        }
    }
}
