using System;

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
