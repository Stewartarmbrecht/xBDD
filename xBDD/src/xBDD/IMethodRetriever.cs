using System;

namespace xBDD
{
    public interface IMethodRetriever
    {
        IMethod GetStepMethod(Action<IStep> stepAction);
        IMethod GetScenarioMethod();
    }
}