
namespace xBDD
{
	[System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false)]
	public class InOrderToAttribute : System.Attribute
	{
		string name;
			
		public InOrderToAttribute(string name)
		{
			this.name = name;
		}
	
		public string GetName()
		{
			return name;
		}
	}
}
