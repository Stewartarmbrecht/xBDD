
namespace xBDD
{
	using System;
	using System.Text;
	using xBDD.Utility;
	/// <summary>
	/// Tracks one or more person or team assignments to the scenario or feature.
	/// </summary>
	[System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Method, AllowMultiple = true)]
	public class AssignmentsAttribute : System.Attribute
	{
		string[] names;
			
		/// <summary>
		/// Tracks one or more person or team assignments to the scenario or feature.
		/// </summary>
		/// <param name="names">The names of the team or people assigned to the scenario or feature.</param>
		public AssignmentsAttribute(params string[] names)
		{
			this.names = names;
		}
	
		/// <summary>
		/// Returns a string array of assignments.
		/// </summary>
		/// <returns>The names of the assignments.</returns>
		public string[] GetNames()
		{
			return this.names;
		}
	}
}
