using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD
{
    public class MethodRetriever : IMethodRetriever
    {
        IFactory factory;
        public MethodRetriever(IFactory factory)
        {
            this.factory = factory;
        }
        public IMethod GetScenarioMethod()
        {
            StackFrame stackFrame = new StackFrame(2);
            if (stackFrame.GetMethod().Name == "MoveNext")
                stackFrame = new StackFrame(4);
            return factory.CreateMethod(stackFrame.GetMethod());

        }

        public IMethod GetStepMethod(Action<IStep> action)
        {
            return factory.CreateMethod(action.Method);
        }
    }
}
