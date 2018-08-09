using System;

namespace xBDD
{
    /// <summary>
    /// Thrown when neither a steps action or async function has not been implemented.
    /// </summary>
    public class StepNotImplementedException : Exception
    {
        internal StepNotImplementedException(string stepName, Exception innerException)
            : base("The '" + stepName + "' step is not implemented.", innerException)
        {

        }
    }
}
