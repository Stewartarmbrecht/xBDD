using System;

namespace xBDD.Core
{
    public interface IStepExceptionHandler
    {
        void HandleException(IStepExecutor stepExecutor, IStep step, Exception ex);
    }
}
