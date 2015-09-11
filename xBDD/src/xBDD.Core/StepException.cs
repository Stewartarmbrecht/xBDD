using System;

namespace xBDD
{
    public class StepException : Exception
    {
        public StepException(string stepName, Exception ex)
            : base("The step '"+stepName+"' threw a '" + ex.GetType().Name + "' exception with a message: '" + ex.Message + "'. See the inner exception for details.", ex)
        {
        }
    }
}