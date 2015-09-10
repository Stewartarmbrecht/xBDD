using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace xBDD
{
    public interface IStep
    {
        IScenario Scenario { get; }
        Action<IStep> Action { get; set; }
        Func<IStep, Task> ActionAsync { get; set; }
        ActionType ActionType { get; set; }
        string Name { get; }
        void SetName(string stepName);
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }
        Outcome Outcome { get; set; }
        dynamic State { get; }
        string Reason { get; set; }
        Exception Exception { get; set; }
        string MultilineParameter { get; }

        void ReplaceNameParameters(params string[] keyValue);
        void ReturnIfPreviousError();
        void SetMultilineParameter(string multilineParameter);
    }
}
