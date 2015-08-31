using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD
{
    public interface ITestStep
    {
        Action<ITestStep> Action { get; set; }
        ActionType ActionType { get; set; }
        string Name { get; set; }
    }
}
