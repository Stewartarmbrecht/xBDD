using System;
using xBDD.Core;

namespace xBDD.Utility
{
    public interface IMethodRetriever
    {
        IMethod GetStepMethod(Action<IStep> stepAction);
        IMethod GetScenarioMethod();
        IMethod GetCallingMethod();
    }
}