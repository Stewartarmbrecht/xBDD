using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using xBDD.Model;

namespace xBDD.Reporting.Outline
{
    /// <summary>
    /// Writes test run results in a text format to a string.
    /// </summary>
    public class OpmlWriter
    {
        /// <summary>
        /// Writes test run results in a text format to a string.
        /// </summary>
        /// <param name="testRun">The test run to write to a text string.</param>
        /// <param name="capabilityNameClip">The starting part of each capability name to remove.</param>
        /// <returns>The text respresentation of the test run results.</returns>
        public string WriteToOpml(TestRun testRun, string capabilityNameClip = null)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($@"<?xml version=""1.0""?>
<opml version=""2.0"">
<head>
</head>
<body>");
            sb.AppendLine();
            Scenario lastScenario = null;
            var sortedScenarios = testRun.Scenarios.OrderBy(x => x.Feature.Capability.Name).ThenBy(x => x.Feature.Name).ThenBy(x => x.Name);
            if(testRun.Sorted)
                sortedScenarios = testRun.Scenarios.OrderBy(x => x.Feature.Sort).ThenBy(x => x.Sort);
            foreach(var scenario in sortedScenarios)
            {
                WriteScenario(lastScenario, scenario, sb, capabilityNameClip);
                lastScenario = scenario;
            }
            if(sortedScenarios.Count() > 0) {
                sb.AppendLine($"\t</outline>");
                sb.AppendLine($"</outline>");
            }
            sb.AppendLine($"</body>");
            sb.AppendLine($"</opml>");
            return sb.ToString();
        }

        private void WriteScenario(Scenario lastScenario, Scenario scenario, StringBuilder sb, string capabilityNameClip)
        {
            if (lastScenario != null && lastScenario.Feature.Name != scenario.Feature.Name)
            {
                sb.AppendLine($"\t</outline>");
            }
            if(lastScenario != null && lastScenario.Feature.Capability.Name != scenario.Feature.Capability.Name)
            {
                sb.AppendLine($"</outline>");
            }
            if(lastScenario == null || (lastScenario != null && lastScenario.Feature.Capability.Name != scenario.Feature.Capability.Name))
            {
                var capabilityName = scenario.Feature.Capability.Name;
                if(capabilityNameClip != null) {
                    capabilityName = capabilityName.Replace(capabilityNameClip, "");
                }
                if(scenario.Feature.Capability.Reason != null) {
                    sb.AppendLine($"<outline text=\"{capabilityName} [{scenario.Feature.Capability.Reason}]\">");
                } else {
                    sb.AppendLine($"<outline text=\"{capabilityName}\">");
                }
            }

            if (lastScenario == null || (lastScenario != null && lastScenario.Feature.Name != scenario.Feature.Name))
            {
                if(scenario.Feature.Reason != null) {
                    sb.AppendLine($"\t<outline text=\"{scenario.Feature.Name} [{scenario.Feature.Reason}]\">");
                } else {
                    sb.AppendLine($"\t<outline text=\"{scenario.Feature.Name}\">");
                }
            }
            if(scenario.Reason != null) {
                sb.AppendLine($"\t\t<outline text=\"{scenario.Name} [{scenario.Reason}]\">");
            } else {
                sb.AppendLine($"\t\t<outline text=\"{scenario.Name}\">");
            }
            foreach(var step in scenario.Steps)
            {
                WriteStep(step, sb);
            }
            sb.AppendLine($"\t\t</outline>");
        }

        private void WriteStep(Step step, StringBuilder sb)
        {
            var multiline = !String.IsNullOrEmpty(step.Input);
            sb.AppendLine($"\t\t\t<outline text=\"{step.FullName.Replace(System.Environment.NewLine, "")}\"{(multiline ? "":"/")}>");
            if (multiline)
            {
                WriteMultilineParameter(step.Input, sb);
                sb.AppendLine($"\t\t\t</outline>");
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
                    sb.Append("\t\t\t\t<outline text=\"");
                    sb.Append(lines[i]);
                    sb.AppendLine("\" />");
                }
            }
        }
    }
}
