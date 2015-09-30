using System;

namespace xBDD
{
    public class SkipStepException : Exception
    {
        public SkipStepException(string reason)
            : base(reason) { }
    }
}
