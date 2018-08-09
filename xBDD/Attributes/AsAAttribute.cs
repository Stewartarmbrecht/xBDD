
namespace xBDD
{
	/// <summary>
	/// Marks the actor for a feature.
	/// Use this on the test class to define a feature.
	/// </summary>
	[System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false)]
	public class AsAAttribute : System.Attribute
	{
		string name;
			
		/// <summary>
		/// Set the actor for the feature.
		/// </summary>
		/// <param name="name">The name of the actor.</param>
		public AsAAttribute(string name)
		{
			this.name = name;
		}
	
		/// <summary>
		/// Returns the name of the actor.
		/// </summary>
		/// <returns>The name of the actor.</returns>
		public string GetName()
		{
			return name;
		}
	}
}
