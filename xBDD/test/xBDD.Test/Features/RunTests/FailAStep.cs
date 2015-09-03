using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Test.Features.RunTests
{
    public class FailAStep
    {
        [ScenarioFact]
        public void Sync()
        {
            throw new SkipStepException("Not Implemented");
        }
        [ScenarioFact]
        public void Async()
        {
            throw new SkipStepException("Not Implemented");
        }

    }
}
