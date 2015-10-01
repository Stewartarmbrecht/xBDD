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
            Action<Step> action = null, 
            string multilineParameter = "",
            TextFormat multilineParameterFormat = TextFormat.text)
        {
            action = action ?? ((s) => { });
            return factory.CreateStep(stepName, action, multilineParameter, multilineParameterFormat);
        }

        public static Step CreateAsyncStep(
            string stepName, 
            Func<Step, Task> action = null,
            string multilineParameter = "",
            TextFormat multilineParameterFormat = TextFormat.text)
        {
            action = action ?? ((s) => { return Task.Run(() => { }); });
            return factory.CreateStep(stepName, action, multilineParameter, multilineParameterFormat);
        }

        static void EnsureFactory()
        {
            if (factory == null)
                factory = new CoreFactory();
        }
    }
}
