using System;
using System.Threading.Tasks;
using xBDD.Core;
using xBDD.Model;

namespace xBDD
{
    public partial class xBDD
    {
        static CoreFactory factory;
        static TestRunBuilder testRunBuilder;
        public static TestRunBuilder CurrentRun
        {
            get
            {
                EnsureFactory();
                if (testRunBuilder == null)
                {
                    testRunBuilder = factory.CreateTestRunBuilder(null);
                }
                return testRunBuilder;
            }
        }

        public static Step CreateStep(
            string stepName, 
            Action action = null, 
            string multilineParameter = "",
            MultilineParameterFormat multilineParameterFormat = MultilineParameterFormat.literal)
        {
            action = action ?? (() => { });
            return factory.CreateStep(stepName, action, multilineParameter, multilineParameterFormat);
        }

        public static Step CreateAsyncStep(
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
