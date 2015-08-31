using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD
{
    public interface ITestRun
    {
        IScenario AddScenario();
        IScenario AddScenario(string scenarioName);
        IScenario AddScenario(string featureName, string scenarioName);
    }
}
