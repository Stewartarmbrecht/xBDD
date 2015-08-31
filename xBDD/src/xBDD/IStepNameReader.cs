using System.Reflection;

namespace xBDD
{
    public interface IStepNameReader
    {
        string ReadStepName(string StepName, IMethod method);
    }
}