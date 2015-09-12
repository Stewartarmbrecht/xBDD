using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace xBDD.Reporting.TextFile
{
    public class TextFileWriter : ITextFileWriter
    {
        public void WriteToFile(ITestRun testRun, string fileName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(testRun.Name);
            sb.AppendLine();
            foreach(var scenario in testRun.Scenarios)
            {
                WriteScenario(scenario, sb);
            }
            File.WriteAllText(fileName, sb.ToString());
        }

        private void WriteScenario(IScenario scenario, StringBuilder sb)
        {
            sb.AppendLine(scenario.AreaPath);
            sb.Append("\t");
            sb.AppendLine(scenario.FeatureName);
            sb.Append("\t\t");
            sb.Append(scenario.Name);
            if (scenario.Outcome != Outcome.Passed)
            {
                sb.Append(" [");
                sb.Append(Enum.GetName(typeof(Outcome), scenario.Outcome));
                if (scenario.Reason != null && scenario.Reason != "Failed Step")
                {
                    sb.Append(" - ");
                    sb.Append(scenario.Reason);
                }
                sb.AppendLine("]");

            }
            else
                sb.AppendLine();
            foreach(var step in scenario.Steps)
            {
                WriteStep(step, sb);
            }
        }

        private void WriteStep(IStep step, StringBuilder sb)
        {
            sb.Append("\t\t\t" + step.Name);
            if(step.Scenario.Outcome == Outcome.Failed)
            {
                if (step.Outcome != Outcome.Passed)
                {
                    sb.Append(" [" + Enum.GetName(typeof(Outcome), step.Outcome));
                    if (step.Reason != null && step.Outcome != Outcome.Failed)
                        sb.Append(" - " + step.Reason);
                    sb.AppendLine("]");
                }
                else
                    sb.AppendLine();
                if (step.Exception != null && step.Outcome != Outcome.Skipped)
                    WriteException(step.Exception, sb);
            }
            else
                sb.AppendLine();
        }

        private void WriteException(Exception exception, StringBuilder sb)
        {
            sb.Append("\t\t\t\tError Type: ");
            sb.AppendLine(exception.GetType().Name);
            sb.Append("\t\t\t\t   Message: ");
            sb.AppendLine(exception.Message);
            sb.Append("\t\t\t\t     Stack: ");
            string[] lines = Regex.Split(exception.StackTrace, "\r\n");
            for (int i = 0; i < lines.Length; i++)
            {
                if (i == 0)
                    sb.AppendLine(lines[i]);
                else
                {
                    if (i == lines.Length - 1 && lines[i].Length == 0)
                        return;
                    else
                    {
                        sb.Append("\t\t\t\t            ");
                        sb.AppendLine(lines[i]);
                    }
                }
            }
        }
    }
}
