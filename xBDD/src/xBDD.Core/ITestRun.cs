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
        IScenario AddScenario(string scenarioName, string featureName);
        IScenario AddScenario(string scenarioName, string featureName, string areaPath);
        ICollection<IScenario> Scenarios { get; }
        ICollection<IStep> Steps { get; }
        string Name { get; set; }
    }
}
