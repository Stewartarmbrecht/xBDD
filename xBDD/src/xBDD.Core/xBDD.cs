using xBDD.Core;
using xBDD.Stats;

namespace xBDD
{
    public partial class xBDD
    {
        static IFactory factory;
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
                factory = new Factory();
        }
        static IStatsCompiler statsCompiler;
        public static IStatsCompiler StatsCompiler
        {
            get
            {
                EnsureFactory();
                if (statsCompiler == null)
                    statsCompiler = factory.CreateStatsCompiler();
                return statsCompiler;
            }
        }
    }
}
