using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xBDD.Core;

namespace xBDD.Utility
{
    public interface IStepExceptionHandler
    {
        void HandleException(IStepExecutor stepExecutor, IStep step, Exception ex);
    }
}
