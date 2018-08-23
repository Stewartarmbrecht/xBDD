﻿using System;
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
        private bool includeStatus;
        /// <summary>
        /// Writes test run results in a text format to a string.
        /// </summary>
        /// <param name="testRun">The test run to write to a text string.</param>
        /// <param name="includeStatus">Sets the text writer to include 
        /// non-passing step status in the name and print out exceptions.</param>
        /// <returns>The text respresentation of the test run results.</returns>
        public async Task<string> WriteToText(TestRun testRun, bool includeStatus)
        {
            this.includeStatus = includeStatus;
            return await Task.Run(() => {
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
            });
        }

        private void WriteScenario(Scenario lastScenario, Scenario scenario, StringBuilder sb)
        {
            if(lastScenario == null || (lastScenario != null && lastScenario.Feature.Area.Name != scenario.Feature.Area.Name))
            {
                sb.AppendLine(scenario.Feature.Area.Name);
            }

            if (lastScenario == null || (lastScenario != null && lastScenario.Feature.Name != scenario.Feature.Name))
            {
                sb.Append("\t");
                sb.AppendLine(scenario.Feature.Name);
            }
            sb.Append("\t\t");
            sb.Append(scenario.Name);
            if (scenario.Outcome != Outcome.Passed && includeStatus)
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

        private void WriteStep(Step step, StringBuilder sb)
        {
            sb.Append("\t\t\t" + step.FullName.Replace(System.Environment.NewLine, ""));
            if (step.Scenario.Outcome == Outcome.Failed)
            {
                if (step.Outcome != Outcome.Passed && includeStatus)
                {
                    sb.Append(" [" + Enum.GetName(typeof(Outcome), step.Outcome));
                    if (step.Reason != null && (step.Outcome != Outcome.Failed || step.Reason == "Not Implemented"))
                        sb.Append(" - " + step.Reason);
                    sb.AppendLine("]");
                }
                else
                    sb.AppendLine();
            }
            else
                sb.AppendLine();
            if (!String.IsNullOrEmpty(step.MultilineParameter))
            {
                WriteMultilineParameter(step.MultilineParameter, sb);
            }
            if (step.Exception != null && !(step.Exception is NotImplementedException) && step.Outcome != Outcome.Skipped && includeStatus)
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
