using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace xBDD
{
    public class TestRun : ITestRun
    {
        static ITestRun testRun;
        public static ITestRun Current
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

        IFactory factory;
        TestRun(IFactory factory)
        {
            this.factory = factory;
        }

        public ITestCase AddTestCase()
        {
            IMethod method = factory.GetMethodRetriever().GetTestCaseMethod();
            return AddTestCase(null, method);
        }

        public ITestCase AddTestCase(string testName)
        {
            IMethod method = factory.GetMethodRetriever().GetTestCaseMethod();
            return AddTestCase(testName, method);
        }

        public ITestCase AddTestCase(string testName, IMethod method)
        {
            var test = factory.CreateTestCase();
            test.Name = factory.GetTestNameReader().ReadTestName(testName, method);
            test.ClassName = method.GetClassName(); 
            test.Namespace = method.GetNameSpace();
            return test;
        }
    }
}
