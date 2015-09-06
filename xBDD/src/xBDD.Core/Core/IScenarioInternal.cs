﻿using System;
using System.Collections.Generic;

namespace xBDD.Core
{
    public interface IScenarioInternal : IScenario
    {
        ITestRun TestRun { get; }
        new string FeatureName { get; set; }
        new string AreaPath { get; set; }
        new string Name { get; set; }
        new Outcome Outcome { get; set; }
        new DateTime StartTime { get; set; }
        new DateTime EndTime { get; set; }
        new TimeSpan Time { get; set; }
        new Exception FirstStepException { get; set; }
        new List<IStep> Steps { get; }

    }
}
