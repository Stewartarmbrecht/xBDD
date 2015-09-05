using System;
using System.Threading.Tasks;
using xBDD.Core;

namespace xBDD.Utility
{
    public interface IMethodRetriever
    {
        IMethod GetStepMethod(Action<IStep> stepAction);
        IMethod GetStepMethod(Func<IStep, Task> stepAction);
        IMethod GetScenarioMethod();
        IMethod GetCallingStepMethod();
    }
}