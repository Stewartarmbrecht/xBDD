using System;
using System.Reflection;

namespace xBDD
{
    public class Factory : IFactory
    {
        public IScenario CreateFeature()
        {
            return new Scenario(this);
        }

        public IStep CreateStep()
        {
            return new Step();
        }

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

        public IAttribute CreateAttribute(CustomAttributeData data)
        {
            return new AttributeWrapper(data);
        }

        public IFeatureNameReader GetFeatureNameReader()
        {
            return new FeatureNameReader();
        }
    }
}
