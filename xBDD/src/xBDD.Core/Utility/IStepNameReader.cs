using System.Collections.Generic;

namespace xBDD.Utility
{
    public interface IStepNameReader
    {
        string ReadStepName(IMethod method);
    }
}