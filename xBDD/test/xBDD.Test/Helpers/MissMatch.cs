using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Test.Helpers
{
    public class MissMatch
    {
        public int TargetLineNumber { get; set; }
        public string TargetLine { get; set; }
        public int TemplateLineNumber { get; set; }
        public string TemplateLine { get; set; }
    }
}
