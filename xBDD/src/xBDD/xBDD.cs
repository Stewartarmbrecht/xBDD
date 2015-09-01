using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xBDD.Core;

namespace xBDD
{
    public class xBDD
    {
        static ITestRun testRun;
        public static ITestRun CurrentRun
        {
            get
            {
                if (testRun == null)
                {
                    IFactory factory = new Factory();
                    testRun = new TestRun(factory);
                }
                return testRun;
            }
        }
    }
}
