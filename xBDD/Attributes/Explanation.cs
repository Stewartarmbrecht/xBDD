
namespace xBDD
{
	/// <summary>
	/// Marks the actor for a feature.
	/// Use this on the test class to define a feature.
	/// </summary>
	[System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Method, AllowMultiple = false)]
	public class ExplanationAttribute : System.Attribute
	{
		string explanation;
			
		/// <summary>
		/// Set the actor for the feature.
		/// </summary>
		/// <param name="explanation">The name of the actor.</param>
		public ExplanationAttribute(string explanation)
		{
			this.explanation = explanation;
		}
	
		/// <summary>
		/// Returns the name of the actor.
		/// </summary>
		/// <returns>The name of the actor.</returns>
		public string GetExplanation()
		{
			return explanation;
		}
	}
}
