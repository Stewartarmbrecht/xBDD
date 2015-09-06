using xBDD.Core;
using xBDD.Stats;

namespace xBDD
{
    public partial class xBDD
    {
        static ICoreFactory factory;
        static ITestRun testRun;
        public static ITestRun CurrentRun
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
        static void EnsureFactory()
        {
            if (factory == null)
                factory = new CoreFactory();
        }
    }
}
