namespace xBDD
{
	[System.AttributeUsage(System.AttributeTargets.Assembly, AllowMultiple = false)]
	public class TestRunNameAttribute : System.Attribute
	{
		string name;
			
		public TestRunNameAttribute(string name)
		{
			this.name = name;
		}
	
		public string GetName()
		{
			return name;
		}
	}
}
