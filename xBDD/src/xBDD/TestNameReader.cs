using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace xBDD
{
    public class TestNameReader : ITestNameReader
    {
        public string ReadTestName(string testName, IMethod method)
        {
            if (testName == null)
            {
                testName = ReadAttribute(method);
                if (testName == null)
                    testName = method.Name.AddSpacesToSentence(true);
            }

            return testName;
        }

        string ReadAttribute(IMethod method)
        {
            string name = null;
            foreach (var data in method.GetCustomAttributesData())
            { 
            
                if (data.AttributeType == typeof(TestNameAttribute))
                {
                    var args = data.ConstructorArguments;
                    name = args[0];
                }
            }
            return name;
        }
    }
}
