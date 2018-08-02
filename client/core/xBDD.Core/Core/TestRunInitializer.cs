using System.Reflection;
using xBDD.Model;

namespace xBDD.Core
{
	public class TestRunInitializer
	{
		public void InitializeTestRun(object callingTestClass, TestRun testRun)
		{
			if(testRun.Name == null)
			{
				var testRunName = callingTestClass.GetType().GetTypeInfo().Assembly.GetCustomAttribute<TestRunNameAttribute>();
				if(testRunName != null)
					testRun.Name = testRunName.GetName();
			}
		}
	}
}