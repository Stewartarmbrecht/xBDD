using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace xBDD
{
    public class Factory : IFactory
    {
        public ITestCase CreateTestCase()
        {
            return new TestCase(this);
        }

        public ITestStep CreateTestStep()
        {
            return new TestStep();
        }

        public ITestNameReader GetTestNameReader()
        {
            return new TestNameReader();
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
    }
}
