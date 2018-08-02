using System;

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
