
namespace xBDD
{
	using System;
	using System.Text;
	using xBDD.Utility;
	/// <summary>
	/// Tracks one or more tags for the scenario or feature.
	/// </summary>
	[System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Method, AllowMultiple = true)]
	public class TagsAttribute : System.Attribute
	{
		string[] tags;
			
		/// <summary>
		/// Tracks one or more tags for the scenario or feature.
		/// </summary>
		/// <param name="tags">The tags for the scenario or feature.</param>
		public TagsAttribute(params string[] tags)
		{
			this.tags = tags;
		}
	
		/// <summary>
		/// Returns a string array of tags.
		/// </summary>
		/// <returns>The names of the tags.</returns>
		public string[] GetTags()
		{
			return tags;
		}
	}
}
