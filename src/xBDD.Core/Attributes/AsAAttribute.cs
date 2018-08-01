
namespace xBDD
{
	[System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false)]
	public class AsAAttribute : System.Attribute
	{
		string name;
			
		public AsAAttribute(string name)
		{
			this.name = name;
		}
	
		public string GetName()
		{
			return name;
		}
	}
}
