using xBDD.Core;

namespace xBDD.Utility
{
    public interface IStepNameReader
    {
        string ReadStepName(string StepName, IMethod method);
    }
}