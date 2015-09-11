using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD
{
    public class StepNotImplementedException : Exception
    {
        public StepNotImplementedException(string stepName, Exception innerException)
            : base("The '" + stepName + "' step is not implemented.", innerException)
        {

        }
    }
}
