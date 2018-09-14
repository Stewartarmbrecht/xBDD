
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
	public class ExplanationAttribute : System.Attribute
	{
		string explanation;
		int indentation;
		TextFormat textFormat;
			
		/// <summary>
		/// Set the actor for the feature.
		/// </summary>
		/// <param name="explanation">The name of the actor.</param>
		/// <param name="indentation">The number of tabs to remove from each line when returning the final string.  
		/// This enables you to indent multiline strings in your code without the indentation showing up in reports.</param>
		/// <param name="textFormat">The format of the text provided for the explanation. This controls the rendering in the HTML report.
		/// The default format is text. You can also use Markdown, HTML, and all languages supported by google prettyprint.</param>
		public ExplanationAttribute(string explanation, int indentation=0, TextFormat textFormat = TextFormat.markdown)
		{
			this.explanation = explanation;
			this.indentation = indentation;
			this.textFormat = textFormat;
		}
	
		/// <summary>
		/// Returns the name of the actor.
		/// </summary>
		/// <returns>The name of the actor.</returns>
		public string GetExplanation()
		{
			return explanation.RemoveIndentation(indentation, true);
		}
		/// <summary>
		/// The text format of the explanation.
		/// </summary>
		/// <returns>The text format of the explanation.</returns>
		public TextFormat GetExplanationFormat()
		{
			return textFormat;
		}
	}
}
