using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace xBDD.Core
{
    public class ScenarioOutputWriter
    {
        Scenario scenario;
        IOutputWriter outputWriter;
        public ScenarioOutputWriter(Scenario scenario, IOutputWriter outputWriter)
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

        private void WriteStep(Step step)
        {
            outputWriter.WriteLine("    " + step.Name);
            if (step.MultilineParameter != null)
            {
                string[] lines = Regex.Split(step.MultilineParameter, "\r\n");
                for(int i =0; i < lines.Length; i++)
                {
                    if (i == lines.Length - 1 && lines[i].Length == 0)
                        return;
                    else
                        outputWriter.WriteLine((lines[i].Length > 0? "        ": "") + lines[i]);
                }
            }
        }
    }
}
