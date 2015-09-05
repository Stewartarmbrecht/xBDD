﻿using System;
using System.Threading.Tasks;

namespace xBDD.Core
{
    public interface IScenarioBuilder
    {
        IScenario And(Action<IStep> stepAction);
        IScenario And(string name, Action<IStep> stepAction);
        IScenario AndAsync(Func<IStep, Task> stepAction);
        IScenario AndAsync(string name, Func<IStep, Task> stepAction);
        IScenario Given(Action<IStep> stepAction);
        IScenario Given(string name, Action<IStep> stepAction);
        IScenario GivenAsync(Func<IStep, Task> stepAction);
        IScenario GivenAsync(string name, Func<IStep, Task> stepAction);
        IScenario Then(Action<IStep> stepAction);
        IScenario Then(string name, Action<IStep> stepAction);
        IScenario ThenAsync(Func<IStep, Task> stepAction);
        IScenario ThenAsync(string name, Func<IStep, Task> stepAction);
        IScenario When(Action<IStep> stepAction);
        IScenario When(string name, Action<IStep> stepAction);
        IScenario WhenAsync(Func<IStep, Task> stepAction);
        IScenario WhenAsync(string name, Func<IStep, Task> stepAction);
    }
}