using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace xBDD.Test.Stories
{
    public class OverrideTestName
    {
        [Fact]
        public void WhenAddingTest()
        {
            var testName = "Create Test With Name";
            var test = TestRun.Current.AddTestCase(testName);
            Assert.Equal(testName, test.Name);
        }
        [Fact]
        [TestName("With A Test Attribute")]
        public void WithTestAttribute()
        {
            var test = TestRun.Current.AddTestCase();
            Assert.Equal("With A Test Attribute", test.Name);
        }
    }
}
