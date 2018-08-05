using System;

namespace xBDD
{
    /// <summary>
    /// Thrown when a asynchronous action is added to a synchronous step.
    /// </summary>
    public class AsyncStepInSyncScenarioException : Exception
    {
        internal AsyncStepInSyncScenarioException(string stepName)
            : base("The child step, '"+stepName+"' is an asynchronous step and you are trying to run the scenario synchronously.")
        {
        }
    }
}