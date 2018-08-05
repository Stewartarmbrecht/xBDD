using System.Text.RegularExpressions;
using xBDD.Model;

namespace xBDD.Core
{

    internal class ScenarioOutputWriter
    {
        Scenario scenario;
        IOutputWriter outputWriter;
        
        internal ScenarioOutputWriter(Scenario scenario, IOutputWriter outputWriter)
        {
            this.scenario = scenario;
            this.outputWriter = outputWriter;
        }
        internal void WriteOutput()
        {
            outputWriter.WriteLine(scenario.Name);
            foreach (var step in scenario.Steps)
            {
                WriteStep(step);
            }
        }

        private void WriteStep(Step step)
        {
            outputWriter.WriteLine("    " + step.FullName);
            if (step.MultilineParameter != null)
            {
                string[] lines = Regex.Split(step.MultilineParameter, System.Environment.NewLine);
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
