using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace xBDD
{
    public class TestRun
    {
        static TestRun testRun;
        public static TestRun Current
        {
            get
            {
                if (testRun == null)
                    testRun = new TestRun();
                return testRun;
            }
        }

        TestRun()
        {

        }

        public TestCase AddTestCase([CallerMemberName]string name = null)
        {
            TestCase test = new TestCase();
            name = Regex.Replace(name, "(\\B[A-Z])", " $1");
            test.Name = name;
            return test;
        }
    }
}
