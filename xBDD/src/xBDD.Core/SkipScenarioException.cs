using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD
{
    public class SkipScenarioException : Exception
    {
        public SkipScenarioException(string reason)
            : base("The scenario was skippped because '" + reason + "'")
        {
        }
    }
}
