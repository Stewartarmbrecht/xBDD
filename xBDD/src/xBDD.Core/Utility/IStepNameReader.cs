using System.Collections.Generic;
using xBDD.Core;

namespace xBDD.Utility
{
    public interface IStepNameReader
    {
        string ReadStepName(IStep step, string stepName, IMethod method);
        string ReadStepNameWithReplacement(IStep step, string stepName, IMethod method, Dictionary<string, string> replacements);
    }
}