using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD
{
    public interface ITestRun
    {
        ITestCase AddTestCase();
        ITestCase AddTestCase(string testCaseName);
    }
}
