using System;
using System.Threading.Tasks;

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