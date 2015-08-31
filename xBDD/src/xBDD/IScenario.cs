using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD
{
    public interface IScenario
    {
        string FeatureName { get; set; }
        string AreaPath { get; set; }
        string Name { get; set; }
        List<IStep> Steps { get; }

        IScenario Given(Action<IStep> stepAction);
        IScenario Given(string name, Action<IStep> stepAction);
        IScenario When(Action<IStep> stepAction);
        IScenario When(string name, Action<IStep> stepAction);
        IScenario Then(Action<IStep> stepAction);
        IScenario Then(string name, Action<IStep> stepAction);
        IScenario And(Action<IStep> stepAction);
        IScenario And(string name, Action<IStep> stepAction);
        void Run();
    }
}
