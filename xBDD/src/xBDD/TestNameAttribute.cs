using System;

namespace xBDD
{
    [AttributeUsage(System.AttributeTargets.Class | AttributeTargets.Method)]
    public class TestNameAttribute : Attribute
    {
        public string TestName { get; set; }

        public TestNameAttribute(string testName)
        {
            this.TestName = testName;
        }
    }
}