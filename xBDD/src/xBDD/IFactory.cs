using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace xBDD
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
    }
}
