using System;
using System.Diagnostics;
using xBDD.Core;

namespace xBDD.Utility
{
    public class MethodRetriever : IMethodRetriever
    {
        IFactory factory;
        public MethodRetriever(IFactory factory)
        {
            this.factory = factory;
        }

        public IMethod GetCallingStepMethod()
        {
            StackFrame stackFrame = GetStepStackFrame();
            return factory.CreateMethod(stackFrame.GetMethod());
        }

        private StackFrame GetStepStackFrame()
        {
            bool found = false;
            int stackLocation = 1;
            StackFrame sf = null;
            while(!found)
            {
                sf = new StackFrame(stackLocation);
                var method = sf.GetMethod();
                if (method.DeclaringType != null && (method.IsStep() || method.DeclaringType.IsStepLibrary()))
                    found = true;
                else
                    stackLocation++;
            }
            return sf;
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
