﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xBDD.xUnit;
using Xunit.Abstractions;

namespace xBDD.Test.Features.DefineScenarios
{
    public class OrganizeSteps
    {
        private readonly IOutputWriter outputWriter;

        public OrganizeSteps(ITestOutputHelper output)
        {
            outputWriter = new OutputWriter(output);
        }

        [ScenarioFact]
        public void InAStepLibrary()
        {
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Skip();
        }
        [ScenarioFact]
        public void InAStepLibrarySharedAcrossAreas()
        {
            xBDD.CurrentRun
                .AddScenario()
                .SetOutputWriter(outputWriter)
                .Skip();
        }
    }
}
