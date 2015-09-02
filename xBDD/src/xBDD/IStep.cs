using System;
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

        void SetNameWithReplacement(string key, string value);
    }
}
