using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
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
            string stepName, Action action = null, 
            string multilineParameter = "",
            MultilineParameterFormat multilineParameterFormat = MultilineParameterFormat.literal)
        {
            action = action ?? (() => { });
            return factory.CreateStep(stepName, action, multilineParameter, multilineParameterFormat);
        }

        internal static Step CreateAsyncStep(
            string stepName, Func<Task> action = null,
            string multilineParameter = "",
            MultilineParameterFormat multilineParameterFormat = MultilineParameterFormat.literal)
        {
            action = action ?? (() => { return Task.Run(() => { }); });
            return factory.CreateStep(stepName, action, multilineParameter, multilineParameterFormat);
        }

        static void EnsureFactory()
        {
            if (factory == null)
                factory = new CoreFactory();
        }
    }
}
