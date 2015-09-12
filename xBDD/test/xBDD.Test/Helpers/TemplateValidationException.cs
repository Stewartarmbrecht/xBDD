using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xBDD.Test.Helpers
{
    public class TemplateValidationException : Exception
    {
        public override string Message
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (var miss in Misses)
                {
                    if (miss.TargetLineNumber == -1)
                    {
                        sb.AppendLine("Template line " + (miss.TemplateLineNumber + 1) + " did not match");
                        sb.AppendLine("\tExpected: " + miss.TemplateLine);
                        sb.AppendLine("\t  Actual: ");
                    }
                    else
                    {
                        sb.AppendLine("Target Line " + (miss.TargetLineNumber + 1) + " did not match");
                        sb.AppendLine("\tExpected: " + miss.TemplateLine);
                        sb.AppendLine("\t  Actual: " + miss.TargetLine);
                    }
                }
                return sb.ToString();
            }
        }
        public List<MissMatch> Misses { get; private set; }
        public TemplateValidationException(List<MissMatch> misses)
        {
            Misses = misses;
        }
    }
}
