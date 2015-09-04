using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD
{
    public class SkipScenarioException : Exception
    {
        public SkipScenarioException(string stepName, SkipStepException ex)
            : base("The child step, '"+stepName+"' was skippped because '" + ex.Message + "'. See the inner exception for details.", ex)
        {
        }
        public SkipScenarioException(string stepName, NotImplementedException ex)
            : base("The child step, '" + stepName + "' was not implemented. Message: '" + ex.Message + "'. See the inner exception for details.", ex)
        {
        }
    }
}
