
namespace xBDD
{
	[System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false)]
	public class IWouldLikeToAttribute : System.Attribute
	{
		string name;
			
		public IWouldLikeToAttribute(string name)
		{
			this.name = name;
		}
	
		public string GetName()
		{
			return name;
		}
	}
}
