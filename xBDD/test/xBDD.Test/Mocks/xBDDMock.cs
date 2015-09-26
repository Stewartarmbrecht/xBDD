using System;
using System.Threading.Tasks;
using xBDD.Core;

namespace xBDD
{
    public class xBDDMock
    {
        CoreFactory factory;
        TestRun testRun;
        public TestRun CurrentRun
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

        void EnsureFactory()
        {
            if (factory == null)
                factory = new CoreFactory();
        }

        public Step CreateStep(string stepName, Action action = null, string multilineParameter = null, MultilineParameterFormat format = MultilineParameterFormat.literal)
        {
            return xBDD.CreateStep(stepName, action, multilineParameter, format);
        }
        public Step CreateAsyncStep(string stepName, Func<Task> action = null, string multilineParameter = null, MultilineParameterFormat format = MultilineParameterFormat.literal)
        {
            return xBDD.CreateAsyncStep(stepName, action, multilineParameter, format);
        }
    }
}
