using System;

namespace xBDD
{
    /// <summary>
    /// Exception thrown when you want the framework 
    /// To mark a step as skipped.
    /// </summary>
    public class SkipStepException : Exception
    {
        /// <summary>
        /// Creates a new exception to tell the framework to mark
        /// the step as skipped.
        /// </summary>
        /// <param name="reason"></param>
        public SkipStepException(string reason)
            : base(reason) { }
    }
}
