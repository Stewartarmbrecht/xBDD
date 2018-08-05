using System;

namespace xBDD
{
    /// <summary>
    /// Thrown when a step experiences an exception during execution.
    /// </summary>
    public class StepException : Exception
    {
        /// <summary>
        /// Creates a new step exception.
        /// </summary>
        /// <param name="stepName">Name of the step throwing the exception.</param>
        /// <param name="ex">The exception encountered when executing the step.</param>
        internal StepException(string stepName, Exception ex)
            : base("The step '"+stepName+"' threw a '" + ex.GetType().Name + "' exception with a message: '" + ex.Message + "'. See the inner exception for details.", ex)
        {
        }
    }
}