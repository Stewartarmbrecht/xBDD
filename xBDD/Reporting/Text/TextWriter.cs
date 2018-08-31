using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using xBDD.Model;

namespace xBDD.Reporting.Text
{
    /// <summary>
    /// Writes test run results in a text format to a string.
    /// </summary>
    public class TextWriter
    {
        private bool includeExceptions;
        /// <summary>
        /// Writes test run results in a text format to a string.
        /// </summary>
        /// <param name="testRun">The test run to write to a text string.</param>
        /// <param name="includeExceptions">Sets the text writer to include 
        /// exception information for failed steps.</param>
        /// <returns>The text respresentation of the test run results.</returns>
        public string WriteToText(TestRun testRun, bool includeExceptions)
        {
            this.includeExceptions = includeExceptions;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(testRun.Name);
            sb.AppendLine();
            Scenario lastScenario = null;
            var sortedScenarios = testRun.Scenarios.OrderBy(x => x.Feature.Area.Name).ThenBy(x => x.Feature.Name).ThenBy(x => x.Name);
            if(testRun.Sorted)
                sortedScenarios = testRun.Scenarios.OrderBy(x => x.Feature.Sort).ThenBy(x => x.Sort);
            foreach(var scenario in sortedScenarios)
            {
                WriteScenario(lastScenario, scenario, sb);
                lastScenario = scenario;
            }
            return sb.ToString();
        }

        private void WriteScenario(Scenario lastScenario, Scenario scenario, StringBuilder sb)
        {
            if(lastScenario == null || (lastScenario != null && lastScenario.Feature.Area.Name != scenario.Feature.Area.Name))
            {
                sb.Append(scenario.Feature.Area.Name);
                if (scenario.Feature.Area.Reason != null)
                {
                    sb.AppendLine($" [{scenario.Feature.Area.Reason}]");
                }
                else
                    sb.AppendLine();
            }

            if (lastScenario == null || (lastScenario != null && lastScenario.Feature.Name != scenario.Feature.Name))
            {
                sb.Append("\t");
                sb.Append(scenario.Feature.Name);
                if (scenario.Feature.Reason != null)
                {
                    sb.AppendLine($" [{scenario.Feature.Reason}]");
                }
                else
                    sb.AppendLine();
            }
            sb.Append("\t\t");
            sb.Append(scenario.Name);
            if (scenario.Reason != null)
            {
                sb.AppendLine($" [{scenario.Reason}]");
            }
            else
                sb.AppendLine();
            foreach(var step in scenario.Steps)
            {
                WriteStep(step, sb);
            }
        }

        private void WriteStep(Step step, StringBuilder sb)
        {
            sb.Append("\t\t\t" + step.FullName.Replace(System.Environment.NewLine, ""));
            if (step.Scenario.Outcome == Outcome.Failed)
            {
                if (step.Reason != null)
                {
                    sb.AppendLine($" [{step.Reason}]");
                }
                else
                    sb.AppendLine();
            }
            else
                sb.AppendLine();
            if (!String.IsNullOrEmpty(step.Input))
            {
                WriteMultilineParameter(step.Input, sb);
            }
            if (step.Exception != null && !(step.Exception is NotImplementedException) && step.Outcome != Outcome.Skipped && includeExceptions)
                WriteException(step.Exception, sb);
        }

        private void WriteException(Exception exception, StringBuilder sb)
        {
            sb.Append("\t\t\t\tError Type: ");
            sb.AppendLine(exception.GetType().Name);
            sb.Append("\t\t\t\t   Message: ");
            sb.AppendLine(exception.Message);
            sb.Append("\t\t\t\t     Stack: ");
            string[] lines = Regex.Split(exception.StackTrace, System.Environment.NewLine);
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

        private void WriteMultilineParameter(string multilineParameter, StringBuilder sb)
        {
            string[] lines = Regex.Split(multilineParameter, System.Environment.NewLine);
            for (int i = 0; i < lines.Length; i++)
            {
                if (i == lines.Length - 1 && lines[i].Length == 0)
                    return;
                else
                {
                    sb.Append("\t\t\t\t");
                    sb.AppendLine(lines[i]);
                }
            }
        }
    }
}
