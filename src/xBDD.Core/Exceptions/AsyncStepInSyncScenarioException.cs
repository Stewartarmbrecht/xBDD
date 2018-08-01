using System;

namespace xBDD
{
    public class AsyncStepInSyncScenarioException : Exception
    {
        public AsyncStepInSyncScenarioException(string stepName)
            : base("The child step, '"+stepName+"' is an asynchronous step and you are trying to run the scenario synchronously.")
        {
        }
    }
}