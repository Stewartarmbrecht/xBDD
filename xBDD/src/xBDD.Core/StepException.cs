using System;

namespace xBDD
{
    public class StepException : Exception
    {
        public StepException(string stepName, Exception ex)
            : base("The child step, '"+stepName+"' threw an exception of '" + ex.Message + "'. See the inner exception for details.", ex)
        {
        }
    }
}