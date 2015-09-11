﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
            sb.AppendLine("\t" + scenario.FeatureName);
            sb.Append("\t\t" + scenario.Name);
            if (scenario.Outcome != Outcome.Passed)
                sb.AppendLine(" [" + Enum.GetName(typeof(Outcome), scenario.Outcome) + "]");
        }
    }
}