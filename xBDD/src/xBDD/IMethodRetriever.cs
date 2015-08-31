using System;

namespace xBDD
{
    public interface IMethodRetriever
    {
        IMethod GetStepMethod(Action<ITestStep> stepAction);
        IMethod GetTestCaseMethod();
    }
}