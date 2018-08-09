namespace xBDD
{

	/// <summary>
	/// Sets the name for a test run
	/// by decorating the assembly.
	/// </summary>
	[System.AttributeUsage(System.AttributeTargets.Assembly, AllowMultiple = false)]
	public class TestRunNameAttribute : System.Attribute
	{
		string testRunName;
		
		/// <summary>
		/// Sets the name of the test run.
		/// </summary>
		/// <param name="testRunName">Name for the test run.</param>
		public TestRunNameAttribute(string testRunName)
		{
			this.testRunName = testRunName;
		}
	
		/// <summary>
		/// Gets the test run name.
		/// </summary>
		/// <returns>Test run name.</returns>
		public string GetTestRunName()
		{
			return testRunName;
		}
	}
}
