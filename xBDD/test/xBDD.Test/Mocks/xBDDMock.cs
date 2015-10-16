using System;
using System.Threading.Tasks;
using xBDD.Core;
using xBDD.Model;

namespace xBDD
{
    public class xBDDMock
    {
        CoreFactory factory;
        TestRunBuilder testRun;
        public TestRunBuilder CurrentRun
        {
            get
            {
                EnsureFactory();
                if (testRun == null)
                {
                    testRun = factory.CreateTestRunBuilder("My Test Run");
                }
                return testRun;
            }
        }

        void EnsureFactory()
        {
            if (factory == null)
                factory = new CoreFactory();
        }

        public Step CreateStep(string stepName, Action<Step> action = null, string multilineParameter = null, TextFormat format = TextFormat.text)
        {
            return xB.CreateStep(stepName, action, multilineParameter, format);
        }
        public Step CreateAsyncStep(string stepName, Func<Step, Task> action = null, string multilineParameter = null, TextFormat format = TextFormat.text)
        {
            return xB.CreateAsyncStep(stepName, action, multilineParameter, format);
        }
    }
}
