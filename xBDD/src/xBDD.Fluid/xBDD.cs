using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xBDD.Fluid
{
    public static class xBDD
    {
        static TestRun testRun;
        public static TestRun TestRun
        {
            get
            {
                testRun = testRun ?? new TestRun();
                return testRun;
            }
        }
    }
}
