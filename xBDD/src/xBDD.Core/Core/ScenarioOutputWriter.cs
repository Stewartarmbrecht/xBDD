using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Core
{
    public class ScenarioOutputWriter : IScenarioOutputWriter
    {
        IScenarioInternal scenario;
        IOutputWriter outputWriter;
        public ScenarioOutputWriter(IScenarioInternal scenario, IOutputWriter outputWriter)
        {
            this.scenario = scenario;
            this.outputWriter = outputWriter;
        }
        public void WriteOutput()
        {
            outputWriter.WriteLine(scenario.Name);
            foreach (var step in scenario.Steps)
            {
                WriteStep(step);
            }
        }

        private void WriteStep(IStep step)
        {
            outputWriter.WriteLine("    " + step.Name);
            if (step.MultilineParameter != null)
                outputWriter.WriteLine("        " + step.MultilineParameter);
        }
    }
}
