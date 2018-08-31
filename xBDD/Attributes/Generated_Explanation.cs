
namespace xBDD
{
	using System;
	using System.Text;
	using xBDD.Utility;
	/// <summary>
	/// Marks the actor for a feature.
	/// Use this on the test class to define a feature.
	/// </summary>
	[System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Method, AllowMultiple = false)]
	public class Generated_ExplanationAttribute : System.Attribute
	{
		string explanation;
		int indentation;
			
		/// <summary>
		/// Set the actor for the feature.
		/// </summary>
		/// <param name="explanation">The name of the actor.</param>
		/// <param name="indentation">The number of tabs to remove from each line when returning the final string.  
		/// This enables you to indent multiline strings in your code without the indentation showing up in reports.</param>
		public Generated_ExplanationAttribute(string explanation, int indentation=0)
		{
			this.explanation = explanation;
			this.indentation = indentation;
		}
	
		/// <summary>
		/// Returns the name of the actor.
		/// </summary>
		/// <returns>The name of the actor.</returns>
		public string GetExplanation()
		{
			return explanation.RemoveIndentation(indentation, true);
		}
	}
}
