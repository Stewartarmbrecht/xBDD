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
        dynamic State { get; }
        List<IStep> Steps { get; }

        IScenario GivenAsync(string stepName, Func<IStep, Task> stepAction);
        IScenario GivenAsync(Func<IStep,Task> stepAction);
        IScenario Given(Action<IStep> stepAction);
        IScenario Given(string name, Action<IStep> stepAction);

        IScenario WhenAsync(string name, Func<IStep, Task> stepAction);
        IScenario WhenAsync(Func<IStep, Task> stepAction);
        IScenario When(Action<IStep> stepAction);
        IScenario When(string name, Action<IStep> stepAction);

        IScenario ThenAsync(string name, Func<IStep, Task> stepAction);
        IScenario ThenAsync(Func<IStep, Task> stepAction);
        IScenario Then(Action<IStep> stepAction);
        IScenario Then(string name, Action<IStep> stepAction);

        IScenario AndAsync(string name, Func<IStep, Task> stepAction);
        IScenario AndAsync(Func<IStep, Task> stepAction);
        IScenario And(Action<IStep> stepAction);
        IScenario And(string name, Action<IStep> stepAction);

        void Run();
        Task RunAsync();
    }
}
