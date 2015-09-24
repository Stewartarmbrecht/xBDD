using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using xBDD.Core;
using xBDD.Stats;

namespace xBDD
{
    public partial class xBDD
    {
        static CoreFactory factory;
        static TestRun testRun;
        public static TestRun CurrentRun
        {
            get
            {
                EnsureFactory();
                if (testRun == null)
                {
                    testRun = factory.CreateTestRun();
                }
                return testRun;
            }
        }

        internal static Step CreateStep(
            string stepName, Action action, string multilineParameter = "")
        {
            return factory.CreateStep(stepName, action, multilineParameter);
        }

        static void EnsureFactory()
        {
            if (factory == null)
                factory = new CoreFactory();
        }
    }
}
