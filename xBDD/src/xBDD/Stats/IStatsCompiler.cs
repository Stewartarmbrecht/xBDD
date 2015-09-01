﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Stats
{
    public interface IStatsCompiler
    {
        ITestRunStats CompileStats(ITestRun testRun);
    }
}