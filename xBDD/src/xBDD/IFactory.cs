using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace xBDD
{
    public interface IFactory
    {
        ITestNameReader GetTestNameReader();
        IStepNameReader GetStepNameReader();
        IMethodRetriever GetMethodRetriever();
        ITestCase CreateTestCase();
        ITestStep CreateTestStep();

        IMethod CreateMethod(MethodBase methodBase);
        IAttribute CreateAttribute(CustomAttributeData data);
    }
}
