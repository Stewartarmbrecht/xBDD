using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace xBDD.Utility
{
    public class MethodRetriever : IMethodRetriever
    {
        IUtilityFactory factory;
        public MethodRetriever(IUtilityFactory factory)
        {
            this.factory = factory;
        }

        public IMethod GetCallingStepMethod()
        {
            StackFrame stackFrame = GetStepStackFrame();
            return factory.CreateMethod(stackFrame.GetMethod());
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
        public IMethod GetStepMethod(Func<IStep, Task> action)
        {
            return factory.CreateMethod(action.Method);
        }

        StackFrame GetStepStackFrame()
        {
            bool found = false;
            int stackLocation = 1;
            StackFrame sf = null;
            while(!found)
            {
                sf = new StackFrame(stackLocation);
                var method = sf.GetMethod();
                if (method == null)
                {
                    throw new StepMethodNotFoundException();
                }
                if (method.DeclaringType != null && (method.IsStep() || method.DeclaringType.IsStepLibrary()))
                    found = true;
                else
                    stackLocation++;
            }
            return sf;
        }

    }
}
